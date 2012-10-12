namespace Project2_Random
{
    partial class frmMain
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
			this.dgvProgramGen = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvTableGen = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.udNumberCount = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.dgvResult1 = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvResult2 = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvResult3 = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvManualMethod = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmbFiles = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.udManualMethod = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvProgramGen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTableGen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udNumberCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvManualMethod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udManualMethod)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvProgramGen
			// 
			this.dgvProgramGen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProgramGen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			this.dgvProgramGen.Location = new System.Drawing.Point(12, 25);
			this.dgvProgramGen.Name = "dgvProgramGen";
			this.dgvProgramGen.ReadOnly = true;
			this.dgvProgramGen.RowHeadersWidth = 100;
			this.dgvProgramGen.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvProgramGen.Size = new System.Drawing.Size(272, 278);
			this.dgvProgramGen.TabIndex = 1;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "1d";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 50;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "2d";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 50;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "3d";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 50;
			// 
			// dgvTableGen
			// 
			this.dgvTableGen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTableGen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
			this.dgvTableGen.Location = new System.Drawing.Point(290, 25);
			this.dgvTableGen.Name = "dgvTableGen";
			this.dgvTableGen.ReadOnly = true;
			this.dgvTableGen.RowHeadersVisible = false;
			this.dgvTableGen.RowHeadersWidth = 100;
			this.dgvTableGen.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvTableGen.Size = new System.Drawing.Size(215, 278);
			this.dgvTableGen.TabIndex = 2;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "1d";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 50;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "2d";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 50;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "3d";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 50;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(46, 498);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(196, 30);
			this.button1.TabIndex = 3;
			this.button1.Text = "Generate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(9, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Program method";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(298, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Table method";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(566, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Manual method";
			// 
			// udNumberCount
			// 
			this.udNumberCount.Location = new System.Drawing.Point(122, 472);
			this.udNumberCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.udNumberCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udNumberCount.Name = "udNumberCount";
			this.udNumberCount.Size = new System.Drawing.Size(120, 20);
			this.udNumberCount.TabIndex = 8;
			this.udNumberCount.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(73, 474);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Count";
			// 
			// dgvResult1
			// 
			this.dgvResult1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResult1.ColumnHeadersVisible = false;
			this.dgvResult1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
			this.dgvResult1.Location = new System.Drawing.Point(12, 309);
			this.dgvResult1.Name = "dgvResult1";
			this.dgvResult1.ReadOnly = true;
			this.dgvResult1.RowHeadersWidth = 100;
			this.dgvResult1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvResult1.Size = new System.Drawing.Size(272, 156);
			this.dgvResult1.TabIndex = 10;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "1d";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 50;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "2d";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 50;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.HeaderText = "3d";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 50;
			// 
			// dgvResult2
			// 
			this.dgvResult2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvResult2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResult2.ColumnHeadersVisible = false;
			this.dgvResult2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
			this.dgvResult2.Location = new System.Drawing.Point(290, 309);
			this.dgvResult2.Name = "dgvResult2";
			this.dgvResult2.ReadOnly = true;
			this.dgvResult2.RowHeadersVisible = false;
			this.dgvResult2.RowHeadersWidth = 100;
			this.dgvResult2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvResult2.Size = new System.Drawing.Size(215, 156);
			this.dgvResult2.TabIndex = 11;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.HeaderText = "1d";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Width = 21;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.HeaderText = "2d";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Width = 21;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.HeaderText = "3d";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.Width = 21;
			// 
			// dgvResult3
			// 
			this.dgvResult3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResult3.ColumnHeadersVisible = false;
			this.dgvResult3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11});
			this.dgvResult3.Location = new System.Drawing.Point(511, 309);
			this.dgvResult3.Name = "dgvResult3";
			this.dgvResult3.ReadOnly = true;
			this.dgvResult3.RowHeadersVisible = false;
			this.dgvResult3.RowHeadersWidth = 100;
			this.dgvResult3.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvResult3.Size = new System.Drawing.Size(215, 156);
			this.dgvResult3.TabIndex = 12;
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.HeaderText = "";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.Width = 50;
			// 
			// dgvManualMethod
			// 
			this.dgvManualMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvManualMethod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
			this.dgvManualMethod.Location = new System.Drawing.Point(511, 25);
			this.dgvManualMethod.Name = "dgvManualMethod";
			this.dgvManualMethod.RowHeadersVisible = false;
			this.dgvManualMethod.RowHeadersWidth = 100;
			this.dgvManualMethod.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvManualMethod.Size = new System.Drawing.Size(215, 278);
			this.dgvManualMethod.TabIndex = 13;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 70;
			// 
			// cmbFiles
			// 
			this.cmbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFiles.FormattingEnabled = true;
			this.cmbFiles.Location = new System.Drawing.Point(511, 471);
			this.cmbFiles.Name = "cmbFiles";
			this.cmbFiles.Size = new System.Drawing.Size(215, 21);
			this.cmbFiles.TabIndex = 18;
			this.cmbFiles.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(511, 498);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(215, 30);
			this.button3.TabIndex = 21;
			this.button3.Text = "Clear";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// udManualMethod
			// 
			this.udManualMethod.Location = new System.Drawing.Point(342, 472);
			this.udManualMethod.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.udManualMethod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udManualMethod.Name = "udManualMethod";
			this.udManualMethod.Size = new System.Drawing.Size(139, 20);
			this.udManualMethod.TabIndex = 14;
			this.udManualMethod.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.udManualMethod.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(301, 474);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Count";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(290, 498);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(215, 30);
			this.button2.TabIndex = 16;
			this.button2.Text = "Calculate";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(740, 546);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.cmbFiles);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.udManualMethod);
			this.Controls.Add(this.dgvManualMethod);
			this.Controls.Add(this.dgvResult3);
			this.Controls.Add(this.dgvResult2);
			this.Controls.Add(this.dgvResult1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.udNumberCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dgvTableGen);
			this.Controls.Add(this.dgvProgramGen);
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "Random Sequence Analysis";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvProgramGen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTableGen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udNumberCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvManualMethod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udManualMethod)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProgramGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dgvTableGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udNumberCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvResult1;
        private System.Windows.Forms.DataGridView dgvResult2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dgvResult3;
		private System.Windows.Forms.DataGridView dgvManualMethod;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.ComboBox cmbFiles;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NumericUpDown udManualMethod;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button2;
    }
}

