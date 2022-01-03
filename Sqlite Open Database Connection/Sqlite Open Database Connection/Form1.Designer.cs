
namespace Sqlite_Open_Database_Connection
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOpenConn = new System.Windows.Forms.Button();
            this.btnCloseConn = new System.Windows.Forms.Button();
            this.btnReadNpc = new System.Windows.Forms.Button();
            this.btnReadItemInstances = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnOpenConn
            // 
            this.btnOpenConn.Location = new System.Drawing.Point(12, 178);
            this.btnOpenConn.Name = "btnOpenConn";
            this.btnOpenConn.Size = new System.Drawing.Size(99, 23);
            this.btnOpenConn.TabIndex = 1;
            this.btnOpenConn.Text = "Open Conneciton";
            this.btnOpenConn.UseVisualStyleBackColor = true;
            this.btnOpenConn.Click += new System.EventHandler(this.btnOpenConn_Click);
            // 
            // btnCloseConn
            // 
            this.btnCloseConn.Location = new System.Drawing.Point(12, 207);
            this.btnCloseConn.Name = "btnCloseConn";
            this.btnCloseConn.Size = new System.Drawing.Size(99, 23);
            this.btnCloseConn.TabIndex = 2;
            this.btnCloseConn.Text = "Close Connection";
            this.btnCloseConn.UseVisualStyleBackColor = true;
            this.btnCloseConn.Click += new System.EventHandler(this.btnCloseConn_Click);
            // 
            // btnReadNpc
            // 
            this.btnReadNpc.Location = new System.Drawing.Point(118, 178);
            this.btnReadNpc.Name = "btnReadNpc";
            this.btnReadNpc.Size = new System.Drawing.Size(134, 23);
            this.btnReadNpc.TabIndex = 3;
            this.btnReadNpc.Text = "Read NPC Table";
            this.btnReadNpc.UseVisualStyleBackColor = true;
            this.btnReadNpc.Click += new System.EventHandler(this.btnReadNpc_Click);
            // 
            // btnReadItemInstances
            // 
            this.btnReadItemInstances.Location = new System.Drawing.Point(118, 207);
            this.btnReadItemInstances.Name = "btnReadItemInstances";
            this.btnReadItemInstances.Size = new System.Drawing.Size(134, 38);
            this.btnReadItemInstances.TabIndex = 4;
            this.btnReadItemInstances.Text = "Read Item Instance Table";
            this.btnReadItemInstances.UseVisualStyleBackColor = true;
            this.btnReadItemInstances.Click += new System.EventHandler(this.btnReadItemInstances_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReadItemInstances);
            this.Controls.Add(this.btnReadNpc);
            this.Controls.Add(this.btnCloseConn);
            this.Controls.Add(this.btnOpenConn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOpenConn;
        private System.Windows.Forms.Button btnCloseConn;
        private System.Windows.Forms.Button btnReadNpc;
        private System.Windows.Forms.Button btnReadItemInstances;
    }
}

