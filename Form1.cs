using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using hqx;
using System.IO;


namespace PixelArtUpScaler
{
    public partial class Form1 : Form
    {
        private Bitmap OriImg;
        private Bitmap DstImg;
        private double Zoom = 1.0;
        private int ImgScale = 1;
        private InterpolationMode suavizacao = InterpolationMode.NearestNeighbor;

        public Form1()
        {
            InitializeComponent();
            OriImg = new Bitmap(2, 2);
            DstImg = new Bitmap(2, 2);
        }

        private void pictureBoxOriImg_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            g.DrawImage(OriImg, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, (int)(OriImg.Width * Zoom), (int)(OriImg.Height * Zoom)));
        }

        private void pictureBoxDstImg_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Apresenta a imagem como ela realmente é sem suavização nenhuma
            e.Graphics.InterpolationMode = suavizacao;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            g.DrawImage(DstImg, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y, (int)(DstImg.Width * Zoom / ImgScale), (int)(DstImg.Height * Zoom / ImgScale)));
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Arquivos Bitmap (*.bmp)|*.bmp|Arquivos Jpeg (*.jpg)|*.jpg|Arquivos Png (*.png)|*.png|Arquivos Gif (*.gif)|*.gif|Todos os arquivos válidos (*.bmp *.jpg *.png *.gif)|*.bmp;*.jpg;*.png;*.gif|Todos arquivos|*.*";
            openFileDialog.FilterIndex = 5;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                OriImg = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(OriImg.Width * Zoom), (int)(OriImg.Height * Zoom));
                this.Invalidate();
            }
            pictureBoxOriImg.Invalidate();
            //pictureBoxOriImg.Image = OriImg;

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
                if (DstImg != null)
                    DstImg.Save(saveFileDialog.FileName);
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            salvarToolStripMenuItem_Click(sender, e);
        }


        private void refreshImages()
        {
            pictureBoxOriImg.Invalidate();
            pictureBoxDstImg.Invalidate();
        }

        private void toolStripButtonZoomIn_Click_1(object sender, EventArgs e)
        {
            Zoom += .25;
            refreshImages();
        }

        private void toolStripButtonZoomOut_Click_1(object sender, EventArgs e)
        {
            Zoom -= .25;
            refreshImages();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            abrirToolStripMenuItem_Click(sender, e);
        }

        private void zoom50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = .50;
            refreshImages();
        }

        private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 1;
            refreshImages();
        }

        private void zoom250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 2.5;
            refreshImages();
        }

        private void zoom500ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 5;
            refreshImages();
        }

        private void zoom1000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 10;
            refreshImages();
        }

        private void scale2xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = BitmapFilter.Scale2x(DstImg);
            ImgScale = 2;
            refreshImages();
        }

        private void scale3xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = BitmapFilter.Scale3x(DstImg);
            ImgScale = 3;
            refreshImages();
        }

        private void scale4xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = BitmapFilter.Scale4x(DstImg);
            ImgScale = 4;
            refreshImages();
        }

        private void hqx2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = HqxSharp.Scale2(DstImg);
            ImgScale = 2;
            refreshImages();
        }

        private void hqx3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = HqxSharp.Scale3(DstImg);
            ImgScale = 3;
            refreshImages();
        }

        private void hqx4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = HqxSharp.Scale4(DstImg);
            ImgScale = 4;
            refreshImages();
        }

        private void desativaOpcoes()
        {
            nenhumaToolStripMenuItem.Checked = false;
            bicubicaToolStripMenuItem.Checked = false;
            bilinearToolStripMenuItem.Checked = false;
            altaToolStripMenuItem.Checked = false;
            baixaToolStripMenuItem.Checked = false;

        }
        private void nenhumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desativaOpcoes();
            nenhumaToolStripMenuItem.Checked = true;
            suavizacao = InterpolationMode.NearestNeighbor;
            refreshImages();
        }

        private void bicubicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desativaOpcoes();
            bicubicaToolStripMenuItem.Checked = true;
            suavizacao = InterpolationMode.Bicubic;
            refreshImages();
        }

        private void bilinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desativaOpcoes();
            bilinearToolStripMenuItem.Checked = true;
            suavizacao = InterpolationMode.Bilinear;
            refreshImages();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desativaOpcoes();
            altaToolStripMenuItem.Checked = true;
            suavizacao = InterpolationMode.High;
            refreshImages();
        }

        private void baixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desativaOpcoes();
            baixaToolStripMenuItem.Checked = true;
            suavizacao = InterpolationMode.Low;
            refreshImages();
        }

        private void toolStripButtonCopia_Click(object sender, EventArgs e)
        {
            OriImg = DstImg;
            ImgScale = 1;
            Zoom = 1;
            DstImg = new Bitmap(2, 2);
            refreshImages();

        }

        private void cinzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DstImg = new Bitmap(OriImg);
            DstImg = BitmapFilter.Grayscale(DstImg);
            ImgScale = 1;
            refreshImages();
        }

        private void toolStripButtonExemplo_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            switch (rnd.Next(6) + 1)
            {
                case 1: OriImg = PixelArtUpScaler.Properties.Resources.mslug2_1; break;
                case 2: OriImg = PixelArtUpScaler.Properties.Resources.megaman; break;
                case 3: OriImg = PixelArtUpScaler.Properties.Resources.sq_orig; break;
                case 4: OriImg = PixelArtUpScaler.Properties.Resources.mario_8bit; break;
                default: OriImg = PixelArtUpScaler.Properties.Resources.test_original; break;
            }
            //Utiliza sempre o Mario como exemplo
            OriImg = PixelArtUpScaler.Properties.Resources.mario_8bit;
            Zoom = 5;
            ImgScale = 1;
            DstImg = new Bitmap(2, 2);
            refreshImages();
        }

        private void vetorizarPixelArtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Vectorize grafo = new Vectorize();
            

            String c = "";
            c = grafo.ImageToGraph(OriImg);
            c = grafo.SolveAmbiguities();
            c = grafo.ReshapePixelCell();
            c = grafo.DrawNewGraphEdges();
            c = grafo.DrawNewCurves();
            //System.Diagnostics.Process.Start(grafo.ImageToGraph(OriImg));
            //System.Diagnostics.Process.Start(grafo.SolveAmbiguities());
            //System.Diagnostics.Process.Start(grafo.ReshapePixelCell());
            //System.Diagnostics.Process.Start(grafo.DrawNewGraphEdges());
            //System.Diagnostics.Process.Start(grafo.DrawNewCurves());
            System.Diagnostics.Process.Start(grafo.DrawNewImage());
            grafo = null;
        }




    }
}
