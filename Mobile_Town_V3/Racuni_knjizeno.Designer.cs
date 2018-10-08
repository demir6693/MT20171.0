namespace Mobile_Town_V3
{
    partial class Racuni_knjizeno
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mobile_TownDataSet1 = new Mobile_Town_V3.Mobile_TownDataSet1();
            this.racuniknjizenoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.racuni_knjizenoTableAdapter = new Mobile_Town_V3.Mobile_TownDataSet1TableAdapters.Racuni_knjizenoTableAdapter();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.idracunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artikliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumizdavanjaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iznosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iznosnabavnaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vidi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.izbrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobile_TownDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racuniknjizenoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 29);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 580);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(895, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 580);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 599);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(885, 10);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(17, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(872, 557);
            this.panel5.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idracunaDataGridViewTextBoxColumn,
            this.artikliDataGridViewTextBoxColumn,
            this.datumizdavanjaDataGridViewTextBoxColumn,
            this.iznosDataGridViewTextBoxColumn,
            this.iznosnabavnaDataGridViewTextBoxColumn,
            this.vidi,
            this.izbrisi});
            this.dataGridView1.DataSource = this.racuniknjizenoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(866, 551);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // mobile_TownDataSet1
            // 
            this.mobile_TownDataSet1.DataSetName = "Mobile_TownDataSet1";
            this.mobile_TownDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // racuniknjizenoBindingSource
            // 
            this.racuniknjizenoBindingSource.DataMember = "Racuni_knjizeno";
            this.racuniknjizenoBindingSource.DataSource = this.mobile_TownDataSet1;
            // 
            // racuni_knjizenoTableAdapter
            // 
            this.racuni_knjizenoTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Mobile_Town_V3.Properties.Resources.if_Retract_20018861;
            this.pictureBox2.Location = new System.Drawing.Point(850, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Mobile_Town_V3.Properties.Resources.if_Cross_2001870__1_;
            this.pictureBox1.Location = new System.Drawing.Point(879, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // idracunaDataGridViewTextBoxColumn
            // 
            this.idracunaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idracunaDataGridViewTextBoxColumn.DataPropertyName = "id_racuna";
            this.idracunaDataGridViewTextBoxColumn.HeaderText = "id_racuna";
            this.idracunaDataGridViewTextBoxColumn.Name = "idracunaDataGridViewTextBoxColumn";
            this.idracunaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // artikliDataGridViewTextBoxColumn
            // 
            this.artikliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.artikliDataGridViewTextBoxColumn.DataPropertyName = "artikli";
            this.artikliDataGridViewTextBoxColumn.HeaderText = "artikli";
            this.artikliDataGridViewTextBoxColumn.Name = "artikliDataGridViewTextBoxColumn";
            // 
            // datumizdavanjaDataGridViewTextBoxColumn
            // 
            this.datumizdavanjaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datumizdavanjaDataGridViewTextBoxColumn.DataPropertyName = "datum_izdavanja";
            this.datumizdavanjaDataGridViewTextBoxColumn.HeaderText = "datum_izdavanja";
            this.datumizdavanjaDataGridViewTextBoxColumn.Name = "datumizdavanjaDataGridViewTextBoxColumn";
            // 
            // iznosDataGridViewTextBoxColumn
            // 
            this.iznosDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iznosDataGridViewTextBoxColumn.DataPropertyName = "iznos";
            this.iznosDataGridViewTextBoxColumn.HeaderText = "iznos";
            this.iznosDataGridViewTextBoxColumn.Name = "iznosDataGridViewTextBoxColumn";
            // 
            // iznosnabavnaDataGridViewTextBoxColumn
            // 
            this.iznosnabavnaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iznosnabavnaDataGridViewTextBoxColumn.DataPropertyName = "iznos_nabavna";
            this.iznosnabavnaDataGridViewTextBoxColumn.HeaderText = "iznos_nabavna";
            this.iznosnabavnaDataGridViewTextBoxColumn.Name = "iznosnabavnaDataGridViewTextBoxColumn";
            // 
            // vidi
            // 
            this.vidi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vidi.DataPropertyName = "id_racuna";
            this.vidi.HeaderText = "Vidi";
            this.vidi.Name = "vidi";
            this.vidi.ReadOnly = true;
            this.vidi.Text = "Vidi";
            this.vidi.UseColumnTextForButtonValue = true;
            // 
            // izbrisi
            // 
            this.izbrisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.izbrisi.DataPropertyName = "id_racuna";
            this.izbrisi.HeaderText = "Izbrisi";
            this.izbrisi.Name = "izbrisi";
            this.izbrisi.ReadOnly = true;
            this.izbrisi.Text = "Izbrisi";
            this.izbrisi.UseColumnTextForButtonValue = true;
            // 
            // Racuni_knjizeno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(905, 609);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Racuni_knjizeno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Racuni_knjizeno";
            this.Load += new System.EventHandler(this.Racuni_knjizeno_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobile_TownDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racuniknjizenoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Mobile_TownDataSet1 mobile_TownDataSet1;
        private System.Windows.Forms.BindingSource racuniknjizenoBindingSource;
        private Mobile_TownDataSet1TableAdapters.Racuni_knjizenoTableAdapter racuni_knjizenoTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idracunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumizdavanjaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iznosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iznosnabavnaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn vidi;
        private System.Windows.Forms.DataGridViewButtonColumn izbrisi;
    }
}