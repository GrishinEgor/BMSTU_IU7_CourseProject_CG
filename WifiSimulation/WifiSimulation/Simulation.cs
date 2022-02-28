using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace WifiSimulation
{
    class Simulation
    {
        ZBuffer zBuffer;
        PictureBox canvas;
        Label labelTime, labelMaxPowerLoss;
        // 0 - земля, 1 - антенна, 2... - препятствия, n-1 - индикаторный слой если есть
        Scene scene, turnedScene;
        WifiModel wifiModel;

        // Координаты центра и половины длин сторон-1 обрабатываемого пространства
        int centX, centY, centZ;
        int dx, dy, dz;
        // Вершина обрабатываемого пространства с минимальными координатами
        int minX, minY, minZ;
        int antennaX = 550, antennaY = 50, antennaZ = 50;

        bool shadows = false;
        bool optimisation = false;
        bool scenePreprocessed = false;
        bool showIndicatorSlice = false;
        int indicatorSliceY;
        LightSource sun = new LightSource(Color.White, -90, 0, 0, new Vector(0, 1, 0));
        double tetax = -25, tetay = 0, tetaz = 0;


        public Simulation(PictureBox canvas, Label labelTime, Label labelMaxPowerLoss)
        {
            this.centX = canvas.Size.Width / 2;
            this.centY = 300;
            this.centZ = 0;
            this.dx = 300;
            this.dy = 100;
            this.dz = 300;
            this.minX = centX - dx;
            this.minY = centY - dy;
            this.minZ = centZ - dz;
            
            this.indicatorSliceY = centY;
            this.canvas = canvas;
            this.labelTime = labelTime;
            this.labelMaxPowerLoss = labelMaxPowerLoss;
            this.zBuffer = new ZBuffer(canvas.Size, dx * 2 + 1, dy * 2 + 1, dz * 2 + 1);
            this.scene = new Scene();
            this.wifiModel = new WifiModel(centX, dx, centY, dy, centZ, dz, antennaX, antennaY, antennaZ);
            Transformation.SetCenter(centX, centY);

            scene.CreateGround(centX, dx, centZ, dz, centY+dy, 5, 0);
            wifiModel.SetAntenna(antennaX, antennaY, antennaZ);
            scene.CreateCube(Color.Brown, minX + antennaX, 20, minY + antennaY, 20, minZ + antennaZ, 20, 1);
            wifiModel.AddBarrier(100, 30, dz, 100);
            scene.CreateCubeOnGround(Color.Gray, minX + 100, 30, minZ + dz, 100, dy * 2 - 1);
            wifiModel.AddBarrier(350, 30, dz, 150);
            scene.CreateCubeOnGround(Color.Gray, minX + 350, 30, minZ + dz, 150, dy * 2 - 1);
            wifiModel.ProcessModel();
            labelMaxPowerLoss.Text = ((int)wifiModel.maxPowerLoss).ToString() + " Дб";
            RedrawScene();
        }

        public void RedrawScene(bool measureTime = true)
        {

            Stopwatch stopWatch = new Stopwatch();
            if (measureTime)
                stopWatch.Start();
            
            if (showIndicatorSlice && optimisation)
            {
                if (scenePreprocessed)
                {
                    int[] indexes = new int[1];
                    indexes[0] = turnedScene.Count() - 1;
                    zBuffer.ProcessScene(turnedScene, indexes, sun, true);
                }
                else
                {
                    turnedScene = new Scene(scene);
                    LogTransformation log = new LogTransformation();
                    log.Add(new WritingTransformation(Transformation.Type.RotateY, tetay));
                    log.Add(new WritingTransformation(Transformation.Type.RotateX, tetax));
                    turnedScene.Transform(log);

                    int[] indexes = new int[turnedScene.Count() - 1];
                    for (int i = 0; i < turnedScene.Count() - 1; i++)
                        indexes[i] = i;

                    zBuffer.ProcessScene(turnedScene, indexes, sun);
                    zBuffer.Save();
                    scenePreprocessed = true;
                    RedrawScene(false);
                    return;
                }
            }
            else
            {
                if (shadows)
                {
                    turnedScene = new Scene(scene);
                    LogTransformation log = new LogTransformation();
                    log.Add(new WritingTransformation(Transformation.Type.RotateY, tetay));
                    log.Add(new WritingTransformation(Transformation.Type.RotateX, tetax));
                    turnedScene.Transform(log);

                    zBuffer.ProcessSceneWithShadows(turnedScene, sun);
                }
                else
                {
                    turnedScene = new Scene(scene);
                    LogTransformation log = new LogTransformation();
                    log.Add(new WritingTransformation(Transformation.Type.RotateY, tetay));
                    log.Add(new WritingTransformation(Transformation.Type.RotateX, tetax));
                    turnedScene.Transform(log);

                    int[] indexes = new int[turnedScene.Count()];
                    for (int i = 0; i < turnedScene.Count(); i++)
                        indexes[i] = i;

                    zBuffer.ProcessScene(turnedScene, indexes, sun);
                }
            }

            canvas.Image = zBuffer.GetImage();
            canvas.Refresh();

            if (measureTime)
                labelTime.Text = stopWatch.Elapsed.Milliseconds.ToString() + " мс";
        }

        public void ChangeShadows()
        {
            shadows = !shadows;
            if (optimisation)
                optimisation = false;
            scenePreprocessed = false;
            RedrawScene();
        }

        public void ChangeOptimisation()
        {
            optimisation = !optimisation;
            if (optimisation)
                shadows = false;
            scenePreprocessed = false;
            RedrawScene();
        }

        public void ChangeShowIndicatorSlice()
        {
            showIndicatorSlice = !showIndicatorSlice;
            if (showIndicatorSlice)
                scene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
            else
                scene.Remove(scene.Count() - 1);

            scenePreprocessed = false;
            RedrawScene();
        }

        public void MoveIndicatorSliceUp()
        {
            if (showIndicatorSlice)
            {
                indicatorSliceY = indicatorSliceY - 10 > centY - dy ? indicatorSliceY - 10 : centY - dy;
                scene.Remove(scene.Count() - 1);
                scene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                if (scenePreprocessed)
                {
                    turnedScene.Remove(turnedScene.Count() - 1);
                    turnedScene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                }
                RedrawScene();
            }
        }

        public void MoveIndicatorSliceDown()
        {
            if (showIndicatorSlice)
            {
                indicatorSliceY = indicatorSliceY + 10 < centY + dy ? indicatorSliceY + 10 : centY + dy - 1;
                scene.Remove(scene.Count() - 1);
                scene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                if (scenePreprocessed)
                {
                    turnedScene.Remove(turnedScene.Count() - 1);
                    turnedScene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                }
                RedrawScene();
            }
        }

        public void StartMovingIndicatorSlice()
        {
            bool oldShadows = shadows, oldOptimisation = optimisation, oldShowIndicatorSlice = showIndicatorSlice;
            shadows = false;
            optimisation = true;
            showIndicatorSlice = true;
            if (oldShowIndicatorSlice)
                scene.Remove(scene.Count() - 1);
            indicatorSliceY = centY - dy;
            scene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
            RedrawScene(false);

            while (indicatorSliceY < centY + dy - 1)
            {
                indicatorSliceY = indicatorSliceY + 5 >= centY + dy ? centY + dy - 1 : indicatorSliceY + 5;
                scene.Remove(scene.Count() - 1);
                scene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                turnedScene.Remove(turnedScene.Count() - 1);
                turnedScene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                RedrawScene(false);
            }

            while (indicatorSliceY > centY - dy)
            {
                indicatorSliceY = indicatorSliceY - 5 < centY - dy ? centY - dy : indicatorSliceY - 5;
                scene.Remove(scene.Count() - 1);
                scene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                turnedScene.Remove(turnedScene.Count() - 1);
                turnedScene.CreateSpecialSlice(wifiModel.GetMap(indicatorSliceY), centX, dx, centZ, dz, indicatorSliceY);
                RedrawScene(false);
            }

            shadows = oldShadows;
            optimisation = oldOptimisation;
            showIndicatorSlice = oldShowIndicatorSlice;
            scenePreprocessed = false;
            if (!showIndicatorSlice)
                scene.Remove(scene.Count() - 1);
            RedrawScene();
        }

        public void LightSourceTop()
        {
            sun = new LightSource(Color.White, -90, 0, 0, new Vector(0, 1, 0));
            scenePreprocessed = false;
            RedrawScene();
        }

        public void LightSourceLeft()
        {
            sun = new LightSource(Color.White, -60, -90, 0, new Vector(0.5, 1, 0));
            scenePreprocessed = false;
            RedrawScene();
        }

        public void LightSourceRight()
        {
            sun = new LightSource(Color.White, -60, 90, 0, new Vector(-0.5, 1, 0));
            scenePreprocessed = false;
            RedrawScene();
        }

        public void RotateLeft()
        {
            tetay += 20;
            scenePreprocessed = false;
            RedrawScene();
        }

        public void RotateRight()
        {
            tetay -= 20;
            scenePreprocessed = false;
            RedrawScene();
        }

        public void AddBarrier(int centX, int dx, int centZ, int dz)
        {
            wifiModel.AddBarrier(centX, dx, centZ, dz);
            wifiModel.ProcessModel();
            labelMaxPowerLoss.Text = ((int)wifiModel.maxPowerLoss).ToString() + " дБ";

            if (showIndicatorSlice)
                scene.CreateCubeOnGround(Color.Gray, minX + centX, dx, minZ + centZ, dz, dy * 2 - 1, scene.Count() - 1);
            else
                scene.CreateCubeOnGround(Color.Gray, minX + centX, dx, minZ + centZ, dz, dy * 2 - 1);
            scenePreprocessed = false;
            RedrawScene();
        }

        public void RemoveAllBarriers()
        {
            wifiModel.RemoveAllBarriers();
            wifiModel.ProcessModel();
            labelMaxPowerLoss.Text = ((int)wifiModel.maxPowerLoss).ToString() + " дБ";

            if (showIndicatorSlice)
                for (int i = scene.Count() - 4; i >= 0; i--)
                    scene.Remove(i + 2);
            else
                for (int i = scene.Count() - 3; i >= 0; i--)
                    scene.Remove(i + 2);
            scenePreprocessed = false;
            RedrawScene();
        }

        public void SetAntenna(int antennaX, int antennaY, int antennaZ)
        {
            wifiModel.SetAntenna(antennaX, antennaY, antennaZ);
            wifiModel.ProcessModel();
            labelMaxPowerLoss.Text = ((int)wifiModel.maxPowerLoss).ToString() + " дБ";

            scene.Remove(1);
            scene.CreateCube(Color.Brown, minX + antennaX, 20, minY + antennaY, 20, minZ + antennaZ, 20, 1);
            scenePreprocessed = false;
            RedrawScene();
        }
    }
}
