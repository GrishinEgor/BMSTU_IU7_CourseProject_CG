using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WifiSimulation
{
    /// <summary>
    /// Модель владеет вершинами, полигонами.
    /// Полигоны модели владеют теми же вершинами (в памяти) что и модель.
    /// При создании нового полигона, модель передаёт ему общий журнал преобразований сцены,
    /// но сама им не владеет.
    /// </summary>
    class GraphicModel
    {
        List<Point3D> vertices;
        public List<Polygon> polygons;
        private List<int[]> indexes;
        LogTransformation logTransformation;

        public GraphicModel(LogTransformation logTransformation)
        {
            vertices = new List<Point3D>();
            polygons = new List<Polygon>();
            indexes = new List<int[]>();
            this.logTransformation = logTransformation;
        }

        public GraphicModel(GraphicModel graphicModel, LogTransformation logTransformation)
        {
            this.vertices = new List<Point3D>(graphicModel.vertices.Count);
            for (int i = 0; i < graphicModel.vertices.Count; i++)
                this.vertices.Add(new Point3D(graphicModel.vertices[i]));

            this.logTransformation = logTransformation;
            this.polygons = new List<Polygon>(graphicModel.polygons.Count);
            this.indexes = new List<int[]>(graphicModel.indexes.Count);
            for (int i = 0; i < graphicModel.polygons.Count; i++)
            {
                switch (graphicModel.polygons[i].typeColor)
                {
                    case Polygon.TypeColor.BasicColor:
                        CreatePolygon(graphicModel.polygons[i].basicColor,
                                      graphicModel.polygons[i].ignore,
                                      (int[])graphicModel.indexes[i].Clone());
                        break;
                    case Polygon.TypeColor.MapColor:
                        CreatePolygon(graphicModel.polygons[i].mapColor,
                                      graphicModel.polygons[i].ignore,
                                      (int[])graphicModel.indexes[i].Clone());
                        break;
                }
            }
        }

        public void AddVertex(Point3D vertex)
        {
            Transformation.Transform(vertex, logTransformation);
            vertices.Add(vertex);
        }

        public void AddVertex(int x, int y, int z)
        {
            Point3D vertex = new Point3D(x, y, z);
            AddVertex(vertex);
        }

        /// <summary>
        /// Создание полигона c постоянным цветом, используя индексы вершин модели
        /// </summary>
        /// <param name="indexes">Индексы вершин многоугольника из списка всех вершин модели</param>
        public void CreatePolygon(Color color, bool special, params int[] indexes)
        {
            this.indexes.Add(indexes);

            List<Point3D> verticesPolygon = new List<Point3D>();
            foreach (int i in indexes)
            {
                verticesPolygon.Add(vertices[i]);
            }
            polygons.Add(new Polygon(verticesPolygon, color, logTransformation, special));
        }

        /// <summary>
        /// Создание полигона c картой цветов, используя индексы вершин модели
        /// </summary>
        /// <param name="indexes">Индексы вершин многоугольника из списка всех вершин модели</param>
        public void CreatePolygon(MapColor mapColor, bool special, params int[] indexes)
        {
            this.indexes.Add(indexes);

            List<Point3D> verticesPolygon = new List<Point3D>();
            foreach (int i in indexes)
            {
                verticesPolygon.Add(vertices[i]);
            }
            polygons.Add(new Polygon(verticesPolygon, mapColor, logTransformation, special));
        }

        public void Transform(LogTransformation logTransformation)
        {
            foreach (Point3D v in vertices)
                Transformation.Transform(v, logTransformation);
            foreach (Polygon p in polygons)
                p.changed = true;
        }

        public void Transform(WritingTransformation writing)
        {
            foreach (Point3D v in vertices)
                Transformation.Transform(v, writing);
            foreach (Polygon p in polygons)
                p.changed = true;
        }
    }

    /// <summary>
    /// Прямоугольный полигон, при инициализации перпендикулярный одной из координатных осей,
    /// стороны которого параллельны другим осям
    /// </summary>
    class Polygon
    {
        List<Point3D> v;
        public bool changed = true;
        Vector normal;
        public List<Point3D> pointsInside;
        LogTransformation logTransformation;

        public delegate Color GetColorDelegate(LightSource lightSource, Point3D point);
        public GetColorDelegate GetColor;
        public Color basicColor;
        public MapColor mapColor;
        public enum TypeColor
        {
            BasicColor = 1,
            MapColor = 2
        }
        public TypeColor typeColor;

        public bool ignore = false; // игнорируем ли от лица солнца

        #region Создание Polygon

        public Polygon(List<Point3D> vertex, Color color, LogTransformation logTransformation, bool special = false)
        {
            this.v = vertex;
            FindNormal();
            this.pointsInside = new List<Point3D>();
            this.logTransformation = logTransformation;
            this.GetColor = GetColorBasicColor;
            this.basicColor = color;
            this.typeColor = TypeColor.BasicColor;
            this.ignore = special;
        }

        public Polygon(List<Point3D> vertex, MapColor mapColor, LogTransformation logTransformation, bool special = false)
        {
            this.v = vertex;
            FindNormal();
            this.pointsInside = new List<Point3D>();
            this.logTransformation = logTransformation;
            this.GetColor = GetColorMapColor;
            this.mapColor = mapColor;
            this.typeColor = TypeColor.MapColor;
            this.ignore = special;
        }
        #endregion

        #region Нахождение внутренних точек

        /// <summary>
        /// Получение точек, лежащих внутри полигона
        /// </summary>
        /// <param name="firstXPossible">Минимальная x координата</param>
        /// <param name="firstYPossible">Минимальная y координата</param>
        /// <param name="lastXPossible">Максимальная x координата</param>
        /// <param name="lastYPossible">Максимальная y координата</param>
        public void CalculatePointsInside(int minX, int maxX, int minY, int maxY)
        {
            pointsInside = new List<Point3D>();

            List<Point3D> triangle = new List<Point3D>();
            triangle.Add(v[0]);
            triangle.Add(v[2]);
            triangle.Add(v[1]);
            CalculatePointsInsideTriangle(triangle, minX, maxX, minY, maxY);
            triangle = new List<Point3D>();
            triangle.Add(v[0]);
            triangle.Add(v[2]);
            triangle.Add(v[3]);
            CalculatePointsInsideTriangle(triangle, minX, maxX, minY, maxY);
        }

        /// <summary>
        /// Поиск точек, лежащих внутри треугольника
        /// </summary>
        /// <param name="v">Вершины треугольника</param>
        /// <param name="firstXPossible">Минимальная x координата</param>
        /// <param name="firstYPossible">Минимальная y координата</param>
        /// <param name="lastXPossible">Максимальная x координата</param>
        /// <param name="lastYPossible">Максимальная y координата</param>
        private void CalculatePointsInsideTriangle(List<Point3D> v, int firstXPossible, int lastXPossible, int firstYPossible, int lastYPossible)
        {
            int yMax, yMin;
            int[] x = new int[3], y = new int[3];

            for (int i = 0; i < 3; ++i)
            {
                x[i] = v[i].x;
                y[i] = v[i].y;
            }

            yMax = y.Max();
            yMin = y.Min();

            yMin = (yMin < firstYPossible) ? firstYPossible : yMin;
            yMax = (yMax < lastYPossible) ? yMax : lastYPossible;

            int x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;

            for (int yDot = yMin; yDot <= yMax; yDot++)
            {
                int fFirst = 1;
                for (int n = 0; n < 3; ++n)
                {
                    int n1 = (n + 1) % 3;

                    if (yDot >= Math.Max(y[n], y[n1]) || yDot < Math.Min(y[n], y[n1])) // || y[n] == y[n1]  
                        continue; // точка вне

                    double m = (double)(y[n] - yDot) / (y[n] - y[n1]);
                    if (fFirst == 0)
                    {
                        x2 = x[n] + (int)(m * (x[n1] - x[n]));
                        z2 = v[n].z + m * (v[n1].z - v[n].z);
                    }
                    else
                    {
                        x1 = x[n] + (int)(m * (x[n1] - x[n]));
                        z1 = v[n].z + m * (v[n1].z - v[n].z);
                    }
                    fFirst = 0;
                }

                if (x2 < x1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref z1, ref z2);
                }

                int xStart = (x1 < firstXPossible) ? firstXPossible : x1;
                int xEnd = (x2 < lastXPossible) ? x2 : lastXPossible;
                for (int xDot = xStart; xDot < xEnd; xDot++)
                {
                    double m = (double)(x1 - xDot) / (x1 - x2);
                    double zDot = z1 + m * (z2 - z1);

                    pointsInside.Add(new Point3D(xDot, yDot, (int)zDot));
                }
            }
        }
        #endregion

        /// <summary>
        /// Получение внутреннего (в сторону материала) вектора нормали к полигону
        /// </summary>
        public void FindNormal()
        {
            if (changed)
            {
                int ax = v[1].x - v[0].x, ay = v[1].y - v[0].y, az = v[1].z - v[0].z;
                int bx = v[2].x - v[1].x, by = v[2].y - v[1].y, bz = v[2].z - v[1].z;

                this.normal = new Vector(ay * bz - az * by, az * bx - ax * bz, ax * by - ay * bx);
                changed = false;
            }
        }

        /// <summary>
        /// Нахождение цвета полигона в данной точке с наложением затемнения в зависимости 
        /// от его расположения к источнику света в случае постоянного цвета всего полигона
        /// </summary>
        public Color GetColorBasicColor(LightSource lightSource, Point3D point)
        {
            FindNormal();
            double cos = Vector.ScalarMultiplication(lightSource.direction, normal) /
                (lightSource.direction.length * normal.length);

            if (cos <= 0)
                return Colors.Mix(basicColor, Color.Black, 0.2f);
            else
                return Colors.Mix(basicColor, Color.Black, cos);
        }

        /// <summary>
        /// Нахождение цвета полигона в данной точке с наложением затемнения в зависимости 
        /// от его расположения к источнику света в случае наличия карты цветов полигона
        /// </summary>
        public Color GetColorMapColor(LightSource lightSource, Point3D startPoint)
        {
            Point3D point = new Point3D(startPoint);
            Transformation.Transform(point, logTransformation.GetReverse());

            Color color = mapColor.GetColor(point);
            FindNormal();
            double cos = Vector.ScalarMultiplication(lightSource.direction, normal) /
                (lightSource.direction.length * normal.length);

            if (cos <= 0)
                return Colors.Mix(color, Color.Black, 0.2f);
            else
                return Colors.Mix(color, Color.Black, cos);
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    /// <summary>
    /// Хранит карту цветов для прямоугольного полигона, лежащего в одной из трёх плоскостей.
    /// Характеризуется матрицей цветов, плоскостью, в которой расположен полигон и начальной точкой.
    /// Считается, что ребра полигона параллельны координатным осям и 
    /// начальная точка - его вершина с минимальными координатами.
    /// </summary>
    class MapColor
    {
        Matrix<Color> matr;
        Point3D minPoint;
        public enum Plane
        {
            OXY = 1,
            OYZ = 2,
            OXZ = 3
        }
        Plane plane;

        public MapColor(Matrix<Color> matr, Point3D minPoint, Plane plane)
        {
            this.matr = matr;
            this.minPoint = minPoint;
            this.plane = plane;
        }

        public Color GetColor(Point3D point)
        {
            CheckPoint(point);
            switch (plane)
            {
                case Plane.OXY:
                    return matr[point.x - minPoint.x, point.y - minPoint.y];
                case Plane.OYZ:
                    return matr[point.y - minPoint.y, point.z - minPoint.z];
                case Plane.OXZ:
                    return matr[point.x - minPoint.x, point.z - minPoint.z];
                default:
                    throw new Exception("Попытка передачи несуществующей плоскости");
            }
        }

        public void SetColor(int x, int y, int z, Color color)
        {
            switch (plane)
            {
                case Plane.OXY:
                    matr[x - minPoint.x, y - minPoint.y] = color;
                    break;
                case Plane.OYZ:
                    matr[y - minPoint.y, z - minPoint.z] = color;
                    break;
                case Plane.OXZ:
                    matr[x - minPoint.x, z - minPoint.z] = color;
                    break;
            }
        }

        private void CheckPoint(Point3D point)
        {
            switch (plane)
            {
                case Plane.OXY:
                    if (point.x < minPoint.x)
                        point.x = minPoint.x;
                    else if (point.x >= minPoint.x + matr.N)
                        point.x = minPoint.x + matr.N - 1;

                    if (point.y < minPoint.y)
                        point.y = minPoint.y;
                    else if (point.y >= minPoint.y + matr.M)
                        point.y = minPoint.y + matr.M - 1;
                    break;

                case Plane.OYZ:
                    if (point.y < minPoint.y)
                        point.y = minPoint.y;
                    else if (point.y >= minPoint.y + matr.N)
                        point.y = minPoint.y + matr.N - 1;

                    if (point.z < minPoint.z)
                        point.z = minPoint.z;
                    else if (point.z >= minPoint.z + matr.M)
                        point.z = minPoint.z + matr.M - 1;
                    break;
                case Plane.OXZ:
                    if (point.x < minPoint.x)
                        point.x = minPoint.x;
                    else if (point.x >= minPoint.x + matr.N)
                        point.x = minPoint.x + matr.N - 1;

                    if (point.z < minPoint.z)
                        point.z = minPoint.z;
                    else if (point.z >= minPoint.z + matr.M)
                        point.z = minPoint.z + matr.M - 1;
                    break;
            }
        }
    }

    class Point3D
    {
        public int x, y, z;
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D(Point3D point)
        {
            this.x = point.x;
            this.y = point.y;
            this.z = point.z;
        }
    }

    class Vector
    {
        public double x, y, z;
        public double length;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            FindLength();
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            FindLength();
        }

        public Vector(Point3D a, Point3D b)
        {
            x = b.x - a.x;
            y = b.y - a.y;
            z = b.z - b.z;
            FindLength();
        }

        /// <summary>
        /// Нахождение длины вектора
        /// </summary>
        private void FindLength()
        {
            length = Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Получение длины вектора
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            return length;
        }

        /// <summary>
        /// Скалярное умножение двух векторов
        /// </summary>
        public static double ScalarMultiplication(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
