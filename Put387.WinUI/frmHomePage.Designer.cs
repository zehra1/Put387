
namespace Put387.WinUI
{
    partial class frmHomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBadges = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRides = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.btnBadges);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.btnRides);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Location = new System.Drawing.Point(1, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 535);
            this.panel1.TabIndex = 0;
            // 
            // btnBadges
            // 
            this.btnBadges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.btnBadges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBadges.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnBadges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBadges.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBadges.Location = new System.Drawing.Point(31, 403);
            this.btnBadges.Name = "btnBadges";
            this.btnBadges.Size = new System.Drawing.Size(201, 70);
            this.btnBadges.TabIndex = 7;
            this.btnBadges.Text = "Medalje";
            this.btnBadges.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUsers.Location = new System.Drawing.Point(31, 317);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(201, 70);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Korisnici";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnRides
            // 
            this.btnRides.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.btnRides.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRides.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnRides.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRides.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRides.Location = new System.Drawing.Point(31, 232);
            this.btnRides.Name = "btnRides";
            this.btnRides.Size = new System.Drawing.Size(201, 70);
            this.btnRides.TabIndex = 5;
            this.btnRides.Text = "Vožnje";
            this.btnRides.UseVisualStyleBackColor = false;
            this.btnRides.Click += new System.EventHandler(this.btnRides_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OldLace;
            this.pictureBox1.Location = new System.Drawing.Point(25, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 104);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(194)))), ((int)(((byte)(0)))));
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHome.Location = new System.Drawing.Point(31, 146);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(201, 70);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Početna";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(265, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(888, 524);
            this.pnlContent.TabIndex = 1;
            // 
            // frmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 521);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Name = "frmHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.frmHomePage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBadges;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnRides;
        private System.Windows.Forms.Panel pnlContent;
    }
}

