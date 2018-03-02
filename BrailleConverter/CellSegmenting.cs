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

                    Image<Gray, byte> erode1 = imggray.Erode(4);
                    Image<Gray, byte> erode2 = erode1.InRange(new Gray(70), new Gray(220));

                    imageBox2.Image = erode2;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
