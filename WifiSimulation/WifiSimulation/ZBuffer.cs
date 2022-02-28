using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WifiSimulation
{
    class ZBuffer
    {
        private Bitmap img;
        private Bitmap imgSaved;
        private int[][] Zbuf;
        private int[][] ZbufSaved;
        private int[][] ZbufFromSun;
        Size sizeScreen;
        Size sizeFromsSun;
        int shiftXFromSun;
        int shiftYFromSun;

        private static readonly int zBackground = -10000;

        /// <param name="sizeScreen">Размеры экрана</param>
        /// <param name="sceneX">Ширина сцены</param>
        /// <param name="sceneY">Высота сцены</param>
        /// <param name="sceneZ">Глубина сцены</param>
        public ZBuffer(Size sizeScreen, int sceneX, int sceneY, int sceneZ)
        {
            InitBuf(ref Zbuf, sizeScreen.Width, sizeScreen.Height);
            InitBuf(ref ZbufSaved, sizeScreen.Width, sizeScreen.Height);
            this.sizeScreen = sizeScreen;

            int diagonal = (int)Math.Sqrt(sceneX * sceneX + sceneY * sceneY + sceneZ * sceneZ) + 2;
            this.sizeFromsSun = new Size(diagonal, diagonal);
            InitBuf(ref ZbufFromSun, sizeFromsSun.Width, sizeFromsSun.Height);
            this.shiftXFromSun = (diagonal - sizeScreen.Width) / 2;
            this.shiftYFromSun = (diagonal - sizeScreen.Height) / 2;
        }

        private void InitBuf(ref int[][] buf, int w, int h)
        {
            buf = new int[h][];
            for (int i = 0; i < h; i++)
                buf[i] = new int[w];
        }

        private void FillBuf(ref int[][] buf, int w, int h, int value)
        {
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    buf[i][j] = value;
        }

        private void CopyBuf(ref int[][] bufFrom, ref int[][] bufTo, int w, int h)
        {
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    bufTo[i][j] = bufFrom[i][j];
        }
        
        public Bitmap GetImage()
        {
            return img;
        }

        public void Save()
        {
            imgSaved = new Bitmap(img);
            CopyBuf(ref Zbuf, ref ZbufSaved, sizeScreen.Width, sizeScreen.Height);
        }

        /// <summary>
        /// Обрабока сцены
        /// </summary>
        /// <param name="indexes">Индексы моделей сцены, которые следует обработать</param>
        public void ProcessScene(Scene scene, int[] indexes, LightSource sun, bool useSavedBuf = false)
        {
            if (useSavedBuf)
            {
                img = new Bitmap(imgSaved);
                CopyBuf(ref ZbufSaved, ref Zbuf, sizeScreen.Width, sizeScreen.Height);
            }
            else
            {
                img = new Bitmap(sizeScreen.Width, sizeScreen.Height);
                FillBuf(ref Zbuf, sizeScreen.Width, sizeScreen.Height, zBackground);
            }
            foreach (int i in indexes)
                ProcessModel(scene.models[i], sun);
        }

        /// <summary>
        /// Обрабока одной модели для занесения ее в буфер
        /// </summary>
        /// <param name="m">Модель</param>
        private void ProcessModel(GraphicModel graphicModel, LightSource sun)
        {
            Color draw;
            foreach (Polygon polygon in graphicModel.polygons)
            {
                polygon.CalculatePointsInside(0, sizeScreen.Width-1, 0, sizeScreen.Height-1);
                foreach (Point3D point in polygon.pointsInside)
                {
                    draw = polygon.GetColor(sun, point);
                    if (point.z > Zbuf[point.y][point.x])
                    {
                        Zbuf[point.y][point.x] = point.z;
                        img.SetPixel(point.x, point.y, draw);
                    }
                }
            }
        }

        /// <summary>
        /// Обработка сцены с наложением теней
        /// </summary>
        public void ProcessSceneWithShadows(Scene scene, LightSource sun)
        {
            Scene sceneFromSun = new Scene(scene);
            LogTransformation log = new LogTransformation();
            log.Add(new WritingTransformation(Transformation.Type.RotateX, sun.tetax));
            log.Add(new WritingTransformation(Transformation.Type.RotateY, sun.tetay));
            log.Add(new WritingTransformation(Transformation.Type.RotateZ, sun.tetaz));
            sceneFromSun.Transform(log);

            FillBuf(ref ZbufFromSun, sizeFromsSun.Width, sizeFromsSun.Height, zBackground);
            for (int i = 0; i < sceneFromSun.Count(); i++)
                ProcessModelForSun(sceneFromSun.models[i], sun);

            img = new Bitmap(sizeScreen.Width, sizeScreen.Height);
            FillBuf(ref Zbuf, sizeScreen.Width, sizeScreen.Height, zBackground);
            for (int i = 0; i < scene.Count(); i++)
                ProcessModel(scene.models[i], sun);

            for (int i = 0; i < sizeScreen.Width; i++)
            {
                for (int j = 0; j < sizeScreen.Height; j++)
                {
                    int z = Zbuf[j][i];
                    if (z != zBackground)
                    {
                        Point3D turnedPoint = new Point3D(i, j, z);
                        Transformation.Transform(turnedPoint, log);

                        Color color = img.GetPixel(i, j);
                        // текущая точка невидима из источника света
                        if (ZbufFromSun[turnedPoint.y + shiftYFromSun][turnedPoint.x + shiftXFromSun] > turnedPoint.z + 10)
                            img.SetPixel(i, j, Colors.Mix(Color.Black, color, 0.4f));
                        else
                            img.SetPixel(i, j, color);
                    }
                }
            }
        }

        /// <summary>
        /// Обработка модели с возможностью пропуска полигонов с установленным полем special 
        /// Используется для создания теней: чтобы избежать собственных теней, земля пропускается.
        /// </summary>
        private void ProcessModelForSun(GraphicModel graphicModel, LightSource sun)
        {
            Color draw;
            foreach (Polygon polygon in graphicModel.polygons)
                if (!polygon.ignore)
                {
                    polygon.CalculatePointsInside(-shiftXFromSun, sizeFromsSun.Width - shiftXFromSun -1,
                                                  -shiftYFromSun, sizeFromsSun.Height - shiftYFromSun - 1);
                    foreach (Point3D point in polygon.pointsInside)
                    {
                        draw = polygon.GetColor(sun, point);
                        if (point.z > ZbufFromSun[point.y + shiftYFromSun][point.x + shiftXFromSun])
                            ZbufFromSun[point.y + shiftYFromSun][point.x + shiftXFromSun] = point.z;
                    }
                }
        }
        
    }
}
