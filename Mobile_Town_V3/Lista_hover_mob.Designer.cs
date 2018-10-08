namespace Mobile_Town_V3
{
    partial class Lista_hover_mob
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mobhoverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mobile_TownDataSet3 = new Mobile_Town_V3.Mobile_TownDataSet3();
            this.mob_hoverTableAdapter = new Mobile_Town_V3.Mobile_TownDataSet3TableAdapters.mob_hoverTableAdapter();
            this.mobile_TownDataSet4 = new Mobile_Town_V3.Mobile_TownDataSet4();
            this.mobhoverknjizenoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mob_hover_knjizenoTableAdapter = new Mobile_Town_V3.Mobile_TownDataSet4TableAdapters.mob_hover_knjizenoTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sifraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artikalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nabavnacenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodajnacenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.izmeni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.izbrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobhoverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobile_TownDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobile_TownDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobhoverknjizenoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 29);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(775, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 551);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 551);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 570);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(765, 10);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(17, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(752, 528);
            this.panel5.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(257, 501);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Knjizeno";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mobilni telefon",
            "Hoverbord",
            "Ostalo"});
            this.comboBox1.Location = new System.Drawing.Point(122, 497);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 26);
            this.comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Grupa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sifraDataGridViewTextBoxColumn,
            this.grupaDataGridViewTextBoxColumn,
            this.artikalDataGridViewTextBoxColumn,
            this.kolicinaDataGridViewTextBoxColumn,
            this.nabavnacenaDataGridViewTextBoxColumn,
            this.prodajnacenaDataGridViewTextBoxColumn,
            this.prodaj,
            this.izmeni,
            this.izbrisi});
            this.dataGridView1.DataSource = this.mobhoverBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(745, 484);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // mobhoverBindingSource
            // 
            this.mobhoverBindingSource.DataMember = "mob_hover";
            this.mobhoverBindingSource.DataSource = this.mobile_TownDataSet3;
            // 
            // mobile_TownDataSet3
            // 
            this.mobile_TownDataSet3.DataSetName = "Mobile_TownDataSet3";
            this.mobile_TownDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mob_hoverTableAdapter
            // 
            this.mob_hoverTableAdapter.ClearBeforeFill = true;
            // 
            // mobile_TownDataSet4
            // 
            this.mobile_TownDataSet4.DataSetName = "Mobile_TownDataSet4";
            this.mobile_TownDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobhoverknjizenoBindingSource
            // 
            this.mobhoverknjizenoBindingSource.DataMember = "mob_hover_knjizeno";
            this.mobhoverknjizenoBindingSource.DataSource = this.mobile_TownDataSet4;
            // 
            // mob_hover_knjizenoTableAdapter
            // 
            this.mob_hover_knjizenoTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Mobile_Town_V3.Properties.Resources.if_Cross_2001870__1_;
            this.pictureBox1.Location = new System.Drawing.Point(759, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sifraDataGridViewTextBoxColumn
            // 
            this.sifraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sifraDataGridViewTextBoxColumn.DataPropertyName = "sifra";
            this.sifraDataGridViewTextBoxColumn.HeaderText = "sifra";
            this.sifraDataGridViewTextBoxColumn.Name = "sifraDataGridViewTextBoxColumn";
            // 
            // grupaDataGridViewTextBoxColumn
            // 
            this.grupaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grupaDataGridViewTextBoxColumn.DataPropertyName = "grupa";
            this.grupaDataGridViewTextBoxColumn.HeaderText = "grupa";
            this.grupaDataGridViewTextBoxColumn.Name = "grupaDataGridViewTextBoxColumn";
            // 
            // artikalDataGridViewTextBoxColumn
            // 
            this.artikalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.artikalDataGridViewTextBoxColumn.DataPropertyName = "artikal";
            this.artikalDataGridViewTextBoxColumn.HeaderText = "artikal";
            this.artikalDataGridViewTextBoxColumn.Name = "artikalDataGridViewTextBoxColumn";
            // 
            // kolicinaDataGridViewTextBoxColumn
            // 
            this.kolicinaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kolicinaDataGridViewTextBoxColumn.DataPropertyName = "kolicina";
            this.kolicinaDataGridViewTextBoxColumn.HeaderText = "kolicina";
            this.kolicinaDataGridViewTextBoxColumn.Name = "kolicinaDataGridViewTextBoxColumn";
            // 
            // nabavnacenaDataGridViewTextBoxColumn
            // 
            this.nabavnacenaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nabavnacenaDataGridViewTextBoxColumn.DataPropertyName = "nabavna_cena";
            this.nabavnacenaDataGridViewTextBoxColumn.HeaderText = "nabavna_cena";
            this.nabavnacenaDataGridViewTextBoxColumn.Name = "nabavnacenaDataGridViewTextBoxColumn";
            this.nabavnacenaDataGridViewTextBoxColumn.Visible = false;
            // 
            // prodajnacenaDataGridViewTextBoxColumn
            // 
            this.prodajnacenaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prodajnacenaDataGridViewTextBoxColumn.DataPropertyName = "prodajna_cena";
            this.prodajnacenaDataGridViewTextBoxColumn.HeaderText = "prodajna_cena";
            this.prodajnacenaDataGridViewTextBoxColumn.Name = "prodajnacenaDataGridViewTextBoxColumn";
            // 
            // prodaj
            // 
            this.prodaj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prodaj.DataPropertyName = "sifra";
            this.prodaj.HeaderText = "Prodaj";
            this.prodaj.Name = "prodaj";
            this.prodaj.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.prodaj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.prodaj.Text = "Prodaj";
            this.prodaj.ToolTipText = "Prodaj";
            this.prodaj.UseColumnTextForButtonValue = true;
            // 
            // izmeni
            // 
            this.izmeni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.izmeni.DataPropertyName = "sifra";
            this.izmeni.HeaderText = "Izmeni";
            this.izmeni.Name = "izmeni";
            this.izmeni.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.izmeni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.izmeni.Text = "Izmeni";
            this.izmeni.ToolTipText = "Izmeni";
            this.izmeni.UseColumnTextForButtonValue = true;
            // 
            // izbrisi
            // 
            this.izbrisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.izbrisi.DataPropertyName = "sifra";
            this.izbrisi.HeaderText = "Izbrisi";
            this.izbrisi.Name = "izbrisi";
            this.izbrisi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.izbrisi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.izbrisi.Text = "Izbrisi";
            this.izbrisi.ToolTipText = "Izbrisi";
            this.izbrisi.UseColumnTextForButtonValue = true;
            // 
            // Lista_hover_mob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(785, 580);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lista_hover_mob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista_hover_mob";
            this.Load += new System.EventHandler(this.Lista_hover_mob_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobhoverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobile_TownDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobile_TownDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobhoverknjizenoBindingSource)).EndInit();
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
        private Mobile_TownDataSet3 mobile_TownDataSet3;
        private System.Windows.Forms.BindingSource mobhoverBindingSource;
        private Mobile_TownDataSet3TableAdapters.mob_hoverTableAdapter mob_hoverTableAdapter;
        private Mobile_TownDataSet4 mobile_TownDataSet4;
        private System.Windows.Forms.BindingSource mobhoverknjizenoBindingSource;
        private Mobile_TownDataSet4TableAdapters.mob_hover_knjizenoTableAdapter mob_hover_knjizenoTableAdapter;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolicinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nabavnacenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodajnacenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn prodaj;
        private System.Windows.Forms.DataGridViewButtonColumn izmeni;
        private System.Windows.Forms.DataGridViewButtonColumn izbrisi;
    }
}