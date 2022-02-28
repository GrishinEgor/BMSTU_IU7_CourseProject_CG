using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WifiSimulation
{
    class LightSource
    {
        public Color color;
        public double tetax, tetay, tetaz;
        public Vector direction;


        public LightSource(Color color, double tetax, double tetay, double tetaz, Vector direction)
        {
            this.direction = direction;
            this.color = color;
            this.tetax = tetax;
            this.tetay = tetay;
            this.tetaz = tetaz;
        }
    }
}
