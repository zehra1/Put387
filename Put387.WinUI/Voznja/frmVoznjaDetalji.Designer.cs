
namespace Put387.WinUI.Voznja
{
    partial class frmVoznjaDetalji
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.txtOdrediste = new System.Windows.Forms.TextBox();
            this.Orediste = new System.Windows.Forms.Label();
            this.txtPolaziste = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTipVoznje = new System.Windows.Forms.Label();
            this.txtImeVoz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbKorisnici = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOcjena = new System.Windows.Forms.Label();
            this.dgvDojmovi = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDojmovi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetalji);
            this.groupBox1.Controls.Add(this.txtOdrediste);
            this.groupBox1.Controls.Add(this.Orediste);
            this.groupBox1.Controls.Add(this.txtPolaziste);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTipVoznje);
            this.groupBox1.Controls.Add(this.txtImeVoz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji vozaca za odabranu relaciju";
            // 
            // btnDetalji
            // 
            this.btnDetalji.BackColor = System.Drawing.Color.Gold;
            this.btnDetalji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalji.Location = new System.Drawing.Point(240, 67);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(111, 29);
            this.btnDetalji.TabIndex = 12;
            this.btnDetalji.Text = "Detalji vozaca";
            this.btnDetalji.UseVisualStyleBackColor = false;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // txtOdrediste
            // 
            this.txtOdrediste.Location = new System.Drawing.Point(200, 139);
            this.txtOdrediste.Name = "txtOdrediste";
            this.txtOdrediste.ReadOnly = true;
            this.txtOdrediste.Size = new System.Drawing.Size(151, 27);
            this.txtOdrediste.TabIndex = 9;
            // 
            // Orediste
            // 
            this.Orediste.AutoSize = true;
            this.Orediste.Location = new System.Drawing.Point(197, 116);
            this.Orediste.Name = "Orediste";
            this.Orediste.Size = new System.Drawing.Size(74, 20);
            this.Orediste.TabIndex = 8;
            this.Orediste.Text = "Odrediste";
            // 
            // txtPolaziste
            // 
            this.txtPolaziste.Location = new System.Drawing.Point(19, 139);
            this.txtPolaziste.Name = "txtPolaziste";
            this.txtPolaziste.ReadOnly = true;
            this.txtPolaziste.Size = new System.Drawing.Size(157, 27);
            this.txtPolaziste.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Polaziste";
            // 
            // lblTipVoznje
            // 
            this.lblTipVoznje.AutoSize = true;
            this.lblTipVoznje.Location = new System.Drawing.Point(240, 21);
            this.lblTipVoznje.Name = "lblTipVoznje";
            this.lblTipVoznje.Size = new System.Drawing.Size(77, 20);
            this.lblTipVoznje.TabIndex = 2;
            this.lblTipVoznje.Text = "Tip voznje";
            // 
            // txtImeVoz
            // 
            this.txtImeVoz.Location = new System.Drawing.Point(16, 67);
            this.txtImeVoz.Name = "txtImeVoz";
            this.txtImeVoz.ReadOnly = true;
            this.txtImeVoz.Size = new System.Drawing.Size(202, 27);
            this.txtImeVoz.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime vozaca";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbKorisnici);
            this.groupBox2.Location = new System.Drawing.Point(421, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 187);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji korisnika aplikacije";
            // 
            // lbKorisnici
            // 
            this.lbKorisnici.FormattingEnabled = true;
            this.lbKorisnici.ItemHeight = 20;
            this.lbKorisnici.Location = new System.Drawing.Point(16, 30);
            this.lbKorisnici.Name = "lbKorisnici";
            this.lbKorisnici.Size = new System.Drawing.Size(237, 144);
            this.lbKorisnici.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ocjena";
            // 
            // lblOcjena
            // 
            this.lblOcjena.AutoSize = true;
            this.lblOcjena.Location = new System.Drawing.Point(668, 468);
            this.lblOcjena.Name = "lblOcjena";
            this.lblOcjena.Size = new System.Drawing.Size(18, 20);
            this.lblOcjena.TabIndex = 10;
            this.lblOcjena.Text = "#";
            // 
            // dgvDojmovi
            // 
            this.dgvDojmovi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDojmovi.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDojmovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDojmovi.Location = new System.Drawing.Point(12, 26);
            this.dgvDojmovi.Name = "dgvDojmovi";
            this.dgvDojmovi.RowHeadersWidth = 51;
            this.dgvDojmovi.RowTemplate.Height = 29;
            this.dgvDojmovi.Size = new System.Drawing.Size(640, 188);
            this.dgvDojmovi.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gold;
            this.groupBox3.Controls.Add(this.dgvDojmovi);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(24, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(665, 227);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista svih korisnika te njihovih dojmova za odabranu voznju";
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.BackColor = System.Drawing.Color.Gold;
            this.btnIzvjestaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzvjestaj.Location = new System.Drawing.Point(24, 464);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(111, 29);
            this.btnIzvjestaj.TabIndex = 13;
            this.btnIzvjestaj.Text = "Izvjestaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = false;
            // 
            // frmVoznjaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 502);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblOcjena);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "frmVoznjaDetalji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalji vožnje";
            this.Load += new System.EventHandler(this.frmVoznjaDetalji_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDojmovi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbKorisnici;
        private System.Windows.Forms.TextBox txtOdrediste;
        private System.Windows.Forms.Label Orediste;
        private System.Windows.Forms.TextBox txtPolaziste;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipVoznje;
        private System.Windows.Forms.TextBox txtImeVoz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOcjena;
        private System.Windows.Forms.DataGridView dgvDojmovi;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIzvjestaj;
    }
}