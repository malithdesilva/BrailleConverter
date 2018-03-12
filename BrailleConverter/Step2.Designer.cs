namespace BrailleConverter
{
    partial class Step2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbCrop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.ImgBoxResult = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCrop
            // 
            this.pbCrop.Location = new System.Drawing.Point(15, 44);
            this.pbCrop.Name = "pbCrop";
            this.pbCrop.Size = new System.Drawing.Size(768, 654);
            this.pbCrop.TabIndex = 0;
            this.pbCrop.TabStop = false;
            this.pbCrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCrop_Paint);
            this.pbCrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCrop_MouseDown);
            this.pbCrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCrop_MouseMove);
            this.pbCrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCrop_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Crop image using mouse drag inorder to select required part of image";
            // 
            // btnProceed
            // 
            this.btnProceed.Location = new System.Drawing.Point(763, 9);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 3;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(403, 9);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 13);
            this.lblX.TabIndex = 4;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(473, 9);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 13);
            this.lblY.TabIndex = 5;
            // 
            // ImgBoxResult
            // 
            this.ImgBoxResult.Location = new System.Drawing.Point(833, 44);
            this.ImgBoxResult.Name = "ImgBoxResult";
            this.ImgBoxResult.Size = new System.Drawing.Size(500, 654);
            this.ImgBoxResult.TabIndex = 2;
            this.ImgBoxResult.TabStop = false;
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 722);
            this.Controls.Add(this.ImgBoxResult);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCrop);
            this.Name = "Step2";
            this.Text = "Sinhala Braille Converter-Crop";
            ((System.ComponentModel.ISupportInitialize)(this.pbCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private Emgu.CV.UI.ImageBox ImgBoxResult;
    }
}