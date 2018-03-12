namespace BrailleConverter
{
    partial class Step3
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtxtBoxResult = new System.Windows.Forms.RichTextBox();
            this.ImgBoxFinal = new Emgu.CV.UI.ImageBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBoxFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(2, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ImgBoxFinal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxtBoxResult);
            this.splitContainer1.Size = new System.Drawing.Size(980, 492);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 0;
            // 
            // rtxtBoxResult
            // 
            this.rtxtBoxResult.Location = new System.Drawing.Point(17, 14);
            this.rtxtBoxResult.Name = "rtxtBoxResult";
            this.rtxtBoxResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtxtBoxResult.Size = new System.Drawing.Size(430, 462);
            this.rtxtBoxResult.TabIndex = 2;
            this.rtxtBoxResult.Text = "";
            this.rtxtBoxResult.WordWrap = false;
            // 
            // ImgBoxFinal
            // 
            this.ImgBoxFinal.Location = new System.Drawing.Point(11, 14);
            this.ImgBoxFinal.Name = "ImgBoxFinal";
            this.ImgBoxFinal.Size = new System.Drawing.Size(456, 462);
            this.ImgBoxFinal.TabIndex = 2;
            this.ImgBoxFinal.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(870, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(22, 5);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 534);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Step3";
            this.Text = "Step3";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBoxFinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Emgu.CV.UI.ImageBox ImgBoxFinal;
        private System.Windows.Forms.RichTextBox rtxtBoxResult;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnConvert;
    }
}