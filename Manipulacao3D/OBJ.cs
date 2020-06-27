using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulacao3D
{
    class OBJ
    {
        private double[,] MA;
        public List<Ponto> pontosOri, pontosAtuais;
        public List<Face> faces;

        public OBJ()
        {
            MA = new double[4,4];
            MA[0, 0] = 1;
            MA[0, 1] = 0;
            MA[0, 2] = 0;
            MA[0, 3] = 0;
            MA[1, 0] = 0;
            MA[1, 1] = 1;
            MA[1, 2] = 0;
            MA[1, 3] = 0;
            MA[2, 0] = 0;
            MA[2, 1] = 0;
            MA[2, 2] = 1;
            MA[3, 0] = 0;
            MA[3, 1] = 0;
            MA[3, 2] = 0;
            MA[3, 3] = 1;

            pontosOri = new List<Ponto>();
            pontosAtuais = new List<Ponto>();
            faces = new List<Face>();
        }

        public void setMA(double[,] ma)
        {
            MA = ma;
        }

        public double[,] getMA()
        {
            return MA;
        }
        
        public void pontoCentral(Ponto p)
        {
            int tl = pontosAtuais.Count();
            p.x = p.y = p.z = 0;

            for (int i = 0; i < tl; i++)
            {
                p.x += pontosAtuais.ElementAt<Ponto>(i).x;
                p.y += pontosAtuais.ElementAt<Ponto>(i).y;
                p.z += pontosAtuais.ElementAt<Ponto>(i).z;
            }

            p.x /= tl;
            p.y /= tl;
            p.z /= tl;
        }

        public void pontoCentralOri(Ponto p)
        {
            int tl = pontosAtuais.Count();
            p.x = p.y = p.z = 0;

            for (int i = 0; i < tl; i++)
            {
                p.x += pontosOri.ElementAt<Ponto>(i).x;
                p.y += pontosOri.ElementAt<Ponto>(i).y;
                p.z += pontosOri.ElementAt<Ponto>(i).z;
            }

            p.x /= tl;
            p.y /= tl;
            p.z /= tl;
        }

        public void calcularVetorNormalFaces()
        {
            int tam = faces.Count;
            Ponto A, B, C;
            double fator;

            for (int i = 0; i < tam; i++)
            {
                A = new Ponto(pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(1) - 1).x - pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(0) - 1).x,
                              pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(1) - 1).y - pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(0) - 1).y,
                              pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(1) - 1).z - pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(0) - 1).z);

                B = new Ponto(pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(2) - 1).x - pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(0) - 1).x,
                              pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(2) - 1).y - pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(0) - 1).y,
                              pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(2) - 1).z - pontosAtuais.ElementAt<Ponto>(faces.ElementAt<Face>(i).face.ElementAt<int>(0) - 1).z);

                C = new Ponto((A.y * B.z) - (A.z * B.y), (A.z * B.x) - (A.x * B.z), (A.x * B.y) - (A.y * B.x));
                fator = Math.Sqrt(Math.Pow(C.x, 2) + Math.Pow(C.y, 2) + Math.Pow(C.z, 2));
                C.x /= fator;
                C.y /= fator;
                C.z /= fator;

                faces.ElementAt<Face>(i).Vnormal = C;
            }
        }
    }
}
