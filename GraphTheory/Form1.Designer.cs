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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dinh = new System.Windows.Forms.Label();
            this.printPicture = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDHeadVertex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDTailVertex = new System.Windows.Forms.ComboBox();
            this.logShow = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.addVtx = new System.Windows.Forms.Button();
            this.deleteVtx = new System.Windows.Forms.Button();
            this.addEdge = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.printPicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dinh
            // 
            this.dinh.AutoSize = true;
            this.dinh.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dinh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dinh.Location = new System.Drawing.Point(359, 28);
            this.dinh.Name = "dinh";
            this.dinh.Size = new System.Drawing.Size(62, 19);
            this.dinh.TabIndex = 4;
            this.dinh.Text = "Số Đỉnh:";
            // 
            // printPicture
            // 
            this.printPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printPicture.BackColor = System.Drawing.Color.Black;
            this.printPicture.Location = new System.Drawing.Point(372, 49);
            this.printPicture.Name = "printPicture";
            this.printPicture.Size = new System.Drawing.Size(400, 500);
            this.printPicture.TabIndex = 7;
            this.printPicture.TabStop = false;
            this.printPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.printPicture_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGraphToolStripMenuItem,
            this.openToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveGraphToolStripMenuItem
            // 
            this.saveGraphToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveGraphToolStripMenuItem.Name = "saveGraphToolStripMenuItem";
            this.saveGraphToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.saveGraphToolStripMenuItem.Text = "Save Graph";
            this.saveGraphToolStripMenuItem.Click += new System.EventHandler(this.writeGr_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.fromFileToolStripMenuItem1});
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.openToolStripMenuItem.Text = "Load Graph";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fromFileToolStripMenuItem.Text = "New Graph";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.NewGraph);
            // 
            // fromFileToolStripMenuItem1
            // 
            this.fromFileToolStripMenuItem1.Name = "fromFileToolStripMenuItem1";
            this.fromFileToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.fromFileToolStripMenuItem1.Text = "From File..";
            this.fromFileToolStripMenuItem1.Click += new System.EventHandler(this.readGr_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.start.Enabled = false;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.SystemColors.Highlight;
            this.start.Location = new System.Drawing.Point(12, 82);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(310, 29);
            this.start.TabIndex = 76;
            this.start.Text = "Bắt đầu";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(128, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 75;
            this.label3.Text = "Đến đỉnh";
            // 
            // cbDHeadVertex
            // 
            this.cbDHeadVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDHeadVertex.Enabled = false;
            this.cbDHeadVertex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDHeadVertex.FormattingEnabled = true;
            this.cbDHeadVertex.Location = new System.Drawing.Point(74, 49);
            this.cbDHeadVertex.Name = "cbDHeadVertex";
            this.cbDHeadVertex.Size = new System.Drawing.Size(48, 27);
            this.cbDHeadVertex.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 19);
            this.label5.TabIndex = 73;
            this.label5.Text = "Từ đỉnh";
            // 
            // cbDTailVertex
            // 
            this.cbDTailVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDTailVertex.Enabled = false;
            this.cbDTailVertex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDTailVertex.FormattingEnabled = true;
            this.cbDTailVertex.Location = new System.Drawing.Point(201, 49);
            this.cbDTailVertex.Name = "cbDTailVertex";
            this.cbDTailVertex.Size = new System.Drawing.Size(48, 27);
            this.cbDTailVertex.TabIndex = 72;
            // 
            // logShow
            // 
            this.logShow.AutoSize = true;
            this.logShow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logShow.Location = new System.Drawing.Point(12, 113);
            this.logShow.Name = "logShow";
            this.logShow.Size = new System.Drawing.Size(31, 16);
            this.logShow.TabIndex = 78;
            this.logShow.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(12, 132);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(310, 190);
            this.rtbLog.TabIndex = 77;
            this.rtbLog.Text = "";
            // 
            // addVtx
            // 
            this.addVtx.Enabled = false;
            this.addVtx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addVtx.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addVtx.Location = new System.Drawing.Point(12, 348);
            this.addVtx.Name = "addVtx";
            this.addVtx.Size = new System.Drawing.Size(75, 75);
            this.addVtx.TabIndex = 79;
            this.addVtx.Text = "Thêm đỉnh";
            this.addVtx.UseVisualStyleBackColor = true;
            this.addVtx.Click += new System.EventHandler(this.addVtx_Click);
            // 
            // deleteVtx
            // 
            this.deleteVtx.Enabled = false;
            this.deleteVtx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteVtx.ForeColor = System.Drawing.SystemColors.Highlight;
            this.deleteVtx.Location = new System.Drawing.Point(129, 348);
            this.deleteVtx.Name = "deleteVtx";
            this.deleteVtx.Size = new System.Drawing.Size(75, 75);
            this.deleteVtx.TabIndex = 80;
            this.deleteVtx.Text = "Xoá đỉnh";
            this.deleteVtx.UseVisualStyleBackColor = true;
            this.deleteVtx.Click += new System.EventHandler(this.deleteVtx_Click);
            // 
            // addEdge
            // 
            this.addEdge.Enabled = false;
            this.addEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEdge.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addEdge.Location = new System.Drawing.Point(246, 348);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(75, 75);
            this.addEdge.TabIndex = 81;
            this.addEdge.Text = "Thêm cạnh";
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.addEdge_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.addEdge);
            this.Controls.Add(this.deleteVtx);
            this.Controls.Add(this.addVtx);
            this.Controls.Add(this.logShow);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDHeadVertex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDTailVertex);
            this.Controls.Add(this.printPicture);
            this.Controls.Add(this.dinh);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphTheory";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.printPicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox printPicture;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbDHeadVertex;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbDTailVertex;
        private System.Windows.Forms.Label logShow;
        public System.Windows.Forms.RichTextBox rtbLog;
        public System.Windows.Forms.Label dinh;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem1;
        private System.Windows.Forms.Button addVtx;
        private System.Windows.Forms.Button deleteVtx;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

