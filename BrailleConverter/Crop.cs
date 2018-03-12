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
using Emgu.CV;
namespace BrailleConverter
{
    public partial class Crop : Form
    {
        Rectangle rect;
        Point mousestart;
        Point mouseend;
        bool ismousedown = false;
        Image<Bgr, byte> temp;
        Image<Bgr, byte> inputImg;
        public Crop()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image myImage = Image.FromFile(ofd.FileName);
                inputImg = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = inputImg.Bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                ismousedown = false;
                if (rect != null)
                {
                    inputImg.ROI = rect;
                    temp = inputImg.CopyBlank();
                    inputImg.CopyTo(temp);
                    temp.Bitmap.Save(@"E:\emgu\wewe.jpg");
                    inputImg.ROI = Rectangle.Empty;
                    pictureBox1.Image = inputImg.Bitmap;
                    // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageBox1.Image = temp;
                 //   imageBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                pictureBox1.Invalidate();

                if (pictureBox1.Image != null)
                {
                    label2.Text = "X: " + e.X.ToString();
                    label4.Text = "Y: " + e.Y.ToString();

                    //if (imageBox1.Image != null)
                    //{
                    //    label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
                    //}
                    //else
                    //{
                    //    label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
                    //}
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismousedown = true;
            mousestart = e.Location;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, makerectangle());
            }
        }

        private Rectangle makerectangle()
        {
            rect = new Rectangle();
            if (inputImg!=null)
            {
                float xratio = (pictureBox1.Width / inputImg.Width);
                float yratio = (pictureBox1.Height / inputImg.Height);
                int realx = Math.Min(mouseend.X, mousestart.X);
                int realy = Math.Min(mouseend.Y, mousestart.Y);
                
                if (realx>0 && realy>0&& xratio>0&&yratio>0)
                {
                    rect.Y = Convert.ToInt32(realy / yratio);
                    rect.X = Convert.ToInt32(realx / xratio);
                    rect.Width = Math.Abs(mousestart.X - mouseend.X);
                    rect.Width = Convert.ToInt32(rect.Width / xratio);
                    rect.Height = Math.Abs(mousestart.Y - mouseend.Y);
                    rect.Height = Convert.ToInt32(rect.Height / yratio);
                    return rect;
                }
                else
                {
                    return rect;
                }
              
                
               
               
               
            }
            else
            {
                return rect; 
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simulate simulate = new Simulate(temp);
            simulate.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
           //if (imageBox1.Image != null)
           //{
           //    label1.Text = "X: " + e.X.ToString();
           //    label2.Text = "Y: " + e.Y.ToString();

           //    if (imageBox1.Image != null)
           //    {
           //        label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
           //    }
           //    else
           //    {
           //        label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
           //    }
           //}
        }

        private void imageBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ismousedown = true;
            mousestart = e.Location;
        }

        private void imageBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                ismousedown = false;
                if (rect != null)
                {
                    inputImg.ROI = rect;
                    temp = inputImg.CopyBlank();
                    inputImg.CopyTo(temp);
                    temp.Bitmap.Save(@"E:\emgu\wewe.jpg");
                    inputImg.ROI = Rectangle.Empty;
                    pictureBox1.Image = inputImg.Bitmap;
                    // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                   // imageBox1.Image = temp;
                    //   imageBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
        }

        private void imageBox2_MouseMove(object sender, MouseEventArgs e)
        {
            //if (ismousedown == true)
            //{
            //    mouseend = e.Location;
            //    imageBox2.Invalidate();

            //    if (imageBox2.Image != null)
            //    {
            //        label2.Text = "X: " + e.X.ToString();
            //        label4.Text = "Y: " + e.Y.ToString();

            //        //if (imageBox1.Image != null)
            //        //{
            //        //    label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
            //        //}
            //        //else
            //        //{
            //        //    label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
            //        //}
            //    }
            //}
        }

        private void imageBox2_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, makerectangle());
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                ismousedown = false;
                if (rect != null)
                {
                    inputImg.ROI = rect;
                    temp = inputImg.CopyBlank();
                    inputImg.CopyTo(temp);
                    temp.Bitmap.Save(@"E:\emgu\wewe.jpg");
                    inputImg.ROI = Rectangle.Empty;
                    pictureBox1.Image = inputImg.Bitmap;
                    // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageBox1.Image = temp;
                    //   imageBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (ismousedown == true)
            {
                mouseend = e.Location;
                pictureBox1.Invalidate();

                if (pictureBox1.Image != null)
                {
                    label2.Text = "X: " + e.X.ToString();
                    label4.Text = "Y: " + e.Y.ToString();

                    //if (imageBox1.Image != null)
                    //{
                    //    label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
                    //}
                    //else
                    //{
                    //    label3.Text = "Value: " + inputImg[e.Y, e.X].ToString();
                    //}
                }
            }

        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ismousedown = true;
            mousestart = e.Location;
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, makerectangle());
            }
        }
    }
}
