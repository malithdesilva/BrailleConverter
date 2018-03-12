using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrailleConverter
{
    public partial class Step1 : Form
    {
        #region

        Image<Gray, byte> temp;
        Image<Bgr, byte> inputImg;
        Image<Gray, byte> gtayImg;

        #endregion
        public Step1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputImg = new Image<Bgr, byte>(ofd.FileName);
                    gtayImg = inputImg.Convert<Gray, byte>();
                    temp = gtayImg.CopyBlank();
                    gtayImg.CopyTo(temp);
                }
               
                for (int v = 1; v < gtayImg.Height; v++)
                {
                    int w = 10;
                    int q = 12;
                    for (int u=1; u < gtayImg.Width;u++)
                    {
                        int xcenter = (gtayImg.Width) / w;
                        int ycenter = (gtayImg.Height) / q;


                        if (u==xcenter||v== ycenter)
                        {
                            gtayImg.Data[v, u, 0] = 0;
                            
                        }
                        if (u == xcenter+1 || v == ycenter+1)
                        {
                            gtayImg.Data[v, u, 0] = 0;
                           
                           
                        }
                        if (u == xcenter+2 || v == ycenter+2)
                        {
                            gtayImg.Data[v, u, 0] = 0;
                           
                        }
                        if (u == xcenter + 3 || v == ycenter + 3)
                        {
                            gtayImg.Data[v, u, 0] = 0;
                          
                        }
                        if (u == xcenter + 4 || v == ycenter +4)
                        {
                            gtayImg.Data[v, u, 0] = 0;
                          
                        }

                    }
                }
                pbRotate.Image = gtayImg.Bitmap;
                pbRotate.SizeMode = PictureBoxSizeMode.Zoom;

            }
            catch (Exception ex)
            {

            }
        }

        private void updwnrotate_ValueChanged(object sender, EventArgs e)
        {
            var dd = (double)updwnrotate.Value;
            pbRotate.Image = gtayImg.Rotate(dd, new Gray(255)).Bitmap;
            temp = temp.Rotate(dd, new Gray(255));
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {

           // pbRotate.Image = temp.Bitmap;
            Step2 st2 = new Step2(temp);
            st2.Show();
        }

        private void pbRotate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = 10;
            int cellSize = 100;
            Pen p = new Pen(Color.Yellow);

            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
    }
}
