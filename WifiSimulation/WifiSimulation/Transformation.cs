using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiSimulation
{
    static class Transformation
    {
        public enum Type
        {
            RotateX = 1,
            RotateY = 2,
            RotateZ = 3
        }
        static int centerX;
        static int centerY;

        public static void SetCenter(int x, int y)
        {
            centerX = x;
            centerY = y;
        }

        static void RotateX(ref double y, ref double z, double tetax)
        {
            tetax = tetax * Math.PI / 180;
            double buf = y;
            y = centerY + Math.Cos(tetax) * (y - centerY) - Math.Sin(tetax) * z;
            z = Math.Cos(tetax) * z + Math.Sin(tetax) * (buf - centerY);
        }

        static void RotateX(ref double y, ref double z, double cosTetX, double sinTetX)
        {
            double buf = y;
            y = centerY + cosTetX * (y - centerY) - sinTetX * z;
            z = cosTetX * z + sinTetX * (buf - centerY);
        }

        static void RotateY(ref double x, ref double z, double tetay)
        {
            tetay = tetay * Math.PI / 180;
            double buf = x;
            x = centerX + Math.Cos(tetay) * (x - centerX) - Math.Sin(tetay) * z;
            z = Math.Cos(tetay) * z + Math.Sin(tetay) * (buf - centerX);
        }

        static void RotateY(ref double x, ref double z, double cosTetY, double sinTetY)
        {
            double buf = x;
            x = centerX + cosTetY * (x - centerX) - sinTetY * z;
            z = cosTetY * z + sinTetY * (buf - centerX);
        }

        static void RotateZ(ref double x, ref double y, double tetaz)
        {
            tetaz = tetaz * Math.PI / 180;
            double buf = x;
            x = centerX + Math.Cos(tetaz) * (x - centerX) - Math.Sin(tetaz) * (y - centerY);
            y = centerY + Math.Cos(tetaz) * (y - centerY) + Math.Sin(tetaz) * (buf - centerX);
        }

        static void RotateZ(ref double x, ref double y, double cosTetZ, double sinTetZ)
        {
            double buf = x;
            x = centerX + cosTetZ * (x - centerX) - sinTetZ * (y - centerY);
            y = centerY + cosTetZ * (y - centerY) + sinTetZ * (buf - centerX);
        }

        /// <summary>
        /// Преобразует координаты точки в соответствии с информацией о преобразовании
        /// </summary>
        /// <param name="x">Координата x точки</param>
        /// <param name="y">Координата y точки</param>
        /// <param name="z">Координата z точки</param>
        /// <param name="type">Тип преобразования: вращение вокруг оси x, y, z</param>
        /// <param name="teta">Угол, на который происходит вращение</param>
        public static void Transform(Point3D point, Transformation.Type type, double teta)
        {
            double x_tmp = point.x;
            double y_tmp = point.y;
            double z_tmp = point.z;
            switch (type)
            {
                case Type.RotateX:
                    RotateX(ref y_tmp, ref z_tmp, teta);
                    break;
                case Type.RotateY:
                    RotateY(ref x_tmp, ref z_tmp, teta);
                    break;
                case Type.RotateZ:
                    RotateZ(ref x_tmp, ref y_tmp, teta);
                    break;
            }
            point.x = (int)x_tmp;
            point.y = (int)y_tmp;
            point.z = (int)z_tmp;
        }

        /// <summary>
        /// Преобразует координаты точки в соответствии с информацией о преобразовании
        /// </summary>
        /// <param name="x">Координата x точки</param>
        /// <param name="y">Координата y точки</param>
        /// <param name="z">Координата z точки</param>
        /// <param name="writing">Структура, содержащая тип преобразования (вращение вокруг оси x, y, z) и угол, на который происходит вращение</param>
        public static void Transform(Point3D point, WritingTransformation writing)
        {
            double x_tmp = point.x;
            double y_tmp = point.y;
            double z_tmp = point.z;
            switch (writing.type)
            {
                case Type.RotateX:
                    RotateX(ref y_tmp, ref z_tmp, writing.costeta, writing.sinteta);
                    break;
                case Type.RotateY:
                    RotateY(ref x_tmp, ref z_tmp, writing.costeta, writing.sinteta);
                    break;
                case Type.RotateZ:
                    RotateZ(ref x_tmp, ref y_tmp, writing.costeta, writing.sinteta);
                    break;
            }
            point.x = (int)x_tmp;
            point.y = (int)y_tmp;
            point.z = (int)z_tmp;
        }

        /// <summary>
        /// Выполняет последовательность преобразований координат точки из журнала
        /// </summary>
        /// <param name="x">Координата x точки</param>
        /// <param name="y">Координата y точки</param>
        /// <param name="z">Координата z точки</param>
        /// <param name="log">Журнал преобразований</param>
        public static void Transform(Point3D point, LogTransformation log)
        {
            double x_tmp = point.x;
            double y_tmp = point.y;
            double z_tmp = point.z;
            for (int i = 0; i < log.GetLength(); i++)
            {
                switch (log[i].type)
                {
                    case Type.RotateX:
                        RotateX(ref y_tmp, ref z_tmp, log[i].costeta, log[i].sinteta);
                        break;
                    case Type.RotateY:
                        RotateY(ref x_tmp, ref z_tmp, log[i].costeta, log[i].sinteta);
                        break;
                    case Type.RotateZ:
                        RotateZ(ref x_tmp, ref y_tmp, log[i].costeta, log[i].sinteta);
                        break;
                }
            }
            point.x = (int)x_tmp;
            point.y = (int)y_tmp;
            point.z = (int)z_tmp;
        }
    }

    struct WritingTransformation
    {
        public Transformation.Type type;
        public double teta;
        public double tetaRadian;
        public double costeta;
        public double sinteta;

        public WritingTransformation(Transformation.Type type, double teta)
        {
            this.type = type;
            this.teta = teta;
            this.tetaRadian = teta * Math.PI / 180;
            this.costeta = Math.Cos(this.tetaRadian);
            this.sinteta = Math.Sin(this.tetaRadian);
        }

    }

    class LogTransformation
    {
        private List<WritingTransformation> log;
        private List<WritingTransformation> reverseLog;

        public LogTransformation()
        {
            log = new List<WritingTransformation>();
            reverseLog = new List<WritingTransformation>();
        }

        public LogTransformation(LogTransformation logTransformation)
        {
            log = new List<WritingTransformation>(logTransformation.log);
            reverseLog = new List<WritingTransformation>(logTransformation.reverseLog);
        }

        private LogTransformation(List<WritingTransformation> log, List<WritingTransformation> reverseLog)
        {
            this.log = new List<WritingTransformation>(log);
            this.reverseLog = new List<WritingTransformation>(reverseLog);
        }

        public void Add(WritingTransformation writing)
        {
            log.Add(writing);
            writing.teta = -writing.teta;
            writing.tetaRadian = -writing.tetaRadian;
            writing.sinteta = -writing.sinteta;
            reverseLog.Insert(0, writing);
        }

        public void Add(LogTransformation logTransformation)
        {
            for (int i = 0; i < logTransformation.GetLength(); i++)
                this.Add(logTransformation[i]);
        }

        public int GetLength()
        {
            return log.Count;
        }

        /// <summary>
        /// Возвращает журнал преобразований, восстанавливающий исходное состояние
        /// </summary>
        public LogTransformation GetReverse()
        {
            return new LogTransformation(this.reverseLog, this.log);
        }

        public WritingTransformation this[int index]
        {
            get
            {
                return log[index];
            }
            set
            {
                log[index] = value;
            }
        }
    }
}
