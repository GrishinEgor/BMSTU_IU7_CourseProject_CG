using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WifiSimulation
{
    class WifiModel
    {
        int minX, minY, minZ;
        int lenX, lenY, lenZ;
        int antennaX, antennaY, antennaZ;

        List<Matrix<double>> powerLoss;
        public double maxPowerLoss;

        List<MapColor> arrMapColor;

        Matrix<bool> mapBarrier;
        // количество препятствий между каждой точкой и антенной
        Matrix<int> mapCountBarriers;


        public WifiModel(int centX, int dx, int centY, int dy, int centZ, int dz, int antennaX, int antennaY, int antennaZ)
        {
            this.minX = centX - dx;
            this.minY = centY - dy;
            this.minZ = centZ - dz;
            this.lenX = 2 * dx + 1;
            this.lenY = 2 * dy + 1;
            this.lenZ = 2 * dz + 1;
            this.antennaX = antennaX;
            this.antennaY = antennaY;
            this.antennaZ = antennaZ;
            this.arrMapColor = new List<MapColor>(this.lenY);
            for (int i = 0; i < this.lenY; i++)
                this.arrMapColor.Add(new MapColor(new Matrix<Color>(this.lenX, this.lenZ),
                                                   new Point3D(this.minX, this.minY + i, this.minZ),
                                                   MapColor.Plane.OXZ));
            this.powerLoss = new List<Matrix<double>>(this.lenY);
            for (int i = 0; i < this.lenY; i++)
                this.powerLoss.Add(new Matrix<double>(this.lenX, this.lenZ));
            this.mapBarrier = new Matrix<bool>(this.lenX, this.lenZ);
            this.mapCountBarriers = new Matrix<int>(this.lenX, this.lenZ);
        }

        public MapColor GetMap(int y)
        {
            return arrMapColor[y - minY];
        }

        public void AddBarrier(int centX, int dx, int centZ, int dz)
        {
            for (int i = centX - dx; i <= centX + dx; i++)
                for (int j = centZ - dz; j <= centZ + dz; j++)
                    mapBarrier[i, j] = true;
        }

        public void SetAntenna(int antennaX, int antennaY, int antennaZ)
        {
            this.antennaX = antennaX;
            this.antennaY = antennaY;
            this.antennaZ = antennaZ;
        }

        public void RemoveAllBarriers()
        {
            for (int x = 0; x < lenX; x++)
                for (int z = 0; z < lenZ; z++)
                    mapBarrier[x, z] = false;
        }

        public void ProcessModel()
        {
            ProcessMapCountBarriers();
            ProcessPowerLoss();
            ProcessArrMapColor();
        }

        private void ProcessMapCountBarriers()
        {
            Console.WriteLine("Processing mapCountBarriers");
            for (int x = 0; x < lenX; x++)
                for (int z = 0; z < lenZ; z++)
                    mapCountBarriers[x, z] = -1;
            mapCountBarriers[antennaX, antennaZ] = 0;

            for (int x = 0; x < lenX; x++)
                for (int z = 0; z < lenZ; z++)
                    if (mapCountBarriers[x, z] == -1)
                        SendingRayMapCountBarriers(x, z);
        }

        private void SendingRayMapCountBarriers(int targX, int targZ)
        {
            double dx = targX - antennaX;
            double dz = targZ - antennaZ;
            int n;

            if (Math.Abs(dx) > Math.Abs(dz))
            {
                n = Math.Abs((int)Math.Round(dx));
                dz /= Math.Abs(dx);
                dx = dx >= 0 ? 1 : -1;
            }
            else
            {
                n = Math.Abs((int)Math.Round(dz));
                dx /= Math.Abs(dz);
                dz = dz >= 0 ? 1 : -1;
            }

            double x = antennaX + dx, z = antennaZ + dz;
            int lastX = antennaX, lastZ = antennaZ;
            int curX, curZ;
            for (int i = 0; i < n; i++)
            {
                curX = (int)Math.Round(x);
                curZ = (int)Math.Round(z);
                mapCountBarriers[curX, curZ] = mapCountBarriers[lastX, lastZ];
                if (mapBarrier[curX, curZ] && !mapBarrier[lastX, lastZ])
                    mapCountBarriers[curX, curZ] += 1;

                lastX = curX;
                lastZ = curZ;
                x += dx;
                z += dz;
            }
        }

        private void ProcessPowerLoss()
        {
            maxPowerLoss = 0;
            int dx = -antennaX, dy = -antennaY, dz = -antennaZ;

            // Длина метра в пространстве модели
            int meter = 100;

            int n, N = 30;
            // Частота в МГц
            double d, f = 2000;
            double lambda = 300 / f;
            double presumm = 20 * Math.Log10(f) - 28;
            double presummFS = 20 * Math.Log10(4 * Math.PI / lambda);
            for (int y = 0; y < lenY; y++)
            {
                dx = -antennaX;
                Console.WriteLine("Processing powerLoss[" + y + "]");
                for (int x = 0; x < lenX; x++)
                {
                    dz = -antennaZ;
                    for (int z = 0; z < lenZ; z++)
                    {
                        d = Math.Sqrt(dx * dx + dy * dy + dz * dz) / meter;
                        if (d > 1)
                        {
                            powerLoss[y][x, z] = presumm + N * Math.Log10(d);
                            n = mapCountBarriers[x, z];
                            if (n > 0)
                                powerLoss[y][x, z] += 15 + 4 * (n - 1);
                        }
                        else
                            powerLoss[y][x, z] = Math.Max(presumm + 20 * Math.Log10(d), 0);


                        if (powerLoss[y][x, z] > maxPowerLoss)
                            maxPowerLoss = powerLoss[y][x, z];

                        dz++;
                    }
                    dx++;
                }
                dy++;
            }
            Console.WriteLine(maxPowerLoss);
        }

        private void ProcessArrMapColor()
        {
            Console.WriteLine("Processing arrMapColors");
            for (int y = 0; y < lenY; y++)
            {
                Console.WriteLine("Processing arrMapColors[" + y + "]");
                for (int x = 0; x < lenX; x++)
                    for (int z = 0; z < lenZ; z++)
                    {
                        Color color = Colors.Mix(Color.DarkBlue, Color.Red, powerLoss[y][x, z] / maxPowerLoss);
                        arrMapColor[y].SetColor(minX + x, minY + y, minZ + z, color);
                    }
            }

            #region Вывод карты количества препятствий
            /*
            Console.WriteLine("Processing arrMapColors");
            for (int y = 0; y < lenY; y++)
            {
                Console.WriteLine("Processing slice " + y);
                for (int x = 0; x < lenX; x++)
                    for (int z = 0; z < lenZ; z++)
                    {
                        switch (mapCountBarriers[x, z])
                        {
                            case 0:
                                arrMapColor[y].SetColor(minX + x, minY + y, minZ + z, Color.Red);
                                break;
                            case 1:
                                arrMapColor[y].SetColor(minX + x, minY + y, minZ + z, Color.Yellow);
                                break;
                            case 2:
                                arrMapColor[y].SetColor(minX + x, minY + y, minZ + z, Color.Blue);
                                break;
                            default:
                                arrMapColor[y].SetColor(minX + x, minY + y, minZ + z, Color.Pink);
                                break;
                        }
                        
                    }
            }
            */
            #endregion

            #region Вывод градиента
            /*
            Console.WriteLine("Preparing default colors");
            for (int i = 0; i < lenY; i++)
            {
                Console.WriteLine("Processing slice " + i);
                Color colorFirst = Colors.Mix(Color.Red, Color.Olive, i / (double)lenY);
                Color colorSec = Colors.Mix(Color.GreenYellow, Color.DarkBlue, i / (double)lenY);
                for (int j = 0; j < lenX; j++)
                    for (int k = 0; k < lenZ; k++)
                    {
                        Color color = Colors.Mix(colorFirst, colorSec, j / (double)lenX);
                        arrMapColor[i].SetColor(minX + j, minY + i, minZ + k, color);
                    }
            }
            */
            #endregion
        }
    }
}
