using BrailleConverter.DB;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrailleConverter
{
    public partial class Overall : Form
    {
       
        public Overall()
        {
            InitializeComponent();
        }
        string full = "";
        Image<Gray, byte> erode2;
        List<Image<Gray, byte>> imglist = new List<Image<Gray, byte>>();
        List<string> binaris = new List<string>();
        List<string> unicodelist = new List<string>();

        BrailleEntities DB = new BrailleEntities();
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //full = null;
            //erode2 = null;
            //imglist = null;
            //binaris = null;
            //unicodelist = null;
            //label1.Text = "";
            //textBox1.Text = "";
            richTextBox1.Text = "";
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    full = "";
                    Image<Bgr, byte> inputImg = new Image<Bgr, byte>(ofd.FileName);
                    imageBox1.Image = inputImg;

                    Image<Gray, byte> imggray = inputImg.Convert<Gray, byte>();

                    Image<Gray, byte> erode1 = imggray.Erode(2);
                    erode2 = erode1.InRange(new Gray(70), new Gray(220));

                    //int x = 20;
                    //int z = 20;
                    //for (int v = 20; v < inputImg.Height; v = v + 85)
                    //{
                    //    x = x + 85;
                    //    z = z + 60;
                    //    for (int u = 143; u < inputImg.Width; u = u + 50)
                    //    {
                    //        int p = u + 42;
                    //        int q = u + 51;
                    //        byte a = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                    //        if (u == 145 || u == p || u == q)
                    //        {
                    //            erode2.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                    //        }
                    //        if (v == z || v == 20 || v == x)
                    //        {
                    //            erode2.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                    //        }
                    //    }
                    //}

                    int bb = 1;
                    int ye = 0;
                    /* for (int y = 20; y < 2311; y = y + 85)*/
                    for (int y = 20; y < inputImg.Height; y = y + 85)
                    {
                        int xe = 0;
                        ye = ye + 1;
                        //for (int x = 143; x < 1700; x = x+44+6)
                        for (int x = 143; x <inputImg.Width; x = x + 33 + 18)
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
                                    byte a = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                    if (u == 22)
                                    {
                                        img1.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                                    }
                                    if (v == 20 || v == 40)
                                    {
                                        img1.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                                    }

                                    ///row 1 column 1
                                    if (u <= 22 && v < 20)
                                    {

                                        byte val1 = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                        if (val1 == 255)
                                        {
                                            meen1 = meen1 + 1;
                                            avg1 = meen1 / 460;
                                        }
                                        // pos1.Add(val1);
                                        if (avg1 >= 0.4)
                                        {
                                            //imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                            a1 = 1;
                                        }

                                    }

                                    ///row 1, colmn 2
                                    if (u > 22 && v < 20)
                                    {

                                        byte val1 = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                        if (val1 == 255)
                                        {
                                            meen2 = meen2 + 1;
                                            avg2 = meen2 / 460;
                                        }
                                        //pos1.Add(val1);
                                        if (avg2 >= 0.4)
                                        {
                                            //imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                            a2 = 1;
                                        }

                                    }

                                    ///row 2 ,colmn 1
                                    if (u <= 22 && v >= 20 & v < 40)
                                    {

                                        byte val1 = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                        if (val1 == 255)
                                        {
                                            meen3 = meen3 + 1;
                                            avg3 = meen3 / 460;
                                        }
                                        //pos1.Add(val1);
                                        if (avg3 >= 0.4)
                                        {
                                            //  imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                            a3 = 1;
                                        }

                                    }

                                    ///row 2 ,colmn 2
                                    if (u > 22 && v >= 20 & v < 40)
                                    {

                                        byte val1 = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                        if (val1 == 255)
                                        {
                                            meen4 = meen4 + 1;
                                            avg4 = meen4 / 440;
                                        }
                                        //pos1.Add(val1);
                                        if (avg4 >= 0.5)
                                        {
                                            // imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                            a4 = 1;
                                        }

                                    }
                                    ///row 3 ,colmn 1
                                    if (u <= 22 && v >= 40)
                                    {

                                        byte val1 = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                        if (val1 == 255)
                                        {
                                            meen5 = meen5 + 1;
                                            avg5 = meen5 / 460;
                                        }
                                        //pos1.Add(val1);
                                        if (avg5 >= 0.4)
                                        {
                                            // imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                            a5 = 1;
                                        }

                                    }

                                    ///row 3 ,colmn 2
                                    if (u > 22 && v >= 40)
                                    {

                                        byte val1 = img1.Data[v, u, 0]; //Get Pixel Color | fast way
                                        if (val1 == 255)
                                        {
                                            meen6 = meen6 + 1;
                                            avg6 = meen6 / 460;
                                        }
                                        //pos1.Add(val1);
                                        if (avg6 >= 0.4)
                                        {
                                            // imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                            a6 = 1;
                                        }

                                    }

                                }
                            }



                            string values = 2 + a1.ToString() + a2.ToString() + a3.ToString() + a4.ToString() + a5.ToString() + a6.ToString();
                            int val = Convert.ToInt32(values);
                            string unicode = DB.mappings.Where(n => n.Bincode == val).Select(c=>c.Unicode).FirstOrDefault();

                           
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

                            img1.Bitmap.Save(@"E:\emgu\MyPic" + xe + "," + ye + ".jpg");

                        }
                    }

                    string path = @"E:\emgu12.txt";
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        using (TextWriter tw = new StreamWriter(fs))
                        {
                            foreach (var item in binaris)
                            {
                                tw.WriteLine(item);
                            }

                        }
                    }
                    string sinhala;
                    foreach (var item in unicodelist)
                    {
                       
                        if (item!="null")
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
                    label1.Text =  full;
                    textBox1.Text = full;
                    richTextBox1.Text = full;
                    label2.Text = "\u0D9A";
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Overall_Load(object sender, EventArgs e)
        {
            //string io = "\u0D85 \u0D86";
            //label1.Text = io;
            label2.Text = "\u0D9A";
            richTextBox1.Text = "\x0D9A";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            show form = new show(full);
            form.Show();
        }
    }
}
