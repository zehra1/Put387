﻿
namespace Put387.Win.Medalje
{
    partial class frmMedaljeIndex
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
            this.dgvMedalje = new System.Windows.Forms.DataGridView();
            this.btnDodajMedalju = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedalje)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMedalje
            // 
            this.dgvMedalje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedalje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedalje.Location = new System.Drawing.Point(60, 87);
            this.dgvMedalje.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMedalje.Name = "dgvMedalje";
            this.dgvMedalje.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvMedalje.Size = new System.Drawing.Size(807, 252);
            this.dgvMedalje.TabIndex = 0;
            this.dgvMedalje.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedalje_CellEndEdit);
            this.dgvMedalje.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMedalje_DataError);
            // 
            // btnDodajMedalju
            // 
            this.btnDodajMedalju.Location = new System.Drawing.Point(720, 13);
            this.btnDodajMedalju.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDodajMedalju.Name = "btnDodajMedalju";
            this.btnDodajMedalju.Size = new System.Drawing.Size(147, 28);
            this.btnDodajMedalju.TabIndex = 1;
            this.btnDodajMedalju.Text = "Dodaj medalju";
            this.btnDodajMedalju.UseVisualStyleBackColor = true;
            this.btnDodajMedalju.Click += new System.EventHandler(this.btnDodajMedalju_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(720, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Obrisi kategoriju";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMedaljeIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodajMedalju);
            this.Controls.Add(this.dgvMedalje);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMedaljeIndex";
            this.Text = "frmMedaljeIndex";
            this.Load += new System.EventHandler(this.frmMedaljeIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedalje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedalje;
        private System.Windows.Forms.Button btnDodajMedalju;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}