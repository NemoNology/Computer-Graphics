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
            inputHistogram = new PictureBox();
            applyHistogram = new Button();
            ((System.ComponentModel.ISupportInitialize)inputHistogram).BeginInit();
            SuspendLayout();
            // 
            // inputHistogram
            // 
            inputHistogram.BorderStyle = BorderStyle.FixedSingle;
            inputHistogram.Location = new Point(25, 25);
            inputHistogram.Name = "inputHistogram";
            inputHistogram.Size = new Size(300, 150);
            inputHistogram.TabIndex = 0;
            inputHistogram.TabStop = false;
            inputHistogram.MouseMove += InputHistogram_MouseMove;
            // 
            // applyHistogram
            // 
            applyHistogram.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            applyHistogram.Location = new Point(366, 80);
            applyHistogram.Name = "applyHistogram";
            applyHistogram.Size = new Size(81, 45);
            applyHistogram.TabIndex = 1;
            applyHistogram.Text = "Apply Histogram";
            applyHistogram.UseVisualStyleBackColor = true;
            applyHistogram.Click += ApplyHistogram_Click;
            // 
            // ChangingHistogramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 211);
            Controls.Add(applyHistogram);
            Controls.Add(inputHistogram);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ChangingHistogramForm";
            Text = "Changing Histogram";
            ((System.ComponentModel.ISupportInitialize)inputHistogram).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox inputHistogram;
        private Button applyHistogram;
    }
}