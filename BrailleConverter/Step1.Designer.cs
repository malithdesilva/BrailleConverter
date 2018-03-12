namespace BrailleConverter
{
    partial class Step1
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
            this.btnImport = new System.Windows.Forms.Button();
            this.pbRotate = new System.Windows.Forms.PictureBox();
            this.updwnrotate = new System.Windows.Forms.NumericUpDown();
            this.Rotation = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwnrotate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(22, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Impot Image";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pbRotate
            // 
            this.pbRotate.Location = new System.Drawing.Point(26, 61);
            this.pbRotate.Name = "pbRotate";
            this.pbRotate.Size = new System.Drawing.Size(502, 602);
            this.pbRotate.TabIndex = 1;
            this.pbRotate.TabStop = false;
            this.pbRotate.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRotate_Paint);
            // 
            // updwnrotate
            // 
            this.updwnrotate.Location = new System.Drawing.Point(278, 13);
            this.updwnrotate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.updwnrotate.Name = "updwnrotate";
            this.updwnrotate.Size = new System.Drawing.Size(120, 20);
            this.updwnrotate.TabIndex = 2;
            this.updwnrotate.ValueChanged += new System.EventHandler(this.updwnrotate_ValueChanged);
            // 
            // Rotation
            // 
            this.Rotation.AutoSize = true;
            this.Rotation.Location = new System.Drawing.Point(224, 13);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(39, 13);
            this.Rotation.TabIndex = 3;
            this.Rotation.Text = "Rotate";
            // 
            // btnProceed
            // 
            this.btnProceed.Location = new System.Drawing.Point(497, 13);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 4;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 749);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.updwnrotate);
            this.Controls.Add(this.pbRotate);
            this.Controls.Add(this.btnImport);
            this.Name = "Step1";
            this.Text = "Step1";
            ((System.ComponentModel.ISupportInitialize)(this.pbRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwnrotate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox pbRotate;
        private System.Windows.Forms.NumericUpDown updwnrotate;
        private System.Windows.Forms.Label Rotation;
        private System.Windows.Forms.Button btnProceed;
    }
}