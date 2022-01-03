using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sqlite_Open_Database_Connection
{
    public partial class Form1 : Form
    {

        public const string path = @"C:\Users\Nicholas Maver\Documents\CSSQLtmp";
        public const string filePath = path + @"\data.db";
        public const string conPath = @"URI=file:" + filePath;

        SQLiteConnection conn;
        bool isOpenConnection;

        public Form1()
        {
            InitializeComponent();
            conn = new SQLiteConnection(conPath);
            isOpenConnection = false;
        }

        private void btnCloseConn_Click(object sender, EventArgs e)
        {
            conn.Close();
            isOpenConnection = false;
        }

        private void btnOpenConn_Click(object sender, EventArgs e)
        {
            conn.Open();
            isOpenConnection = true;
        }

        private void btnReadNpc_Click(object sender, EventArgs e)
        {
            if (isOpenConnection)
                DisplayTableToGrid("NPCs");
        }

        private void btnReadItemInstances_Click(object sender, EventArgs e)
        {
            if (isOpenConnection)
                DisplayTableToGrid("ItemInstances");
        }

        private void DisplayTableToGrid(string tableName) {
            var table = GetTableData(tableName);
            DataSet set = new DataSet();
            set.Tables.Add(table);
            dataGridView1.DataSource = set;
            dataGridView1.DataMember = set.Tables[0].TableName;
        }

        /// <summary>
        /// Pretty much stolen from the Database Priest lmao
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private DataTable GetTableData(string tableName) {
            //Ensure that the function that calls this one opens and closes the connection!
            if (string.IsNullOrEmpty(tableName.Trim()))
                return null;
            var output = new DataTable(tableName);

            try
            {
                var adapter = new SQLiteDataAdapter("SELECT * FROM " + tableName, conn);
                adapter.Fill(output);
                adapter.Dispose();
                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}
