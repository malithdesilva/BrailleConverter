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
    public partial class Simulate : Form
    {
        Image<Gray, byte> imggray;
        Image<Gray, byte> defaltimggray;
        Image<Bgr, byte> inputImg;
        public Simulate()
        {
            InitializeComponent();
        }

        public Simulate(Image<Bgr, byte> inputImg)
        {
            
            InitializeComponent();
            defaltimggray = inputImg.Convert<Gray, byte>();
            imageBox1.Image = defaltimggray;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputImg = new Image<Bgr, byte>(ofd.FileName);

                    //List<byte> pos1 = new List<byte>();
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

                    imggray = inputImg.Convert<Gray, byte>();
                    for (int v = 0; v < imggray.Height; v++)
                    {
                        for (int u = 0; u < imggray.Width; u++)
                        {
                            byte a = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                            if (u == 22)
                            {
                                imggray.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                            }
                            if (v == 20 || v == 40)
                            {
                                imggray.Data[v, u, 0] = 230; //Set Pixel Color | fast way
                            }
                            if (u==140||u==141||u==142)
                            {
                                imggray.Data[v, u, 0] = 255;
                            }

                            ///row 1 column 1
                            if (u <= 22 && v < 20)
                            {

                                byte val1 = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                                if (val1 == 255)
                                {
                                    meen1 = meen1 + 1;
                                    avg1 = meen1 / 440;
                                }
                                // pos1.Add(val1);
                                if (avg1 >= 0.5)
                                {
                                    //imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                    a1 = 1;
                                }

                            }

                            ///row 1, colmn 2
                            if (u > 22 && v <= 20)
                            {

                                byte val1 = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                                if (val1 == 255)
                                {
                                    meen2 = meen2 + 1;
                                    avg2 = meen2 / 440;
                                }
                                //pos1.Add(val1);
                                if (avg2 >= 0.5)
                                {
                                    //imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                    a2 = 1;
                                }

                            }

                            ///row 2 ,colmn 1
                            if (u <= 22 && v >= 20 & v < 40)
                            {

                                byte val1 = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                                if (val1 == 255)
                                {
                                    meen3 = meen3 + 1;
                                    avg3 = meen3 / 440;
                                }
                                //pos1.Add(val1);
                                if (avg3 >= 0.5)
                                {
                                    //  imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                    a3 = 1;
                                }

                            }

                            ///row 2 ,colmn 2
                            if (u > 22 && v >= 20 & v < 40)
                            {

                                byte val1 = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
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

                                byte val1 = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                                if (val1 == 255)
                                {
                                    meen5 = meen5 + 1;
                                    avg5 = meen5 / 440;
                                }
                                //pos1.Add(val1);
                                if (avg5 >= 0.5)
                                {
                                    // imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                    a5 = 1;
                                }

                            }

                            ///row 3 ,colmn 2
                            if (u > 22 && v >= 40)
                            {

                                byte val1 = imggray.Data[v, u, 0]; //Get Pixel Color | fast way
                                if (val1 == 255)
                                {
                                    meen6 = meen6 + 1;
                                    avg6 = meen6 / 440;
                                }
                                //pos1.Add(val1);
                                if (avg6 >= 0.5)
                                {
                                    // imggray.Data[v, u, 0] = 255; //Set Pixel Color | fast way
                                    a6 = 1;
                                }

                            }

                        }
                    }


                    string values = a1.ToString() + "," + a2.ToString() + "," + a3.ToString() + "," + a4.ToString() + "," + a5.ToString() + "," + a6.ToString();
                    label1.Text = values;
                    imageBox1.Image = imggray;



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var val = double.Parse(textBox1.Text);
            imageBox1.Image = imggray.Rotate(val, new Gray(255));
            matrixBox1.Matrix = imggray.Rotate(val, new Gray(255));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var val = double.Parse(textBox1.Text);

            matrixBox1.Matrix = imggray.Rotate(val, new Gray(255));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var dd = (double)numericUpDown1.Value;
            imageBox1.Image = imggray.Rotate(dd, new Gray(255));
           

         
        }
    }
}
