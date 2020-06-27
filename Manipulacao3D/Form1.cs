using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manipulacao3D
{
    public partial class FormOBJ : Form
    {
        private Bitmap bm, bmF, bmS, bmL;
        private OBJ objeto, obF, obS, obL, obP, Oaux;
        private int w, h, cx, cy, cont, Mx, My;
        private bool faceOculta;

        private void rbCavaleira_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCavaleira.Checked)
            {
                int tam = objeto.pontosAtuais.Count;
                int tam2 = objeto.faces.Count;
                Ponto p = new Ponto();

                obP = new OBJ();
                for (int i = 0; i < tam; i++)
                    obP.pontosAtuais.Add(objeto.pontosAtuais.ElementAt<Ponto>(i));

                for (int i = 0; i < tam2; i++)
                    obP.faces.Add(objeto.faces.ElementAt<Face>(i));
                Oaux = objeto;
                objeto = obP;
                obP.pontoCentral(p);
                Aplicacoes.transladar(-p.x, -p.y, -p.z, obP);
                Aplicacoes.projecaoCavaleira(obP);
                Aplicacoes.transladar(p.x, p.y, p.z, obP);
                desenharObjeto(bm, obP);
            }
        }

        public FormOBJ()
        {
            InitializeComponent();
        }

        private void pintar(int i, BitmapData bitmapDataSrc, Bitmap b, OBJ ob)
        {
            int tam2;
            double x1, y1, z1, x2, y2, z2, X1, Y1, Z1;

            tam2 = ob.faces.ElementAt<Face>(i).face.Count();
            X1 = ob.pontosAtuais.ElementAt<Ponto>((objeto.faces.ElementAt<Face>(i).face.ElementAt<int>(0)) - 1).x;
            Y1 = ob.pontosAtuais.ElementAt<Ponto>((objeto.faces.ElementAt<Face>(i).face.ElementAt<int>(0)) - 1).y;
            Z1 = ob.pontosAtuais.ElementAt<Ponto>((objeto.faces.ElementAt<Face>(i).face.ElementAt<int>(0)) - 1).z;

            x1 = X1;
            y1 = Y1;
            z1 = Z1;

            for (int j = 0; j < tam2; j++)
            {
                x2 = ob.pontosAtuais.ElementAt<Ponto>((objeto.faces.ElementAt<Face>(i).face.ElementAt<int>(j)) - 1).x;
                y2 = ob.pontosAtuais.ElementAt<Ponto>((objeto.faces.ElementAt<Face>(i).face.ElementAt<int>(j)) - 1).y;
                z2 = ob.pontosAtuais.ElementAt<Ponto>((objeto.faces.ElementAt<Face>(i).face.ElementAt<int>(j)) - 1).z;
                Aplicacoes.BresenhamReta((int)Math.Round(x1), (int)Math.Round(y1), (int)Math.Round(x2), (int)Math.Round(y2), b, bitmapDataSrc);
                x1 = x2;
                y1 = y2;
                z1 = z2;
            }
            Aplicacoes.BresenhamReta((int)Math.Round(x1), (int)Math.Round(y1), (int)Math.Round(X1), (int)Math.Round(Y1), b, bitmapDataSrc);
        }

        private void desenharVista(Bitmap b, OBJ ob)
        {
            int tam;

            Aplicacoes.LoadPicBox(b, 255, 255, 255);

            tam = ob.faces.Count();
            //lock dados bitmap origem
            BitmapData bitmapDataSrc = b.LockBits(new Rectangle(0, 0, 202, 190),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            for (int i = 0; i < tam; i++)
            {
                if (!faceOculta)
                    pintar(i, bitmapDataSrc, b, ob);
                else
                {
                    objeto.calcularVetorNormalFaces();
                    if (objeto.faces.ElementAt<Face>(i).Vnormal.z > 0)
                        pintar(i, bitmapDataSrc, b, ob);
                }
            }
            //unlock imagem origem
            b.UnlockBits(bitmapDataSrc);
        }

        private void desenharObjeto(Bitmap b, OBJ o)
        {
            int tam;

            Aplicacoes.LoadPicBox(b, 255, 255, 255);
            if(rbCavaleira.Checked)
            {
                /*Ponto p = new Ponto();
                objeto.pontoCentral(p);
                Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                Aplicacoes.projecaoCavaleira(o);
                Aplicacoes.transladar(p.x, p.y, p.z, objeto);*/
            }
            else if(rbGabinete.Checked)
            {

            }
            else if(rbPerspectiva.Checked)
            {

            }

            tam = o.faces.Count();
            //lock dados bitmap origem
            BitmapData bitmapDataSrc = b.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            if (!faceOculta)
                for (int i = 0; i < tam; i++)
                    pintar(i, bitmapDataSrc, b, o);
            else
            {
                o.calcularVetorNormalFaces();
                for (int i = 0; i < tam; i++)
                    if (o.faces.ElementAt<Face>(i).Vnormal.z > 0)
                        pintar(i, bitmapDataSrc, b, o);
            }
            //unlock imagem origem
            b.UnlockBits(bitmapDataSrc);
            picBoxPrincipal.Image = b;
        }

        private void FormOBJ_Load(object sender, EventArgs e)
        {
            cont = 0;
            w = picBoxPrincipal.Size.Width;
            h = picBoxPrincipal.Size.Height;
            cx = w / 2;
            cy = h / 2;
            bm = new Bitmap(w, h);
            bmF = new Bitmap(202, 190);
            bmS = new Bitmap(202, 190);
            bmL = new Bitmap(202, 190);
            objeto = new OBJ();
            Aplicacoes.LoadPicBox(bm, 255, 255, 255);
            picBoxPrincipal.Image = bm;
            faceOculta = false;
        }

        private void checkBoxVistas_CheckedChanged(object sender, EventArgs e)
        {
            //w 34%
            //h 190
            if (checkBoxVistas.Checked)
            {
                desenharVista(bmS, obS);
                picBoxSuperior.Image = bmS;
                
                desenharVista(bmF, obF);
                picBoxFrontal.Image = bmF;

                desenharVista(bmL, obL);
                picBoxLateral.Image = bmL;
            }
            else
            {
                Aplicacoes.LoadPicBox(bmS, 255, 255, 255);
                Aplicacoes.LoadPicBox(bmL, 255, 255, 255);
                Aplicacoes.LoadPicBox(bmF, 255, 255, 255);
                picBoxLateral.Image = bmL;
                picBoxFrontal.Image = bmF;
                picBoxSuperior.Image = bmS;
            }
        }

        private void checkBoxFaces_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFaces.Checked)
                faceOculta = true;
            else
                faceOculta = false;

            desenharObjeto(bm, objeto);
        }

        private void picBoxPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Right:
                    cont++;
                    if (cont > 3)
                    {
                        Ponto p = new Ponto();
                        objeto.pontoCentral(p);
                        Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                        Aplicacoes.rotacionarZ(((e.Y - My) * 0.1) * (Math.PI / 180), objeto);
                        Aplicacoes.transladar(p.x, p.y, p.z, objeto);
                        
                        desenharObjeto(bm, objeto);
                        cont = 0;
                    }
                    break;

                case MouseButtons.Left:
                    cont++;
                    if (cont > 3)
                    {
                        Ponto p = new Ponto();
                        objeto.pontoCentral(p);

                        Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                        Aplicacoes.rotacionarX(((e.Y - My) * 0.1) * (Math.PI / 180), objeto);
                        Aplicacoes.rotacionarY(((e.X - Mx) * 0.1) * (Math.PI / 180), objeto);
                        Aplicacoes.transladar(p.x, p.y, p.z, objeto);
                        desenharObjeto(bm, objeto);

                        if(checkBoxVistas.Checked)
                        {
                            obS.pontoCentral(p);
                            Aplicacoes.transladar(-p.x, -p.y, -p.z, obS);
                            Aplicacoes.rotacionarZ(((e.Y - My) * 0.1) * (Math.PI / 180), obS);
                            Aplicacoes.transladar(p.x, p.y, p.z, obS);
                            desenharVista(bmS, obS);
                            picBoxSuperior.Image = bmS;

                            obF.pontoCentral(p);
                            Aplicacoes.transladar(-p.x, -p.y, -p.z, obF);
                            Aplicacoes.rotacionarY(((e.X - Mx) * 0.1) * (Math.PI / 180), obF);
                            Aplicacoes.transladar(p.x, p.y, p.z, obF);
                            desenharVista(bmF, obF);
                            picBoxFrontal.Image = bmF;

                            obL.pontoCentral(p);
                            Aplicacoes.transladar(-p.x, -p.y, -p.z, obL);
                            Aplicacoes.rotacionarX(((e.Y - My) * 0.1) * (Math.PI / 180), obL);
                            Aplicacoes.transladar(p.x, p.y, p.z, obL);
                            desenharVista(bmL, obL);
                            picBoxLateral.Image = bmL;
                        }
                        cont = 0;
                    }
                    break;
            }
        }

        private void picBoxPrincipal_MouseClick_1(object sender, MouseEventArgs e)
        {
            Ponto p = new Ponto();
            Mx = e.X;
            My = e.Y;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if(ModifierKeys == Keys.Control)
                    {
                        objeto.pontoCentral(p);
                        Aplicacoes.transladar(e.X - p.x, e.Y - p.y, 0, objeto);
                    }
                    desenharObjeto(bm, objeto);
                    break;
            }
        }

        private void picBoxPrincial_MouseWheel(object sender, MouseEventArgs e)
        {
            Ponto p = new Ponto();
            objeto.pontoCentral(p);

            if (e.Delta > 0)
            {
                Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                Aplicacoes.escalar(1.1, 1.1, 1.1, objeto);
                Aplicacoes.transladar(p.x, p.y, p.z, objeto);
                desenharObjeto(bm, objeto);

                if (checkBoxVistas.Checked)
                {
                    obS.pontoCentral(p);
                    Aplicacoes.transladar(-p.x, -p.y, -p.z, obS);
                    Aplicacoes.escalar(1.1, 1.1, 1.1, obS);
                    Aplicacoes.transladar(p.x, p.y, p.z, obS);
                    desenharVista(bmS, obS);
                    picBoxSuperior.Image = bmS;

                    obF.pontoCentral(p);
                    Aplicacoes.transladar(-p.x, -p.y, -p.z, obF);
                    Aplicacoes.escalar(1.1, 1.1, 1.1, obF);
                    Aplicacoes.transladar(p.x, p.y, p.z, obF);
                    desenharVista(bmF, obF);
                    picBoxFrontal.Image = bmF;

                    obL.pontoCentral(p);
                    Aplicacoes.transladar(-p.x, -p.y, -p.z, obL);
                    Aplicacoes.escalar(1.1, 1.1, 1.1, obL);
                    Aplicacoes.transladar(p.x, p.y, p.z, obL);
                    desenharVista(bmL, obL);
                    picBoxLateral.Image = bmL;
                }
            }
            else
            {
                Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                Aplicacoes.escalar(0.9, 0.9, 0.9, objeto);
                Aplicacoes.transladar(p.x, p.y, p.z, objeto);
                desenharObjeto(bm, objeto);

                if (checkBoxVistas.Checked)
                {
                    obS.pontoCentral(p);
                    Aplicacoes.transladar(-p.x, -p.y, -p.z, obS);
                    Aplicacoes.escalar(0.9, 0.9, 0.9, obS);
                    Aplicacoes.transladar(p.x, p.y, p.z, obS);
                    desenharVista(bmS, obS);
                    picBoxSuperior.Image = bmS;

                    obF.pontoCentral(p);
                    Aplicacoes.transladar(-p.x, -p.y, -p.z, obF);
                    Aplicacoes.escalar(0.9, 0.9, 0.9, obF);
                    Aplicacoes.transladar(p.x, p.y, p.z, obF);
                    desenharVista(bmF, obF);
                    picBoxFrontal.Image = bmF;

                    obL.pontoCentral(p);
                    Aplicacoes.transladar(-p.x, -p.y, -p.z, obL);
                    Aplicacoes.escalar(0.9, 0.9, 0.9, obL);
                    Aplicacoes.transladar(p.x, p.y, p.z, obL);
                    desenharVista(bmL, obL);
                    picBoxLateral.Image = bmL;
                }
            }
        }

        private void btnAbrirOBJ_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Object (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picBoxPrincipal.Image = bm;
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);
                objeto = new OBJ();
                Aplicacoes.AbrirOBJ(objeto,sr, cx, cy);
                sr.Close();

                Ponto p = new Ponto();
                objeto.pontoCentral(p);
                Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                Aplicacoes.rotacionarZ(Math.PI, objeto);
                Aplicacoes.transladar(p.x, p.y, p.z, objeto);
                
                desenharObjeto(bm, objeto);

                int tam;
                
                Aplicacoes.transladar(-p.x, -p.y, -p.z, objeto);
                Aplicacoes.escalar(0.66, 0.66, 0.66, objeto);
                Aplicacoes.transladar(p.x - cx + 101, p.y - cy + 95, p.z - (cx + cy) / 2 + (101 + 95) / 2, objeto);
                obF = new OBJ();
                obS = new OBJ();
                obL = new OBJ();
                obF.faces = obS.faces = obL.faces = objeto.faces;
                tam = objeto.pontosOri.Count;
                for (int i = 0; i < tam; i++)
                {
                    obF.pontosOri.Add(new Ponto(objeto.pontosAtuais.ElementAt<Ponto>(i)));
                    obS.pontosOri.Add(new Ponto(objeto.pontosAtuais.ElementAt<Ponto>(i)));
                    obL.pontosOri.Add(new Ponto(objeto.pontosAtuais.ElementAt<Ponto>(i)));

                    obF.pontosAtuais.Add(new Ponto(objeto.pontosAtuais.ElementAt<Ponto>(i)));
                    obS.pontosAtuais.Add(new Ponto(objeto.pontosAtuais.ElementAt<Ponto>(i)));
                    obL.pontosAtuais.Add(new Ponto(objeto.pontosAtuais.ElementAt<Ponto>(i)));
                }
                Aplicacoes.transladar(-(p.x - cx + 101), -(p.y - cy + 95), -(p.z - (cx + cy) / 2 + (101 + 95) / 2), objeto);
                Aplicacoes.escalar(1.34, 1.34, 1.34, objeto);
                Aplicacoes.transladar(p.x, p.y, p.z, objeto);

                obS.pontoCentralOri(p);
                Aplicacoes.transladar(-p.x, -p.y, -p.z, obS);
                Aplicacoes.rotacionarX((90 * Math.PI) / 180, obS);
                Aplicacoes.transladar(p.x, p.y, p.z, obS);
                obL.pontoCentralOri(p);
                Aplicacoes.transladar(-p.x, -p.y, -p.z, obL);
                Aplicacoes.rotacionarY((90 * Math.PI) / 180, obL);
                Aplicacoes.transladar(p.x, p.y, p.z, obL);
            }
        }
    }
}
