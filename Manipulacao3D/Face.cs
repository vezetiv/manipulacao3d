using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulacao3D
{
    class Face
    {
        public List<int> face;
        public Ponto Vnormal;

        public Face()
        {
            face = new List<int>();
            Vnormal = new Ponto();
        }
    }
}
