using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulacao3D
{
    class Aplicacoes
    {
        public static void LoadPicBox(Bitmap imageBitmapSrc, int r, int g, int b)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * 3);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        *(src++) = (byte)b;
                        *(src++) = (byte)g;
                        *(src++) = (byte)r;
                    }
                    src += padding;
                }
            }
            //unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
        }

        public static void AbrirOBJ(OBJ objeto, System.IO.StreamReader sr, int cx, int cy)
        {
            int inc = 3, tam2, posF = 0, posVF = 0;
            String[] s_obj;
            String aux = sr.ReadToEnd(), s_aux;
            string[] dani = {" ","/", "//"};
            Ponto p;
            
            sr.BaseStream.Seek(0,0);
           
            while((s_aux = sr.ReadLine()) != null)
            {
                s_aux = s_aux.Replace(".",",");
                s_obj = s_aux.Split(dani, StringSplitOptions.RemoveEmptyEntries);
                if (s_obj.Length > 0)
                {
                    if (s_obj[0].Equals("v"))
                    {
                        p = new Ponto();
                        p.x = cx + Double.Parse(s_obj[1]);
                        p.y = cy + Double.Parse(s_obj[2]);
                        p.z = (cx + cy) / 2 + Double.Parse(s_obj[3]);

                        objeto.pontosOri.Add(p);
                        objeto.pontosAtuais.Add(new Ponto(p));
                    }
                    else if (s_obj[0].Equals("f"))
                    {
                        tam2 = s_obj.Length;
                        objeto.faces.Add(new Face());
                        if (tam2 % 2 == 1)
                            inc = 2;
                        else
                            inc = 3;
                        for (int i = 1; i < tam2; i += inc)
                            objeto.faces.ElementAt<Face>(posF).face.Add(int.Parse(s_obj[i]));
                        posF++;
                    }
                }
            }
        }

        public static void BresenhamReta(int x1, int y1, int x2, int y2, Bitmap imageBitmapSrc, BitmapData bitmapDataSrc)
        {
            int declive = 1;
            int dx, dy, incE, incNE, d, x, y;
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            
            int padding = bitmapDataSrc.Stride - (width * 3);

            unsafe
            {
                dx = x2 - x1;
                dy = y2 - y1;

                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    if (x2 < x1)
                    {
                        int a, b;
                        a = x1;
                        b = y1;

                        x1 = x2;
                        y1 = y2;

                        x2 = a;
                        y2 = b;

                        dx = x2 - x1;
                        dy = y2 - y1;
                    }

                    if (y2 < y1)
                    {
                        dy = -dy;
                        declive = -1;
                    }
                    //declive = (dy > 0) ? 1 : -1;

                    byte* src;

                    // Constante de Bresenham 
                    incE = 2 * dy;
                    incNE = 2 * dy - 2 * dx;
                    d = 2 * dy - dx;
                    y = y1;
                    
                    for (x = x1; x <= x2; x++)
                    {
                        src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                        if (y >= 0 && y < height && x >= 0 && x < width)
                        {
                            src += y * (width * 3 + padding) + x * 3;
                            *(src++) = (byte)0;
                            *(src++) = (byte)0;
                            *(src++) = (byte)0;
                        }

                        if (d <= 0)
                        {
                            d += incE;
                        }
                        else
                        {
                            d += incNE;
                            y += declive;
                        }
                    }
                }
                else
                {
                    if (y2 < y1)
                    {
                        int a, b;
                        a = x1;
                        b = y1;

                        x1 = x2;
                        y1 = y2;

                        x2 = a;
                        y2 = b;

                        dx = x2 - x1;
                        dy = y2 - y1;
                    }

                    if (x2 < x1)
                    {
                        dx = -dx;
                        declive = -1;
                    }

                    byte* src;

                    // Constante de Bresenham 
                    incE = 2 * dx;
                    incNE = 2 * dx - 2 * dy;
                    d = 2 * dx - dy;
                    x = x1;
                    
                    for (y = y1; y <= y2; y++)
                    {
                        src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                        if (y >= 0 && y < height && x >= 0 && x < width)
                        {
                            src += y * (width * 3 + padding) + x * 3;
                            *(src++) = (byte)0;
                            *(src++) = (byte)0;
                            *(src++) = (byte)0;
                        }

                        if (d <= 0)
                        {
                            d += incE;
                        }
                        else
                        {
                            d += incNE;
                            x += declive;
                        }
                    }
                }
            }
        }

        private static double[,] multiplicaMatriz(double[,] ma1, double[,] ma2)
        {
            double[,] mr = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        mr[i, j] += ma1[i, k] * ma2[k, j];

            return mr;
        }

        public static void transladar(double x, double y, double z, OBJ o)
        {
            double[,] maT = new double[4, 4];
            double px, py, pz;
            int tl = o.pontosOri.Count();

            maT[0, 0] = 1;
            maT[0, 1] = 0;
            maT[0, 2] = 0;
            maT[0, 3] = x;
            maT[1, 0] = 0;
            maT[1, 1] = 1;
            maT[1, 2] = 0;
            maT[1, 3] = y;
            maT[2, 0] = 0;
            maT[2, 1] = 0;
            maT[2, 2] = 1;
            maT[2, 3] = z;
            maT[3, 0] = 0;
            maT[3, 1] = 0;
            maT[3, 2] = 0;
            maT[3, 3] = 1;
            
            o.setMA(multiplicaMatriz(maT, o.getMA()));

            for (int i = 0; i < tl; i++)
            {
                px = o.pontosOri.ElementAt<Ponto>(i).x;
                py = o.pontosOri.ElementAt<Ponto>(i).y;
                pz = o.pontosOri.ElementAt<Ponto>(i).z;

                o.pontosAtuais.ElementAt<Ponto>(i).x = o.getMA()[0, 0] * px + o.getMA()[0, 1] * py + o.getMA()[0, 2] * pz + o.getMA()[0, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).y = o.getMA()[1, 0] * px + o.getMA()[1, 1] * py + o.getMA()[1, 2] * pz + o.getMA()[1, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).z = o.getMA()[2, 0] * px + o.getMA()[2, 1] * py + o.getMA()[2, 2] * pz + o.getMA()[2, 3];
            }
        }

        public static void escalar(double x, double y, double z, OBJ o)
        {
            double[,] maT = new double[4, 4];
            double px, py, pz;
            int tl = o.pontosOri.Count();

            maT[0, 0] = x;
            maT[0, 1] = 0;
            maT[0, 2] = 0;
            maT[0, 3] = 0;
            maT[1, 0] = 0;
            maT[1, 1] = y;
            maT[1, 2] = 0;
            maT[1, 3] = 0;
            maT[2, 0] = 0;
            maT[2, 1] = 0;
            maT[2, 2] = z;
            maT[2, 3] = 0;
            maT[3, 0] = 0;
            maT[3, 1] = 0;
            maT[3, 2] = 0;
            maT[3, 3] = 1;

            o.setMA(multiplicaMatriz(maT, o.getMA()));

            for (int i = 0; i < tl; i++)
            {
                px = o.pontosOri.ElementAt<Ponto>(i).x;
                py = o.pontosOri.ElementAt<Ponto>(i).y;
                pz = o.pontosOri.ElementAt<Ponto>(i).z;

                o.pontosAtuais.ElementAt<Ponto>(i).x = o.getMA()[0, 0] * px + o.getMA()[0, 1] * py + o.getMA()[0, 2] * pz + o.getMA()[0, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).y = o.getMA()[1, 0] * px + o.getMA()[1, 1] * py + o.getMA()[1, 2] * pz + o.getMA()[1, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).z = o.getMA()[2, 0] * px + o.getMA()[2, 1] * py + o.getMA()[2, 2] * pz + o.getMA()[2, 3];
            }
        }

        public static void rotacionarZ(double ang, OBJ o)
        {
            double[,] maT = new double[4, 4];
            double px, py, pz;
            int tl = o.pontosOri.Count();

            maT[0, 0] = Math.Cos(ang);
            maT[0, 1] = -Math.Sin(ang);
            maT[0, 2] = 0;
            maT[0, 3] = 0;
            maT[1, 0] = Math.Sin(ang);
            maT[1, 1] = Math.Cos(ang);
            maT[1, 2] = 0;
            maT[1, 3] = 0;
            maT[2, 0] = 0;
            maT[2, 1] = 0;
            maT[2, 2] = 1;
            maT[2, 3] = 0;
            maT[3, 0] = 0;
            maT[3, 1] = 0;
            maT[3, 2] = 0;
            maT[3, 3] = 1;

            o.setMA(multiplicaMatriz(maT, o.getMA()));

            for (int i = 0; i < tl; i++)
            {
                px = o.pontosOri.ElementAt<Ponto>(i).x;
                py = o.pontosOri.ElementAt<Ponto>(i).y;
                pz = o.pontosOri.ElementAt<Ponto>(i).z;

                o.pontosAtuais.ElementAt<Ponto>(i).x = o.getMA()[0, 0] * px + o.getMA()[0, 1] * py + o.getMA()[0, 2] * pz + o.getMA()[0, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).y = o.getMA()[1, 0] * px + o.getMA()[1, 1] * py + o.getMA()[1, 2] * pz + o.getMA()[1, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).z = o.getMA()[2, 0] * px + o.getMA()[2, 1] * py + o.getMA()[2, 2] * pz + o.getMA()[2, 3];
            }
        }

        public static void rotacionarX(double ang, OBJ o)
        {
            double[,] maT = new double[4, 4];
            double px, py, pz;
            int tl = o.pontosOri.Count();

            maT[0, 0] = 1;
            maT[0, 1] = 0;
            maT[0, 2] = 0;
            maT[0, 3] = 0;
            maT[1, 0] = 0;
            maT[1, 1] = Math.Cos(ang);
            maT[1, 2] = -Math.Sin(ang);
            maT[1, 3] = 0;
            maT[2, 0] = 0;
            maT[2, 1] = Math.Sin(ang);
            maT[2, 2] = Math.Cos(ang);
            maT[2, 3] = 0;
            maT[3, 0] = 0;
            maT[3, 1] = 0;
            maT[3, 2] = 0;
            maT[3, 3] = 1;

            o.setMA(multiplicaMatriz(maT, o.getMA()));

            for (int i = 0; i < tl; i++)
            {
                px = o.pontosOri.ElementAt<Ponto>(i).x;
                py = o.pontosOri.ElementAt<Ponto>(i).y;
                pz = o.pontosOri.ElementAt<Ponto>(i).z;

                o.pontosAtuais.ElementAt<Ponto>(i).x = o.getMA()[0, 0] * px + o.getMA()[0, 1] * py + o.getMA()[0, 2] * pz + o.getMA()[0, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).y = o.getMA()[1, 0] * px + o.getMA()[1, 1] * py + o.getMA()[1, 2] * pz + o.getMA()[1, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).z = o.getMA()[2, 0] * px + o.getMA()[2, 1] * py + o.getMA()[2, 2] * pz + o.getMA()[2, 3];
            }
        }

        public static void rotacionarY(double ang, OBJ o)
        {
            double[,] maT = new double[4, 4];
            double px, py, pz;
            int tl = o.pontosOri.Count();

            maT[0, 0] = Math.Cos(ang);
            maT[0, 1] = 0;
            maT[0, 2] = Math.Sin(ang);
            maT[0, 3] = 0;
            maT[1, 0] = 0;
            maT[1, 1] = 1;
            maT[1, 2] = 0;
            maT[1, 3] = 0;
            maT[2, 0] = -Math.Sin(ang);
            maT[2, 1] = 0;
            maT[2, 2] = Math.Cos(ang);
            maT[2, 3] = 0;
            maT[3, 0] = 0;
            maT[3, 1] = 0;
            maT[3, 2] = 0;
            maT[3, 3] = 1;

            o.setMA(multiplicaMatriz(maT, o.getMA()));

            for (int i = 0; i < tl; i++)
            {
                px = o.pontosOri.ElementAt<Ponto>(i).x;
                py = o.pontosOri.ElementAt<Ponto>(i).y;
                pz = o.pontosOri.ElementAt<Ponto>(i).z;

                o.pontosAtuais.ElementAt<Ponto>(i).x = o.getMA()[0, 0] * px + o.getMA()[0, 1] * py + o.getMA()[0, 2] * pz + o.getMA()[0, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).y = o.getMA()[1, 0] * px + o.getMA()[1, 1] * py + o.getMA()[1, 2] * pz + o.getMA()[1, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).z = o.getMA()[2, 0] * px + o.getMA()[2, 1] * py + o.getMA()[2, 2] * pz + o.getMA()[2, 3];
            }
        }

        public static void projecaoCavaleira(OBJ o)
        {
            double[,] maT = new double[4, 4];
            double px, py, pz;
            int tl = o.pontosOri.Count();

            maT[0, 0] = 1;
            maT[0, 1] = 0;
            maT[0, 2] = Math.Cos((45 * Math.PI) / 180);
            maT[0, 3] = 0;
            maT[1, 0] = 0;
            maT[1, 1] = 1;
            maT[1, 2] = Math.Sin((45 * Math.PI) / 180);
            maT[1, 3] = 0;
            maT[2, 0] = 0;
            maT[2, 1] = 0;
            maT[2, 2] = 0;
            maT[2, 3] = 0;
            maT[3, 0] = 0;
            maT[3, 1] = 0;
            maT[3, 2] = 0;
            maT[3, 3] = 1;

            o.setMA(multiplicaMatriz(maT, o.getMA()));

            for (int i = 0; i < tl; i++)
            {
                px = o.pontosOri.ElementAt<Ponto>(i).x;
                py = o.pontosOri.ElementAt<Ponto>(i).y;
                pz = o.pontosOri.ElementAt<Ponto>(i).z;

                o.pontosAtuais.ElementAt<Ponto>(i).x = o.getMA()[0, 0] * px + o.getMA()[0, 1] * py + o.getMA()[0, 2] * pz + o.getMA()[0, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).y = o.getMA()[1, 0] * px + o.getMA()[1, 1] * py + o.getMA()[1, 2] * pz + o.getMA()[1, 3];
                o.pontosAtuais.ElementAt<Ponto>(i).z = o.getMA()[2, 0] * px + o.getMA()[2, 1] * py + o.getMA()[2, 2] * pz + o.getMA()[2, 3];
            }
        }
    }
}
