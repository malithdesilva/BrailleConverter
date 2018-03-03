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
    public partial class CellSegmenting : Form
    {
        public CellSegmenting()
        {
            InitializeComponent();
        }
        Image<Gray, byte> erode2;
        List<Image<Gray, byte>> imglist = new List<Image<Gray, byte>>();
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> inputImg = new Image<Bgr, byte>(ofd.FileName);
                    imageBox1.Image = inputImg;

                    Image<Gray, byte> imggray = inputImg.Convert<Gray, byte>();

                    Image<Gray, byte> erode1 = imggray.Erode(2);
                    erode2 = erode1.InRange(new Gray(70), new Gray(220));
                    int x = 20;
                    int z = 20;
                    for (int v = 20; v < inputImg.Height; v = v + 85)
                    {
                        x = x + 85;
                        z = z + 60;
                        for (int u = 143; u < inputImg.Width; u=u+50)
                        {
                            int p = u + 42;
                            int q = u + 51;
                            byte a = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                            if (u == 145 || u == p || u == q)
                            {
                                erode2.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                            }
                            if (v == z || v == 20 || v == x)
                            {
                                erode2.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                            }
                        }
                    }

                    imageBox2.Image = erode2;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void sgmntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int xe = 0;
            int ye = 0;
            for (int y = 20; y < 2311; y = y + 85)
            {
                ye = ye + 1;
                //for (int x = 143; x < 1700; x = x+44+6)
                for (int x = 143; x < 1700; x = x + 33 + 18)
                {

                    Image<Gray, byte> img1 = erode2;
                    Rectangle Rect = new Rectangle();
                    Rect.X = x;
                    Rect.Y = y;
                    Rect.Width = 45;
                    Rect.Height = 60;
                    img1.ROI = Rect;
                    img1 = img1.Dilate(3);
                    imglist.Add(img1);
                    xe = xe + 1;

                    img1.Bitmap.Save(@"E:\emgu\MyPic" + xe + "," + ye + ".jpg");

                }
            }
           
            //foreach (var oneimage in imglist)
            //{
            //    Double Red_avg = 0.0;
            //    for (int j = 1; j < oneimage.Cols; j++)
            //    {
            //        for (int i = 1; i < oneimage.Rows; i++)
            //        {
            //            Red_avg += oneimage.Data[i, j, 0];
            //        }
            //    }
            //    oneimage.Bitmap.Save(@"E:\emgu\MyPic" + xe + "," + ye + ".txt");
            //}
        }

        private void simulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulate simul = new Simulate();
            simul.Show();
        }
    }
}
