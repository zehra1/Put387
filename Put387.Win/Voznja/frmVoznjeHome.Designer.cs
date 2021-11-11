
namespace Put387.WinUI.Voznja
{
    partial class frmVoznjeHome
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
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnNadolazece = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHistory.Location = new System.Drawing.Point(64, 143);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(295, 103);
            this.btnHistory.TabIndex = 7;
            this.btnHistory.Text = "Historija vožnji";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnNadolazece
            // 
            this.btnNadolazece.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.btnNadolazece.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNadolazece.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnNadolazece.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNadolazece.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNadolazece.Location = new System.Drawing.Point(430, 143);
            this.btnNadolazece.Name = "btnNadolazece";
            this.btnNadolazece.Size = new System.Drawing.Size(295, 103);
            this.btnNadolazece.TabIndex = 8;
            this.btnNadolazece.Text = "Nadolazeće vožnje";
            this.btnNadolazece.UseVisualStyleBackColor = false;
            this.btnNadolazece.Click += new System.EventHandler(this.btnNadolazece_Click);
            // 
            // frmVoznjeHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNadolazece);
            this.Controls.Add(this.btnHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVoznjeHome";
            this.Text = "frmVoznjeHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnNadolazece;
    }
}