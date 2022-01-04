namespace NPC_Register
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLocationRemove = new System.Windows.Forms.Button();
            this.btnLocationCreate = new System.Windows.Forms.Button();
            this.pnlNPC = new System.Windows.Forms.Panel();
            this.btnNpcRemove = new System.Windows.Forms.Button();
            this.btnNpcCreate = new System.Windows.Forms.Button();
            this.pnlWorkTools = new System.Windows.Forms.Panel();
            this.btnNoteAdd = new System.Windows.Forms.Button();
            this.pnlWorkSpace = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.tsOpenDB = new System.Windows.Forms.ToolStripButton();
            this.tsCreateDB = new System.Windows.Forms.ToolStripButton();
            this.tsDb1 = new System.Windows.Forms.ToolStripButton();
            this.dlgCreate = new System.Windows.Forms.FolderBrowserDialog();
            this.hierarchy2 = new System.Windows.Forms.ListBox();
            this.pnlWork = new System.Windows.Forms.Panel();
            this.hierarchy1 = new System.Windows.Forms.ListBox();
            this.pnlTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlNPC.SuspendLayout();
            this.pnlWorkTools.SuspendLayout();
            this.pnlWorkSpace.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.pnlWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Tomato;
            this.pnlTop.Controls.Add(this.panel3);
            this.pnlTop.Controls.Add(this.pnlNPC);
            this.pnlTop.Location = new System.Drawing.Point(12, 37);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(995, 46);
            this.pnlTop.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Khaki;
            this.panel3.Controls.Add(this.btnLocationRemove);
            this.panel3.Controls.Add(this.btnLocationCreate);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 47);
            this.panel3.TabIndex = 4;
            // 
            // btnLocationRemove
            // 
            this.btnLocationRemove.Location = new System.Drawing.Point(101, 4);
            this.btnLocationRemove.Name = "btnLocationRemove";
            this.btnLocationRemove.Size = new System.Drawing.Size(73, 38);
            this.btnLocationRemove.TabIndex = 1;
            this.btnLocationRemove.Text = "Remove Location";
            this.btnLocationRemove.UseVisualStyleBackColor = true;
            // 
            // btnLocationCreate
            // 
            this.btnLocationCreate.Location = new System.Drawing.Point(4, 4);
            this.btnLocationCreate.Name = "btnLocationCreate";
            this.btnLocationCreate.Size = new System.Drawing.Size(73, 38);
            this.btnLocationCreate.TabIndex = 0;
            this.btnLocationCreate.Text = "Create Location";
            this.btnLocationCreate.UseVisualStyleBackColor = true;
            // 
            // pnlNPC
            // 
            this.pnlNPC.BackColor = System.Drawing.Color.OliveDrab;
            this.pnlNPC.Controls.Add(this.btnNpcRemove);
            this.pnlNPC.Controls.Add(this.btnNpcCreate);
            this.pnlNPC.Location = new System.Drawing.Point(180, 0);
            this.pnlNPC.Name = "pnlNPC";
            this.pnlNPC.Size = new System.Drawing.Size(171, 47);
            this.pnlNPC.TabIndex = 3;
            // 
            // btnNpcRemove
            // 
            this.btnNpcRemove.Location = new System.Drawing.Point(82, 3);
            this.btnNpcRemove.Name = "btnNpcRemove";
            this.btnNpcRemove.Size = new System.Drawing.Size(86, 39);
            this.btnNpcRemove.TabIndex = 1;
            this.btnNpcRemove.Text = "Remove NPC";
            this.btnNpcRemove.UseVisualStyleBackColor = true;
            // 
            // btnNpcCreate
            // 
            this.btnNpcCreate.Location = new System.Drawing.Point(3, 3);
            this.btnNpcCreate.Name = "btnNpcCreate";
            this.btnNpcCreate.Size = new System.Drawing.Size(73, 39);
            this.btnNpcCreate.TabIndex = 0;
            this.btnNpcCreate.Text = "Create NPC";
            this.btnNpcCreate.UseVisualStyleBackColor = true;
            this.btnNpcCreate.Click += new System.EventHandler(this.btnNpcCreate_Click);
            // 
            // pnlWorkTools
            // 
            this.pnlWorkTools.BackColor = System.Drawing.Color.Maroon;
            this.pnlWorkTools.Controls.Add(this.btnNoteAdd);
            this.pnlWorkTools.Location = new System.Drawing.Point(652, 37);
            this.pnlWorkTools.Name = "pnlWorkTools";
            this.pnlWorkTools.Size = new System.Drawing.Size(355, 46);
            this.pnlWorkTools.TabIndex = 2;
            // 
            // btnNoteAdd
            // 
            this.btnNoteAdd.Location = new System.Drawing.Point(3, 3);
            this.btnNoteAdd.Name = "btnNoteAdd";
            this.btnNoteAdd.Size = new System.Drawing.Size(86, 39);
            this.btnNoteAdd.TabIndex = 2;
            this.btnNoteAdd.Text = "Create Note";
            this.btnNoteAdd.UseVisualStyleBackColor = true;
            // 
            // pnlWorkSpace
            // 
            this.pnlWorkSpace.BackColor = System.Drawing.Color.DarkTurquoise;
            this.pnlWorkSpace.Controls.Add(this.panel1);
            this.pnlWorkSpace.Location = new System.Drawing.Point(341, 3);
            this.pnlWorkSpace.Name = "pnlWorkSpace";
            this.pnlWorkSpace.Size = new System.Drawing.Size(651, 431);
            this.pnlWorkSpace.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orchid;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(131, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 170);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 46);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(162, 121);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "hello\nHow are you today?\n";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Magenta;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 40);
            this.panel2.TabIndex = 0;
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpenDB,
            this.tsCreateDB,
            this.tsDb1});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(1007, 25);
            this.tsTop.TabIndex = 3;
            this.tsTop.Text = "toolStrip1";
            // 
            // tsOpenDB
            // 
            this.tsOpenDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsOpenDB.Image = ((System.Drawing.Image)(resources.GetObject("tsOpenDB.Image")));
            this.tsOpenDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpenDB.Name = "tsOpenDB";
            this.tsOpenDB.Size = new System.Drawing.Size(58, 22);
            this.tsOpenDB.Text = "Open DB";
            this.tsOpenDB.Click += new System.EventHandler(this.tsOpenDB_Click);
            // 
            // tsCreateDB
            // 
            this.tsCreateDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCreateDB.Image = ((System.Drawing.Image)(resources.GetObject("tsCreateDB.Image")));
            this.tsCreateDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCreateDB.Name = "tsCreateDB";
            this.tsCreateDB.Size = new System.Drawing.Size(63, 22);
            this.tsCreateDB.Text = "Create DB";
            this.tsCreateDB.Click += new System.EventHandler(this.tsCreateDB_Click);
            // 
            // tsDb1
            // 
            this.tsDb1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDb1.Image = ((System.Drawing.Image)(resources.GetObject("tsDb1.Image")));
            this.tsDb1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDb1.Name = "tsDb1";
            this.tsDb1.Size = new System.Drawing.Size(79, 22);
            this.tsDb1.Text = "Execute DB 1";
            this.tsDb1.Click += new System.EventHandler(this.tsDb1_Click);
            // 
            // hierarchy2
            // 
            this.hierarchy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hierarchy2.FormattingEnabled = true;
            this.hierarchy2.ItemHeight = 20;
            this.hierarchy2.Location = new System.Drawing.Point(180, 3);
            this.hierarchy2.Name = "hierarchy2";
            this.hierarchy2.Size = new System.Drawing.Size(155, 424);
            this.hierarchy2.TabIndex = 4;
            this.hierarchy2.SelectedIndexChanged += new System.EventHandler(this.hierarchy2_SelectedIndexChanged);
            // 
            // pnlWork
            // 
            this.pnlWork.BackColor = System.Drawing.Color.PaleVioletRed;
            this.pnlWork.Controls.Add(this.hierarchy1);
            this.pnlWork.Controls.Add(this.hierarchy2);
            this.pnlWork.Controls.Add(this.pnlWorkSpace);
            this.pnlWork.Location = new System.Drawing.Point(12, 90);
            this.pnlWork.Name = "pnlWork";
            this.pnlWork.Size = new System.Drawing.Size(995, 445);
            this.pnlWork.TabIndex = 5;
            // 
            // hierarchy1
            // 
            this.hierarchy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hierarchy1.FormattingEnabled = true;
            this.hierarchy1.ItemHeight = 20;
            this.hierarchy1.Location = new System.Drawing.Point(3, 3);
            this.hierarchy1.Name = "hierarchy1";
            this.hierarchy1.Size = new System.Drawing.Size(171, 424);
            this.hierarchy1.TabIndex = 6;
            this.hierarchy1.SelectedIndexChanged += new System.EventHandler(this.hierarchy1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 536);
            this.Controls.Add(this.pnlWork);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.pnlWorkTools);
            this.Controls.Add(this.pnlTop);
            this.Name = "Form1";
            this.Text = "NPC Register";
            this.pnlTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlNPC.ResumeLayout(false);
            this.pnlWorkTools.ResumeLayout(false);
            this.pnlWorkSpace.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.pnlWork.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlWorkSpace;
        private System.Windows.Forms.Button btnNpcCreate;
        private System.Windows.Forms.Panel pnlNPC;
        private System.Windows.Forms.Button btnNpcRemove;
        private System.Windows.Forms.Panel pnlWorkTools;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton tsOpenDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNoteAdd;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripButton tsCreateDB;
        private System.Windows.Forms.FolderBrowserDialog dlgCreate;
        private System.Windows.Forms.ToolStripButton tsDb1;
        private System.Windows.Forms.ListBox hierarchy2;
        private System.Windows.Forms.Panel pnlWork;
        private System.Windows.Forms.ListBox hierarchy1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLocationRemove;
        private System.Windows.Forms.Button btnLocationCreate;
    }
}

