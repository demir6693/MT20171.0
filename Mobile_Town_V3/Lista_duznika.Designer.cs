namespace Mobile_Town_V3
{
    partial class Lista_duznika
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_duga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ime_prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.broj_telefona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum_izdavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum_vracanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sifra_artikla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artikal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izbrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.izmeni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.naplati = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(785, 29);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Mobile_Town_V3.Properties.Resources.if_Retract_20018861;
            this.pictureBox2.Location = new System.Drawing.Point(730, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Mobile_Town_V3.Properties.Resources.if_Cross_2001870__1_;
            this.pictureBox1.Location = new System.Drawing.Point(759, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 551);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(775, 29);
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
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(16, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(753, 529);
            this.panel5.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_duga,
            this.ime_prezime,
            this.broj_telefona,
            this.datum_izdavanja,
            this.datum_vracanja,
            this.sifra_artikla,
            this.artikal,
            this.cena,
            this.izbrisi,
            this.izmeni,
            this.naplati});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(753, 529);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id_duga
            // 
            this.id_duga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_duga.HeaderText = "id_duga";
            this.id_duga.Name = "id_duga";
            this.id_duga.ReadOnly = true;
            // 
            // ime_prezime
            // 
            this.ime_prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ime_prezime.HeaderText = "Ime i prezime";
            this.ime_prezime.Name = "ime_prezime";
            this.ime_prezime.ReadOnly = true;
            // 
            // broj_telefona
            // 
            this.broj_telefona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.broj_telefona.HeaderText = "Broj telefona";
            this.broj_telefona.Name = "broj_telefona";
            this.broj_telefona.ReadOnly = true;
            // 
            // datum_izdavanja
            // 
            this.datum_izdavanja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datum_izdavanja.HeaderText = "Datum izdavanja";
            this.datum_izdavanja.Name = "datum_izdavanja";
            this.datum_izdavanja.ReadOnly = true;
            // 
            // datum_vracanja
            // 
            this.datum_vracanja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datum_vracanja.HeaderText = "Datum vracanja";
            this.datum_vracanja.Name = "datum_vracanja";
            this.datum_vracanja.ReadOnly = true;
            // 
            // sifra_artikla
            // 
            this.sifra_artikla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sifra_artikla.HeaderText = "Sifra artikla";
            this.sifra_artikla.Name = "sifra_artikla";
            this.sifra_artikla.ReadOnly = true;
            // 
            // artikal
            // 
            this.artikal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.artikal.HeaderText = "Artikal";
            this.artikal.Name = "artikal";
            this.artikal.ReadOnly = true;
            // 
            // cena
            // 
            this.cena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cena.HeaderText = "Iznos";
            this.cena.Name = "cena";
            this.cena.ReadOnly = true;
            // 
            // izbrisi
            // 
            this.izbrisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.izbrisi.HeaderText = "Izbrisi";
            this.izbrisi.Name = "izbrisi";
            this.izbrisi.Text = "Izbrisi";
            this.izbrisi.UseColumnTextForButtonValue = true;
            // 
            // izmeni
            // 
            this.izmeni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.izmeni.HeaderText = "Izmeni";
            this.izmeni.Name = "izmeni";
            this.izmeni.Text = "Izmeni";
            this.izmeni.UseColumnTextForButtonValue = true;
            // 
            // naplati
            // 
            this.naplati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.naplati.HeaderText = "Naplati";
            this.naplati.Name = "naplati";
            this.naplati.Text = "Naplati";
            this.naplati.UseColumnTextForButtonValue = true;
            // 
            // Lista_duznika
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
            this.Name = "Lista_duznika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista_duznika";
            this.Load += new System.EventHandler(this.Lista_duznika_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_duga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ime_prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn broj_telefona;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum_izdavanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum_vracanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifra_artikla;
        private System.Windows.Forms.DataGridViewTextBoxColumn artikal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cena;
        private System.Windows.Forms.DataGridViewButtonColumn izbrisi;
        private System.Windows.Forms.DataGridViewButtonColumn izmeni;
        private System.Windows.Forms.DataGridViewButtonColumn naplati;
    }
}