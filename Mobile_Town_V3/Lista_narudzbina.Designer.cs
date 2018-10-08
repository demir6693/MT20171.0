namespace Mobile_Town_V3
{
    partial class Lista_narudzbina
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_narudzbine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ime_prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.broj_telefona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opis_narudzbine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otkazi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dostavi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pictureBox2.Location = new System.Drawing.Point(726, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 23);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Mobile_Town_V3.Properties.Resources.if_Cross_2001870__1_;
            this.pictureBox1.Location = new System.Drawing.Point(757, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_narudzbine,
            this.ime_prezime,
            this.broj_telefona,
            this.opis_narudzbine,
            this.otkazi,
            this.dostavi});
            this.dataGridView1.Location = new System.Drawing.Point(17, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(752, 528);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id_narudzbine
            // 
            this.id_narudzbine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_narudzbine.FillWeight = 90.54115F;
            this.id_narudzbine.HeaderText = "id_narudzbine";
            this.id_narudzbine.Name = "id_narudzbine";
            this.id_narudzbine.ReadOnly = true;
            // 
            // ime_prezime
            // 
            this.ime_prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ime_prezime.FillWeight = 90.54115F;
            this.ime_prezime.HeaderText = "Ime i prezime";
            this.ime_prezime.Name = "ime_prezime";
            this.ime_prezime.ReadOnly = true;
            // 
            // broj_telefona
            // 
            this.broj_telefona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.broj_telefona.FillWeight = 90.54115F;
            this.broj_telefona.HeaderText = "Broj telefona";
            this.broj_telefona.Name = "broj_telefona";
            this.broj_telefona.ReadOnly = true;
            // 
            // opis_narudzbine
            // 
            this.opis_narudzbine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.opis_narudzbine.FillWeight = 182.7411F;
            this.opis_narudzbine.HeaderText = "Opis narudzbine";
            this.opis_narudzbine.Name = "opis_narudzbine";
            this.opis_narudzbine.ReadOnly = true;
            // 
            // otkazi
            // 
            this.otkazi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.otkazi.FillWeight = 55.09425F;
            this.otkazi.HeaderText = "Otkazi";
            this.otkazi.Name = "otkazi";
            this.otkazi.Text = "Otkazi";
            this.otkazi.UseColumnTextForButtonValue = true;
            // 
            // dostavi
            // 
            this.dostavi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dostavi.FillWeight = 90.54115F;
            this.dostavi.HeaderText = "Dostavi";
            this.dostavi.Name = "dostavi";
            this.dostavi.Text = "Dostavi";
            this.dostavi.UseColumnTextForButtonValue = true;
            // 
            // Lista_narudzbina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(785, 580);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lista_narudzbina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista_narudzbina";
            this.Load += new System.EventHandler(this.Lista_narudzbina_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_narudzbine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ime_prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn broj_telefona;
        private System.Windows.Forms.DataGridViewTextBoxColumn opis_narudzbine;
        private System.Windows.Forms.DataGridViewButtonColumn otkazi;
        private System.Windows.Forms.DataGridViewButtonColumn dostavi;
    }
}