namespace WF
{
    partial class PictureRotate
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
            label1 = new Label();
            label2 = new Label();
            inputRotationDegree = new NumericUpDown();
            label3 = new Label();
            b_rotate = new Button();
            b_rotate100times = new Button();
            ((System.ComponentModel.ISupportInitialize)inputRotationDegree).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(384, 55);
            label1.TabIndex = 0;
            label1.Text = "The rotation will be around the Central Point";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 74);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 1;
            label2.Text = "Rotation Angle:";
            // 
            // inputRotationDegree
            // 
            inputRotationDegree.Location = new Point(164, 72);
            inputRotationDegree.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            inputRotationDegree.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            inputRotationDegree.Name = "inputRotationDegree";
            inputRotationDegree.Size = new Size(71, 23);
            inputRotationDegree.TabIndex = 2;
            inputRotationDegree.ValueChanged += RotateDegree_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(254, 74);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 1;
            label3.Text = "degrees";
            // 
            // b_rotate
            // 
            b_rotate.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_rotate.Location = new Point(145, 115);
            b_rotate.Name = "b_rotate";
            b_rotate.Size = new Size(101, 34);
            b_rotate.TabIndex = 3;
            b_rotate.Text = "Rotate";
            b_rotate.UseVisualStyleBackColor = true;
            b_rotate.Click += ButtonRotate_Click;
            // 
            // b_rotate100times
            // 
            b_rotate100times.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            b_rotate100times.Location = new Point(285, 126);
            b_rotate100times.Name = "b_rotate100times";
            b_rotate100times.Size = new Size(87, 23);
            b_rotate100times.TabIndex = 3;
            b_rotate100times.Text = "Rotate 100 times";
            b_rotate100times.UseVisualStyleBackColor = true;
            b_rotate100times.Click += ButtonRotate100Times_Click;
            // 
            // PictureRotate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 161);
            Controls.Add(b_rotate100times);
            Controls.Add(b_rotate);
            Controls.Add(inputRotationDegree);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PictureRotate";
            Text = "PictureRotate";
            ((System.ComponentModel.ISupportInitialize)inputRotationDegree).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown inputRotationDegree;
        private Label label3;
        private Button b_rotate;
        private Button b_rotate100times;
    }
}