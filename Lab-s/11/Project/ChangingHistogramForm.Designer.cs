namespace Project
{
    partial class ChangingHistogramForm
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
            this.inputHistogram = new System.Windows.Forms.PictureBox();
            this.applyHistogram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // inputHistogram
            // 
            this.inputHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputHistogram.Location = new System.Drawing.Point(25, 25);
            this.inputHistogram.Name = "inputHistogram";
            this.inputHistogram.Size = new System.Drawing.Size(256, 150);
            this.inputHistogram.TabIndex = 0;
            this.inputHistogram.TabStop = false;
            this.inputHistogram.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InputHistogram_MouseMove);
            // 
            // applyHistogram
            // 
            this.applyHistogram.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.applyHistogram.Location = new System.Drawing.Point(366, 80);
            this.applyHistogram.Name = "applyHistogram";
            this.applyHistogram.Size = new System.Drawing.Size(81, 45);
            this.applyHistogram.TabIndex = 1;
            this.applyHistogram.Text = "Apply Histogram";
            this.applyHistogram.UseVisualStyleBackColor = true;
            this.applyHistogram.Click += new System.EventHandler(this.ApplyHistogram_Click);
            // 
            // ChangingHistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.applyHistogram);
            this.Controls.Add(this.inputHistogram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangingHistogramForm";
            this.Text = "Changing Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.inputHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox inputHistogram;
        private Button applyHistogram;
    }
}