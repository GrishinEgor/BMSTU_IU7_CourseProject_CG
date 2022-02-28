using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiSimulation
{
    class Matrix<T>
    {
        private int n;
        private int m;
        private T[,] mass;

        public int N
        {
            get { return n; }
        }

        public int M
        {
            get { return m; }
        }

        public Matrix(int n)
        {
            this.n = n;
            this.m = n;
            mass = new T[this.n, this.n];
        }

        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            mass = new T[this.n, this.m];
        }

        public T this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }
    }
}
