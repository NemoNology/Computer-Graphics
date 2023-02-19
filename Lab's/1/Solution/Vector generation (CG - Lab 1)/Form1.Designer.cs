namespace Vector_generation__CG___Lab_1_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.View1 = new System.Windows.Forms.DataGridView();
            this.p2_y = new System.Windows.Forms.NumericUpDown();
            this.p1_y = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p2_x = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.p1_x = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.View2 = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.p2_y);
            this.splitContainer1.Panel2.Controls.Add(this.p1_y);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.p2_x);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.p1_x);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDraw);
            this.splitContainer1.Size = new System.Drawing.Size(1210, 544);
            this.splitContainer1.SplitterDistance = 946;
            this.splitContainer1.TabIndex = 0;
            // 
            // View1
            // 
            this.View1.AllowUserToAddRows = false;
            this.View1.AllowUserToDeleteRows = false;
            this.View1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.View1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.View1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.View1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View1.Location = new System.Drawing.Point(0, 0);
            this.View1.MultiSelect = false;
            this.View1.Name = "View1";
            this.View1.ReadOnly = true;
            this.View1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.View1.Size = new System.Drawing.Size(469, 544);
            this.View1.TabIndex = 0;
            this.View1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellContentClick);
            this.View1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellContentDoubleClick);
            this.View1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellDoubleClick);
            this.View1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MainView_CellMouseClick);
            this.View1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKeys);
            // 
            // p2_y
            // 
            this.p2_y.Location = new System.Drawing.Point(112, 224);
            this.p2_y.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.p2_y.Name = "p2_y";
            this.p2_y.Size = new System.Drawing.Size(46, 20);
            this.p2_y.TabIndex = 2;
            this.p2_y.ValueChanged += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // p1_y
            // 
            this.p1_y.Location = new System.Drawing.Point(112, 157);
            this.p1_y.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.p1_y.Name = "p1_y";
            this.p1_y.Size = new System.Drawing.Size(46, 20);
            this.p1_y.TabIndex = 2;
            this.p1_y.ValueChanged += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y:";
            // 
            // p2_x
            // 
            this.p2_x.Location = new System.Drawing.Point(37, 224);
            this.p2_x.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.p2_x.Name = "p2_x";
            this.p2_x.Size = new System.Drawing.Size(46, 20);
            this.p2_x.TabIndex = 2;
            this.p2_x.ValueChanged += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "X:";
            // 
            // p1_x
            // 
            this.p1_x.Location = new System.Drawing.Point(37, 157);
            this.p1_x.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.p1_x.Name = "p1_x";
            this.p1_x.Size = new System.Drawing.Size(46, 20);
            this.p1_x.TabIndex = 2;
            this.p1_x.ValueChanged += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Point 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Point 1:";
            // 
            // buttonDraw
            // 
            this.buttonDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDraw.Location = new System.Drawing.Point(0, 287);
            this.buttonDraw.Margin = new System.Windows.Forms.Padding(0, 0, 0, 400);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(164, 44);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Draw vector";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.ButtonDraw_Click);
            // 
            // View2
            // 
            this.View2.AllowUserToAddRows = false;
            this.View2.AllowUserToDeleteRows = false;
            this.View2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.View2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.View2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.View2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View2.Location = new System.Drawing.Point(0, 0);
            this.View2.MultiSelect = false;
            this.View2.Name = "View2";
            this.View2.ReadOnly = true;
            this.View2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.View2.Size = new System.Drawing.Size(473, 544);
            this.View2.TabIndex = 0;
            this.View2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellContentClick);
            this.View2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellContentDoubleClick);
            this.View2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellDoubleClick);
            this.View2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MainView_CellMouseClick);
            this.View2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKeys);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.View1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.View2);
            this.splitContainer2.Size = new System.Drawing.Size(946, 544);
            this.splitContainer2.SplitterDistance = 469;
            this.splitContainer2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 544);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKeys);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.View1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View2)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown p2_y;
        private System.Windows.Forms.NumericUpDown p1_y;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown p2_x;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown p1_x;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.DataGridView View1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView View2;
    }
}

