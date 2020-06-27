using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulacao3D
{
    class Ponto
    {
        public double x, y, z;

        public Ponto()
        {
            x = y = z = 0.0;
        }

        public Ponto(Ponto p)
        {
            this.x = p.x;
            this.y = p.y;
            this.z = p.z;
        }

        public Ponto(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
