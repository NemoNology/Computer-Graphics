namespace WF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            label2 = new Label();
            inputCx = new NumericUpDown();
            label3 = new Label();
            inputCy = new NumericUpDown();
            label4 = new Label();
            inputCz = new NumericUpDown();
            label5 = new Label();
            inputCubeSize = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputCx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputCubeSize).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 288);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveBorder;
            splitContainer1.Panel2.Controls.Add(inputCz);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(inputCubeSize);
            splitContainer1.Panel2.Controls.Add(inputCy);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(inputCx);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 288;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 0;
            label1.Text = "Cube Center coordinates:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 39);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 1;
            label2.Text = "X:";
            // 
            // inputCx
            // 
            inputCx.Location = new Point(51, 37);
            inputCx.Name = "inputCx";
            inputCx.Size = new Size(83, 23);
            inputCx.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 80);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 1;
            label3.Text = "Y:";
            // 
            // inputCy
            // 
            inputCy.Location = new Point(51, 78);
            inputCy.Name = "inputCy";
            inputCy.Size = new Size(83, 23);
            inputCy.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 118);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 1;
            label4.Text = "Z:";
            // 
            // inputCz
            // 
            inputCz.Location = new Point(51, 116);
            inputCz.Name = "inputCz";
            inputCz.Size = new Size(83, 23);
            inputCz.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(152, 80);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 0;
            label5.Text = "Cube side size:";
            // 
            // inputCubeSize
            // 
            inputCubeSize.Location = new Point(245, 78);
            inputCubeSize.Name = "inputCubeSize";
            inputCubeSize.Size = new Size(83, 23);
            inputCubeSize.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inputCx).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCy).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCz).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputCubeSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private SplitContainer splitContainer1;
        private Label label1;
        private NumericUpDown inputCz;
        private Label label4;
        private NumericUpDown inputCy;
        private Label label3;
        private NumericUpDown inputCx;
        private Label label2;
        private NumericUpDown inputCubeSize;
        private Label label5;
    }
}