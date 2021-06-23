using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDI_2020
{
    public enum Canal
    {
        R,
        G,
        B
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int Max(int r, int b, int g)
        {
            int valorRetorno = r;

            if (valorRetorno < b)
                valorRetorno = b;

            if (valorRetorno < g)
                valorRetorno = g;

            return valorRetorno;
        }

        private int Min(int r, int b, int g)
        {
            int valorRetorno = r;

            if (valorRetorno > b)
                valorRetorno = b;

            if (valorRetorno > g)
                valorRetorno = g;

            return valorRetorno;
        }

        private void lightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);
                    int valorCinza = (Max(pixel.R, pixel.G, pixel.B) + Min(pixel.R, pixel.G, pixel.B)) / 2;
                    destino.SetPixel(x, y, Color.FromArgb(valorCinza, valorCinza, valorCinza));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);
                    int valorCinza = (pixel.R + pixel.G + pixel.B) / 3;
                    destino.SetPixel(x, y, Color.FromArgb(valorCinza, valorCinza, valorCinza));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void luminosityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);
                    //0,21 R + 0,72 G + 0,07 B
                    int valorCinza = (int)((0.21m * pixel.R) + (0.72m * pixel.G) + (0.07m * pixel.B));
                    destino.SetPixel(x, y, Color.FromArgb(valorCinza, valorCinza, valorCinza));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void rTrackBar_Scroll(object sender, EventArgs e)
        {
            if (contrasteRadioButton.Checked)
            {
                int R = rTrackBar.Value / 25;
                R = (R < 1) ? 1 : R;
                rLabel.Text = R.ToString();
            }
            else
            {
                rLabel.Text = rTrackBar.Value.ToString();
                Bitmap origem = ObterImagem();
                Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

                for (int x = 0; x < origem.Width; x++)
                {
                    for (int y = 0; y < origem.Height; y++)
                    {
                        int valor = rTrackBar.Value;
                        destino.SetPixel(x, y, Color.FromArgb(valor, origem.GetPixel(x, y).G, origem.GetPixel(x, y).B));
                    }
                }

                destinoPictureBox.Image = destino;
            }
        }

        private void gTrackBar_Scroll(object sender, EventArgs e)
        {
            if (contrasteRadioButton.Checked)
            {
                int G = gTrackBar.Value / 25;
                G = (G < 1) ? 1 : G;
                gLabel.Text = G.ToString();
            }
            else
            {
                gLabel.Text = gTrackBar.Value.ToString();
                Bitmap origem = ObterImagem();
                Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

                for (int x = 0; x < origem.Width; x++)
                {
                    for (int y = 0; y < origem.Height; y++)
                    {
                        int valor = gTrackBar.Value;
                        destino.SetPixel(x, y, Color.FromArgb(origem.GetPixel(x, y).R, valor, origem.GetPixel(x, y).B));
                    }
                }

                destinoPictureBox.Image = destino;
            }
        }

        private void bTrackBar_Scroll(object sender, EventArgs e)
        {
            if (contrasteRadioButton.Checked)
            {
                int B = bTrackBar.Value / 25;
                B = (B < 1) ? 1 : B;
                bLabel.Text = B.ToString();
            }
            else
            {
                bLabel.Text = bTrackBar.Value.ToString();
                Bitmap origem = ObterImagem();
                Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

                for (int x = 0; x < origem.Width; x++)
                {
                    for (int y = 0; y < origem.Height; y++)
                    {
                        int valor = gTrackBar.Value;
                        destino.SetPixel(x, y, Color.FromArgb(origem.GetPixel(x, y).R, origem.GetPixel(x, y).G, valor));
                    }
                }

                destinoPictureBox.Image = destino;
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);
            

            /*        0-----------10> X   0123456789
             0*       0001000000          0000001000 
             1*       0000101000          0001010000    
             2*       0000001000          0001000000
             3*       0000001000          0001000000
             4*       0000001000          0001000000
             */
            // y

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    destino.SetPixel(origem.Width - x - 1, y, origem.GetPixel(x, y));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);
                    destino.SetPixel(x, origem.Height - y - 1, pixel);
                }
            }

            destinoPictureBox.Image = destino;
        }

        public Bitmap ObterImagem()
        {
            Bitmap valorRetorno = null;

            if (imagemDestinoCheckBox.Checked)
                valorRetorno = (Bitmap)destinoPictureBox.Image;
            else
                valorRetorno = (Bitmap)origemPictureBox.Image;

            return valorRetorno;
        }

        private void brilhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);
            int faixaR = 0;
            int faixaG = 0;
            int faixaB = 0;
            int brilhoR = (int)rTrackBar.Value;
            int brilhoG = (int)gTrackBar.Value;
            int brilhoB = (int)bTrackBar.Value;

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    faixaR = origem.GetPixel(x, y).R + brilhoR;
                    if (faixaR > 255)
                        faixaR = 255;
                    else if (faixaR < 0)
                        faixaR = 0;

                    Color pixel = origem.GetPixel(x, y);
                    destino.SetPixel(x, origem.Height - y - 1, pixel);
                }
            }

            destinoPictureBox.Image = destino;
        }
        private void AjustarBrilhoR(int brilhoR)
        {
            AjustarBrilho(brilhoR, 0, 0);
        }

        private void AjustarBrilhoG(int brilhoG)
        {
            AjustarBrilho(0, brilhoG, 0);
        }

        private void AjustarBrilhoB(int brilhoB)
        {
            AjustarBrilho(0, 0, brilhoB);
        }

        private void AjustarBrilho(int brilhoR, int brilhoG, int brilhoB)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);
            int R = 0;
            int G = 0;
            int B = 0;

            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);

                    // Vermelho
                    R = pixel.R + brilhoR;
                    if (R > 255)
                        R = 255;
                    else if (R < 0)
                        R = 0;

                    // Verde
                    G = pixel.G + brilhoG;
                    if (G > 255)
                        G = 255;
                    else if (G < 0)
                        G = 0;

                    // Azul
                    B = pixel.B + brilhoB;
                    if (B > 255)
                        B = 255;
                    else if (B < 0)
                        B = 0;

                    Color pixelFinal = Color.FromArgb(R, G, B);
                    destino.SetPixel(x, y, pixelFinal);
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void rMenosButton_Click(object sender, EventArgs e)
        {
            AjustarBrilhoR(-10);
        }

        private void rMaisButton_Click(object sender, EventArgs e)
        {
            AjustarBrilhoR(10);
        }

        private void gMenosButton_Click(object sender, EventArgs e)
        {
            AjustarBrilhoG(-10);
        }

        private void gMaisButton_Click(object sender, EventArgs e)
        {
            AjustarBrilhoG(10);
        }

        private void bMenosButton_Click(object sender, EventArgs e)
        {
            AjustarBrilhoB(-10);
        }

        private void bMaisButton_Click(object sender, EventArgs e)
        {
            AjustarBrilhoB(10);
        }

        private void aumentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjustarBrilho(10, 10, 10);
        }

        private void diminuirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjustarBrilho(-10, -10, -10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            destinoPictureBox.Image = origemPictureBox.Image;
        }

        private void todosMaisButton_Click(object sender, EventArgs e)
        {
            AjustarBrilho(10, 10, 10);
        }

        private void todosMenosButton_Click(object sender, EventArgs e)
        {
            AjustarBrilho(-10, -10, -10);
        }

        private void aumentarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            // Pegar o valor do trackbar e normalizar que no máximo 10
            int R = rTrackBar.Value / 25;
            int G = gTrackBar.Value / 25;
            int B = bTrackBar.Value / 25;

            // Garantir que o valor a ser aplicado no contraste seja maior que 0
            R = (R < 1) ? 1 : R;
            G = (G < 1) ? 1 : G;
            B = (B < 1) ? 1 : B;

            int auxR;
            int auxG;
            int auxB;

            // Laço de varredura
            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);

                    auxR = (pixel.R * R > 255) ? 255 : pixel.R;
                    auxG = (pixel.G * G > 255) ? 255 : pixel.G;
                    auxB = (pixel.B * B > 255) ? 255 : pixel.B;

                    Color pixelFinal = Color.FromArgb(auxR, auxG, auxB);
                    destino.SetPixel(x, y, pixelFinal);
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            destinoPictureBox.Image = origemPictureBox.Image;
        }

        private void gerarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             *  1 1 1 1 2
             *  0 0 0 0 0
             *  0 1 0 1 0
             *  0 1 2 3 1
             *  1 2 3 4 5
             */
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);
            Random r = new Random();

            int x;
            int y;
            int cor;

            for (x = 0; x < origem.Width; x++)
            {
                for (y = 0; y < origem.Height; y++)
                {
                    Color pixel = origem.GetPixel(x, y);
                    destino.SetPixel(x, y, pixel);
                }
            }

            destinoPictureBox.Image = destino;

            for (int i = 0; i < ((destino.Width * destino.Height * ruidosTrackBar.Value) / 100); i++)
            {
                x = r.Next(0, destino.Width);
                y = r.Next(0, destino.Height);
                cor = r.Next(0, 255);

                destino.SetPixel(x, y, Color.FromArgb(cor, cor, cor));
            }


            destinoPictureBox.Image = destino;
        }

        private void ruidosTrackBar_Scroll(object sender, EventArgs e)
        {
            ruidoLabel.Text = ruidosTrackBar.Value.ToString();
        }

        private void halfTone1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void HalfTone1(Canal canal)
        { 
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            int aux;
            Color pixel;
            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    pixel = origem.GetPixel(x, y);
                    switch (canal)
                    {
                        case Canal.R:
                            aux = (pixel.R > 127) ? 255 : 0;
                            break;
                        case Canal.G:
                            aux = (pixel.G > 127) ? 255 : 0;
                            break;
                        case Canal.B:
                            aux = (pixel.B > 127) ? 255 : 0;
                            break;
                        default:
                            aux = 0;
                            break;
                    }

                    destino.SetPixel(x, y, Color.FromArgb(aux, aux, aux));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalfTone1(Canal.R);
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalfTone1(Canal.G);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalfTone1(Canal.B);
        }
        private void HalfTone2(Canal canal)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            int aux;
            Color pixel;
            Color pixelVizinhoEsquerda;
            Color pixelVizinhoDireita;
            Color pixelVizinhoCima;
            Color pixelVizinhoBaixo;
            for (int x = 1; x < origem.Width - 1; x+=2)
            {
                for (int y = 1; y < origem.Height - 1; y+=2)
                {
                    pixel = origem.GetPixel(x, y);
                    pixelVizinhoEsquerda = origem.GetPixel(x-1, y);
                    pixelVizinhoDireita = origem.GetPixel(x+1, y);
                    pixelVizinhoCima = origem.GetPixel(x, y-1);
                    pixelVizinhoBaixo = origem.GetPixel(x, y+1);
                    switch (canal)
                    {
                        case Canal.R:
                            aux = pixel.R + pixelVizinhoEsquerda.R + pixelVizinhoDireita.R + pixelVizinhoCima.R + pixelVizinhoBaixo.R;
                            break;
                        case Canal.G:
                            aux = pixel.G + pixelVizinhoEsquerda.G + pixelVizinhoDireita.G + pixelVizinhoCima.G + pixelVizinhoBaixo.G;
                            break;
                        case Canal.B:
                            aux = pixel.B + pixelVizinhoEsquerda.B + pixelVizinhoDireita.B + pixelVizinhoCima.B + pixelVizinhoBaixo.B;
                            break;
                        default:
                            aux = 0;
                            break;
                    }

                    aux = ((aux / 5) > 127) ? 255 : 0;
                    destino.SetPixel(x, y, Color.FromArgb(aux, aux, aux));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void rToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HalfTone2(Canal.R);
        }

        private void gToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HalfTone2(Canal.G);
        }

        private void bToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HalfTone2(Canal.B);
        }

        private void HalfTone3(Canal canal)
        {
            Bitmap origem = ObterImagem();
            Bitmap destino = new Bitmap(destinoPictureBox.Width, destinoPictureBox.Height);

            int aux;
            int erro = 0;
            Color pixel;
            for (int x = 0; x < origem.Width; x++)
            {
                for (int y = 0; y < origem.Height; y++)
                {
                    pixel = origem.GetPixel(x, y);
                    switch (canal)
                    {
                        case Canal.R:
                            aux = ((pixel.R + erro) > 127) ? 255 : 0;
                            if (aux > 0)
                                erro = 255 - (pixel.R + erro);
                            else
                                erro = pixel.R + erro;
                            break;
                        case Canal.G:
                            aux = ((pixel.G + erro) > 127) ? 255 : 0;
                            if (aux > 0)
                                erro = 255 - (pixel.G + erro);
                            else
                                erro = pixel.G + erro;
                            break;
                        case Canal.B:
                            aux = ((pixel.B + erro) > 127) ? 255 : 0;
                            if (aux > 0)
                                erro = 255 - (pixel.B + erro);
                            else
                                erro = pixel.B + erro;
                            break;
                        default:
                            aux = 0;
                            break;
                    }

                    destino.SetPixel(x, y, Color.FromArgb(aux, aux, aux));
                }
            }

            destinoPictureBox.Image = destino;
        }

        private void rToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            HalfTone3(Canal.R);
        }

        private void gToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            HalfTone3(Canal.G);
        }

        private void bToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            HalfTone3(Canal.B);
        }

        private int acertarLimites(int valor)
        {
            if (valor < 0)
            {
                valor = 0;
            }

            return valor > 255 ? 255 : valor;
        }


        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Bitmap destino = new Bitmap(destinoPictureBox.Image);
                int width = destino.Width;
                int height = destino.Height;
                int allNeighbours;
                int Neighbour1;
                int Neighbour2;
                int Neighbour3;
                int Neighbour4;
                int Neighbour5;
                int Neighbour6;
                int Neighbour7;
                int Neighbour8;
                int cpixel;

                for (int x = 0; x < width - 1; x++)
                {
                    if (x - 1 > 0 && x < width)
                    {
                        for (int y = 0; y < height - 1; y++)
                        {
                            if (y - 1 > 0 && y < height)
                            {
                                Neighbour1 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x - 1, y - 1)).R +
                                         0.59 * (destino.GetPixel(x - 1, y - 1)).G +
                                         0.11 * (destino.GetPixel(x - 1, y - 1)).B);
                                Neighbour2 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x - 1, y).R) +
                                         0.59 * (destino.GetPixel(x - 1, y).G) +
                                         0.11 * (destino.GetPixel(x - 1, y).B));
                                Neighbour3 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x - 1, y + 1).R) +
                                         0.59 * (destino.GetPixel(x - 1, y + 1).G) +
                                         0.11 * (destino.GetPixel(x - 1, y + 1).B));
                               Neighbour4 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x, y - 1).R) +
                                        0.59 * (destino.GetPixel(x, y - 1).G) +
                                         0.11 * (destino.GetPixel(x, y - 1).B));
                                Neighbour5 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x, y + 1).R) +
                                        0.59 * (destino.GetPixel(x, y + 1).G) +
                                         0.11 * (destino.GetPixel(x, y + 1).B));
                                Neighbour6 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x + 1, y - 1).R) +
                                         0.59 * (destino.GetPixel(x + 1, y - 1).G) +
                                         0.11 * (destino.GetPixel(x + 1, y - 1).B));
                                Neighbour7 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x + 1, y).R) +
                                        0.59 * (destino.GetPixel(x + 1, y).G) +
                                         0.11 * (destino.GetPixel(x + 1, y).B));
                                Neighbour8 =
                                    (int)
                                        (0.3 * (destino.GetPixel(x + 1, y + 1).R) +
                                         0.59 * (destino.GetPixel(x + 1, y + 1).G) +
                                         0.11 * (destino.GetPixel(x + 1, y + 1).B));
                                allNeighbours =
                                    (int)
                                        ((Neighbour1 + Neighbour2 + Neighbour3 + Neighbour4 + Neighbour5 + Neighbour6 + Neighbour7 + Neighbour8) * 0.125);
                                cpixel =
                                    (int)
                                        (0.3 * (destino.GetPixel(x, y).R) +
                                         0.59 * (destino.GetPixel(x, y).G) +
                                         0.11 * (destino.GetPixel(x, y).B)) + 1;

                                int R = destino.GetPixel(x, y).R;
                                int G = destino.GetPixel(x, y).G;
                                int B = destino.GetPixel(x, y).B;

                                int pixelR = acertarLimites((R * (allNeighbours / cpixel)));
                                int pixelG = acertarLimites((G * (allNeighbours / cpixel)));
                                int pixelB = acertarLimites((B * (allNeighbours / cpixel)));

                                if (Math.Abs(cpixel - allNeighbours) > 127)
                                {
                                    destino.SetPixel(x, y, Color.FromArgb(pixelR, pixelG, pixelB));
                                }
                            }
                        }
                    }
                }

                destinoPictureBox.Image = destino;
            }
        }
    }
}
