
namespace Put387.Win.Medalje
{
    partial class frmMedaljaDodaj
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
            this.button1 = new System.Windows.Forms.Button();
            this.gbKategorija = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxBr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinBr = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.gbKategorija.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 310);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbKategorija
            // 
            this.gbKategorija.Controls.Add(this.label5);
            this.gbKategorija.Controls.Add(this.pbIcon);
            this.gbKategorija.Controls.Add(this.txtBox);
            this.gbKategorija.Controls.Add(this.label4);
            this.gbKategorija.Controls.Add(this.txtMaxBr);
            this.gbKategorija.Controls.Add(this.label3);
            this.gbKategorija.Controls.Add(this.label2);
            this.gbKategorija.Controls.Add(this.txtMinBr);
            this.gbKategorija.Controls.Add(this.txtNaziv);
            this.gbKategorija.Controls.Add(this.label1);
            this.gbKategorija.Location = new System.Drawing.Point(40, 47);
            this.gbKategorija.Margin = new System.Windows.Forms.Padding(4);
            this.gbKategorija.Name = "gbKategorija";
            this.gbKategorija.Padding = new System.Windows.Forms.Padding(4);
            this.gbKategorija.Size = new System.Drawing.Size(583, 256);
            this.gbKategorija.TabIndex = 12;
            this.gbKategorija.TabStop = false;
            this.gbKategorija.Text = "Naziv katgorije";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ikonica";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(23, 183);
            this.txtBox.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(323, 47);
            this.txtBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Opis:";
            // 
            // txtMaxBr
            // 
            this.txtMaxBr.Location = new System.Drawing.Point(212, 118);
            this.txtMaxBr.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxBr.Name = "txtMaxBr";
            this.txtMaxBr.Size = new System.Drawing.Size(132, 22);
            this.txtMaxBr.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Minimalan broj voznji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Minimalan broj voznji";
            // 
            // txtMinBr
            // 
            this.txtMinBr.Location = new System.Drawing.Point(21, 118);
            this.txtMinBr.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinBr.Name = "txtMinBr";
            this.txtMinBr.Size = new System.Drawing.Size(133, 22);
            this.txtMinBr.TabIndex = 12;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(21, 57);
            this.txtNaziv.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(323, 22);
            this.txtNaziv.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Naziv";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // pbIcon
            // 
            this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIcon.Image = global::Put387.Win.Properties.Resources.medal_1369;
            this.pbIcon.Location = new System.Drawing.Point(403, 98);
            this.pbIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(160, 132);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 18;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            // 
            // frmMedaljaDodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(656, 350);
            this.Controls.Add(this.gbKategorija);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMedaljaDodaj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj medalju";
            this.Load += new System.EventHandler(this.frmMedaljaDodaj_Load);
            this.gbKategorija.ResumeLayout(false);
            this.gbKategorija.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbKategorija;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaxBr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinBr;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider err;
    }
}