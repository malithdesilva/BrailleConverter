using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrailleConverter
{
    public partial class Final1 : Form
    {

        Rectangle rect;
        Point mousestart;
        Point mouseend;
        bool ismousedown = false;
        Image<Bgr, byte> inputImg;
        public Final1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image myImage = Image.FromFile(ofd.FileName);
                     inputImg = new Image<Bgr, byte>(ofd.FileName);
                    imageBox1.Image = inputImg;

                    int width = 2550;
                    int height = 3515;
                    var destRect = new Rectangle(0, 0, width, height);
                    var destImage = new Bitmap(width, height);

                    destImage.SetResolution(myImage.HorizontalResolution, myImage.VerticalResolution);

                    using (var graphics = Graphics.FromImage(destImage))
                    {
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        using (var wrapMode = new ImageAttributes())
                        {
                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                            graphics.DrawImage(myImage, destRect, 0, 0, myImage.Width, myImage.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                        Image<Bgr, byte> resizeimage = new Image<Bgr, byte>(destImage);
                        imageBox2.Image = resizeimage;
                    }
                }



            }
            catch { }
        }

        private void imageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismousedown = true;
           mousestart= e.Location;
        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                imageBox1.Invalidate();
            }
        }

        private void imageBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rect!=null)
            {
                e.Graphics.DrawRectangle(Pens.Red ,makerectangle());
            }
        }

        private Rectangle makerectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(mouseend.X, mousestart.X);
            rect.Y = Math.Min(mouseend.Y, mousestart.Y);
            rect.Width = Math.Abs(mousestart.X - mouseend.X);
            rect.Height = Math.Abs(mousestart.Y - mouseend.Y);

            return rect;
        }

        private void imageBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ismousedown==true)
            {
                mouseend = e.Location;
                ismousedown = false;
                if (rect!=null)
                {
                    inputImg.ROI = rect;
                    Image<Bgr, byte> temp = inputImg.CopyBlank();
                    inputImg.CopyTo(temp);
                    inputImg.ROI = Rectangle.Empty;
                    imageBox2.Image = temp;

                }
            }
        }
    }
}