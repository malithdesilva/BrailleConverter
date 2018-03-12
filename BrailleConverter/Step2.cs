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
    public partial class Step2 : Form
    {
        Rectangle rect;
        Rectangle realrectangle;
        Point mousestart;
        Point mouseend;
        bool ismousedown = false;
        Image<Gray, byte> temp1;
        Image<Gray, byte> inputImg;
        public Step2()
        {
            InitializeComponent();
        }

        public Step2(Image<Gray, byte> temp)
        {
            InitializeComponent();
            pbCrop.Image = temp.Bitmap;
            pbCrop.SizeMode = PictureBoxSizeMode.Zoom;
            inputImg = temp.CopyBlank();
            temp.CopyTo(inputImg);

        }

        private void pbCrop_MouseDown(object sender, MouseEventArgs e)
        {
            ismousedown = true;
            mousestart = e.Location;
        }

        private void pbCrop_MouseUp(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                ismousedown = false;
                Rectangle newrect = makeralrectangle();
                if (newrect != null)
                {
                    inputImg.ROI = newrect;
                    temp1 = inputImg.CopyBlank();
                    inputImg.CopyTo(temp1);
                    inputImg.ROI = Rectangle.Empty;
                    ImgBoxResult.Image = temp1;
                    pbCrop.SizeMode = PictureBoxSizeMode.Zoom;
                    

                }
            }
        }

        private void pbCrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                pbCrop.Invalidate();

                if (pbCrop.Image != null)
                {
                    lblX.Text = "X: " + e.X.ToString();
                    lblY.Text = "Y: " + e.Y.ToString();

                }
            }
        }

        private void pbCrop_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, makerectangle());
            }
        }


        //private Rectangle makerectangle()
        //{
        //    rect = new Rectangle();
        //    if (inputImg != null)
        //    {
        //        float xratio = (pictureBox1.Width / inputImg.Width);
        //        float yratio = (pictureBox1.Height / inputImg.Height);
        //        int realx = Math.Min(mouseend.X, mousestart.X);
        //        int realy = Math.Min(mouseend.Y, mousestart.Y);

        //        if (realx > 0 && realy > 0 && xratio > 0 && yratio > 0)
        //        {
        //            rect.Y = Convert.ToInt32(realy / yratio);
        //            rect.X = Convert.ToInt32(realx / xratio);
        //            rect.Width = Math.Abs(mousestart.X - mouseend.X);
        //            rect.Width = Convert.ToInt32(rect.Width / xratio);
        //            rect.Height = Math.Abs(mousestart.Y - mouseend.Y);
        //            rect.Height = Convert.ToInt32(rect.Height / yratio);
        //            return rect;
        //        }
        //        else
        //        {
        //            return rect;
        //        }

        //    }
        //    else
        //    {
        //        return rect;
        //    }


        //}

        private Rectangle makerectangle()
        {
            rect = new Rectangle();

            int realx = Math.Min(mouseend.X, mousestart.X);
            int realy = Math.Min(mouseend.Y, mousestart.Y);

            rect.Y = realy;
            rect.X = realx;
            rect.Width = Math.Abs(mousestart.X - mouseend.X);
            rect.Height = Math.Abs(mousestart.Y - mouseend.Y);

            return rect;


        }

        private Rectangle makeralrectangle()
        {
            realrectangle = new Rectangle();
            if (inputImg!=null && rect.X>0)
            {
                decimal xratio = (decimal)inputImg.Width/pbCrop.Width;
                decimal yratio = (decimal)inputImg.Height/ pbCrop.Height;
                realrectangle.X=(int)Math.Round(rect.X * xratio);
                realrectangle.Y = (int)Math.Round(rect.Y * yratio);
                realrectangle.Height = (int)Math.Round(rect.Height * yratio);
                realrectangle.Width = (int)Math.Round(rect.Width * xratio);



            }
            

            return realrectangle;


        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            Step3 nextStepConvert = new Step3(temp1);
            nextStepConvert.Show();
        }
    }
}

