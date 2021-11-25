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
            this.itemList = new System.Windows.Forms.ListBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlWorkSpace = new System.Windows.Forms.Panel();
            this.btnNPCCreate = new System.Windows.Forms.Button();
            this.btnNPCRemove = new System.Windows.Forms.Button();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.tsOpenDB = new System.Windows.Forms.ToolStripButton();
            this.pnlWorkTools = new System.Windows.Forms.Panel();
            this.pnlNPC = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.pnlNPC.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemList
            // 
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(12, 90);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(171, 355);
            this.itemList.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Tomato;
            this.pnlTop.Controls.Add(this.pnlNPC);
            this.pnlTop.Controls.Add(this.pnlWorkTools);
            this.pnlTop.Location = new System.Drawing.Point(12, 37);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(776, 46);
            this.pnlTop.TabIndex = 1;
            // 
            // pnlWorkSpace
            // 
            this.pnlWorkSpace.BackColor = System.Drawing.Color.DarkTurquoise;
            this.pnlWorkSpace.Location = new System.Drawing.Point(189, 89);
            this.pnlWorkSpace.Name = "pnlWorkSpace";
            this.pnlWorkSpace.Size = new System.Drawing.Size(599, 356);
            this.pnlWorkSpace.TabIndex = 2;
            // 
            // btnNPCCreate
            // 
            this.btnNPCCreate.Location = new System.Drawing.Point(3, 3);
            this.btnNPCCreate.Name = "btnNPCCreate";
            this.btnNPCCreate.Size = new System.Drawing.Size(73, 39);
            this.btnNPCCreate.TabIndex = 0;
            this.btnNPCCreate.Text = "Create NPC";
            this.btnNPCCreate.UseVisualStyleBackColor = true;
            // 
            // btnNPCRemove
            // 
            this.btnNPCRemove.Location = new System.Drawing.Point(82, 3);
            this.btnNPCRemove.Name = "btnNPCRemove";
            this.btnNPCRemove.Size = new System.Drawing.Size(86, 39);
            this.btnNPCRemove.TabIndex = 1;
            this.btnNPCRemove.Text = "Remove NPC";
            this.btnNPCRemove.UseVisualStyleBackColor = true;
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpenDB});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(800, 25);
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
            // pnlWorkTools
            // 
            this.pnlWorkTools.BackColor = System.Drawing.Color.Maroon;
            this.pnlWorkTools.Location = new System.Drawing.Point(177, 0);
            this.pnlWorkTools.Name = "pnlWorkTools";
            this.pnlWorkTools.Size = new System.Drawing.Size(599, 46);
            this.pnlWorkTools.TabIndex = 2;
            // 
            // pnlNPC
            // 
            this.pnlNPC.BackColor = System.Drawing.Color.OliveDrab;
            this.pnlNPC.Controls.Add(this.btnNPCRemove);
            this.pnlNPC.Controls.Add(this.btnNPCCreate);
            this.pnlNPC.Location = new System.Drawing.Point(0, 0);
            this.pnlNPC.Name = "pnlNPC";
            this.pnlNPC.Size = new System.Drawing.Size(171, 47);
            this.pnlNPC.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.pnlWorkSpace);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.itemList);
            this.Name = "Form1";
            this.Text = "NPC Register";
            this.pnlTop.ResumeLayout(false);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.pnlNPC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox itemList;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlWorkSpace;
        private System.Windows.Forms.Button btnNPCCreate;
        private System.Windows.Forms.Panel pnlNPC;
        private System.Windows.Forms.Button btnNPCRemove;
        private System.Windows.Forms.Panel pnlWorkTools;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton tsOpenDB;
    }
}

