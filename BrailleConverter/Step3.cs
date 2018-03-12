using BrailleConverter.DB;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrailleConverter
{
    public partial class Step3 : Form
    {
        #region
        string full = "";
        Image<Gray, byte> finalinput;
        Image<Gray, byte> erode2;
        List<Image<Gray, byte>> imglist = new List<Image<Gray, byte>>();
        List<string> binaris = new List<string>();
        List<string> unicodelist = new List<string>();
        BrailleEntities DB = new BrailleEntities();
        #endregion
        public Step3()
        {
            InitializeComponent();
        }

        public Step3(Image<Gray, byte> inputImg)
        {
            InitializeComponent();
            ImgBoxFinal.Image = inputImg;
            finalinput = inputImg;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                rtxtBoxResult.Text = "";
                Image<Gray, byte> erode1 = finalinput.Erode(2);
                erode2 = erode1.InRange(new Gray(70), new Gray(220));

                // cell segmentation

                int ye = 0;
                int bb = 1;

                for (int y =5; y < erode1.Height; y = y + 85)
                {

                    ye = ye + 1;
                    int xe = 0;

                    for (int x = 0; x < erode1.Width; x = x + 33 + 18)
                    {

                        Image<Gray, byte> img1 = erode2;

                        Rectangle Rect = new Rectangle();
                        Rect.X = x;
                        Rect.Y = y;
                        Rect.Width = 45;
                        Rect.Height = 60;

                        img1.ROI = Rect;
                        img1 = img1.Dilate(4);


                        int a1 = 0;
                        int a2 = 0;
                        int a3 = 0;
                        int a4 = 0;
                        int a5 = 0;
                        int a6 = 0;

                        float avg6 = 0;
                        float meen6 = 0;

                        float avg1 = 0;
                        float meen1 = 0;

                        float avg2 = 0;
                        float meen2 = 0;

                        float avg3 = 0;
                        float meen3 = 0;

                        float avg4 = 0;
                        float meen4 = 0;

                        float avg5 = 0;
                        float meen5 = 0;


                        for (int v = 0; v < img1.Height; v++)
                        {
                            for (int u = 0; u < img1.Width; u++)
                            {
                                byte a = img1.Data[v, u, 0];
                                if (u == 22)
                                {
                                    img1.Data[v, u, 0] = 230;
                                }
                                if (v == 20 || v == 40)
                                {
                                    img1.Data[v, u, 0] = 230;
                                }

                                ///row 1 column 1
                                if (u <= 22 && v < 20)
                                {

                                    byte val1 = img1.Data[v, u, 0];
                                    if (val1 == 255)
                                    {
                                        meen1 = meen1 + 1;
                                        avg1 = meen1 / 460;
                                    }

                                    if (avg1 >= 0.4)
                                    {

                                        a1 = 1;
                                    }

                                }

                                ///row 1, colmn 2
                                if (u > 22 && v < 20)
                                {

                                    byte val1 = img1.Data[v, u, 0];
                                    if (val1 == 255)
                                    {
                                        meen2 = meen2 + 1;
                                        avg2 = meen2 / 460;
                                    }

                                    if (avg2 >= 0.4)
                                    {

                                        a2 = 1;
                                    }

                                }


                                if (u <= 22 && v >= 20 & v < 40)
                                {

                                    byte val1 = img1.Data[v, u, 0];
                                    if (val1 == 255)
                                    {
                                        meen3 = meen3 + 1;
                                        avg3 = meen3 / 460;
                                    }

                                    if (avg3 >= 0.4)
                                    {

                                        a3 = 1;
                                    }

                                }

                                ///row 2 ,colmn 2
                                if (u > 22 && v >= 20 & v < 40)
                                {

                                    byte val1 = img1.Data[v, u, 0];
                                    if (val1 == 255)
                                    {
                                        meen4 = meen4 + 1;
                                        avg4 = meen4 / 440;
                                    }

                                    if (avg4 >= 0.5)
                                    {

                                        a4 = 1;
                                    }

                                }
                                ///row 3 ,colmn 1
                                if (u <= 22 && v >= 40)
                                {

                                    byte val1 = img1.Data[v, u, 0];
                                    if (val1 == 255)
                                    {
                                        meen5 = meen5 + 1;
                                        avg5 = meen5 / 460;
                                    }

                                    if (avg5 >= 0.4)
                                    {

                                        a5 = 1;
                                    }

                                }

                                ///row 3 ,colmn 2
                                if (u > 22 && v >= 40)
                                {

                                    byte val1 = img1.Data[v, u, 0];
                                    if (val1 == 255)
                                    {
                                        meen6 = meen6 + 1;
                                        avg6 = meen6 / 460;
                                    }

                                    if (avg6 >= 0.4)
                                    {

                                        a6 = 1;
                                    }

                                }

                            }
                        }

                        string values = 2 + a1.ToString() + a2.ToString() + a3.ToString() + a4.ToString() + a5.ToString() + a6.ToString();
                        int val = Convert.ToInt32(values);
                        string unicode = DB.mappings.Where(n => n.Bincode == val).Select(c => c.Unicode).FirstOrDefault();


                        bb = bb + 1;
                        xe = xe + 1;
                        binaris.Add(values);
                        if (unicode != null)
                        {
                            unicodelist.Add(unicode);
                        }
                        else
                        {
                            unicodelist.Add("null");
                        }

                        img1.Bitmap.Save(@"E:\emgu\" + xe + "," + ye + ".jpg");

                        


                    }

                }

                string sinhala;
                foreach (var item in unicodelist)
                {

                    if (item != "null")
                    {
                        int n = int.Parse(item, NumberStyles.AllowHexSpecifier);
                        sinhala = ((char)n).ToString();
                    }
                    else
                    {
                        sinhala = "\u002E";
                    }


                    full = full + sinhala;

                }
                rtxtBoxResult.Text = full;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            


        }
    }
}
