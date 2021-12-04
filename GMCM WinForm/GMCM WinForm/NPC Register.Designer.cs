
namespace GMCM_WinForm
{
    partial class NPC_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPC_Register));
            this.listNPC = new System.Windows.Forms.ListBox();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsBtnOpenDb = new System.Windows.Forms.ToolStripButton();
            this.tsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // listNPC
            // 
            this.listNPC.FormattingEnabled = true;
            this.listNPC.Location = new System.Drawing.Point(12, 122);
            this.listNPC.Name = "listNPC";
            this.listNPC.Size = new System.Drawing.Size(235, 316);
            this.listNPC.TabIndex = 0;
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOpenDb});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(800, 25);
            this.tsTop.TabIndex = 1;
            this.tsTop.Text = "toolStrip1";
            // 
            // pnlTools
            // 
            this.pnlTools.BackColor = System.Drawing.Color.Goldenrod;
            this.pnlTools.Location = new System.Drawing.Point(12, 40);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(776, 69);
            this.pnlTools.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(253, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 316);
            this.panel1.TabIndex = 3;
            // 
            // tsBtnOpenDb
            // 
            this.tsBtnOpenDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnOpenDb.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpenDb.Image")));
            this.tsBtnOpenDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenDb.Name = "tsBtnOpenDb";
            this.tsBtnOpenDb.Size = new System.Drawing.Size(58, 22);
            this.tsBtnOpenDb.Text = "Open DB";
            // 
            // NPC_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.listNPC);
            this.Name = "NPC_Register";
            this.Text = "NPC_Register";
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listNPC;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton tsBtnOpenDb;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Panel panel1;
    }
}