namespace GraphTheory
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.dinh = new System.Windows.Forms.Label();
            this.mat = new System.Windows.Forms.Label();
            this.printPicture = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.printPicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 187);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.StatusLbl.Location = new System.Drawing.Point(12, 236);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(0, 16);
            this.StatusLbl.TabIndex = 3;
            // 
            // dinh
            // 
            this.dinh.AutoSize = true;
            this.dinh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dinh.Location = new System.Drawing.Point(360, 34);
            this.dinh.Name = "dinh";
            this.dinh.Size = new System.Drawing.Size(51, 13);
            this.dinh.TabIndex = 4;
            this.dinh.Text = "Số Đinh: ";
            // 
            // mat
            // 
            this.mat.AutoSize = true;
            this.mat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mat.Location = new System.Drawing.Point(9, 280);
            this.mat.Name = "mat";
            this.mat.Size = new System.Drawing.Size(50, 13);
            this.mat.TabIndex = 5;
            this.mat.Text = "Ma Trận:";
            // 
            // printPicture
            // 
            this.printPicture.BackColor = System.Drawing.Color.White;
            this.printPicture.Location = new System.Drawing.Point(363, 67);
            this.printPicture.Name = "printPicture";
            this.printPicture.Size = new System.Drawing.Size(425, 283);
            this.printPicture.TabIndex = 7;
            this.printPicture.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGraphToolStripMenuItem,
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveGraphToolStripMenuItem
            // 
            this.saveGraphToolStripMenuItem.Name = "saveGraphToolStripMenuItem";
            this.saveGraphToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.saveGraphToolStripMenuItem.Text = "Save Graph";
            this.saveGraphToolStripMenuItem.Click += new System.EventHandler(this.writeGr_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.openToolStripMenuItem.Text = "Open..";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.readGr_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 225);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập ma trận";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.printPicture);
            this.Controls.Add(this.mat);
            this.Controls.Add(this.dinh);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "adsa";
            ((System.ComponentModel.ISupportInitialize)(this.printPicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Label dinh;
        private System.Windows.Forms.Label mat;
        public System.Windows.Forms.PictureBox printPicture;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

