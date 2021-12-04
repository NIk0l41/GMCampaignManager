using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace NPC_Register
{
    public partial class Form1 : Form
    {   
        const string path = @"C:\Users\Nicholas Maver\Documents\CSSQLtmp";
        const string filePath = path + @"\data.db";
        const string conPath = @"URI=file:" + filePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void pnlWorkSpace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsCreateDB_Click(object sender, EventArgs e)
        {
            
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            bool debugging = true;

            ///Database Creation
            if (debugging && File.Exists(filePath)) {
                File.Delete(filePath);
            }

            ///SQLite Connection
            //https://zetcode.com/csharp/sqlite/
            //Creates the Database if there is none, then establishes a connection with it.
            SQLiteConnection con = new SQLiteConnection(conPath);
            con.Open();

            ///Database Structure.
            string createTblNpc = @"CREATE TABLE NPC(
                                    npcID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    npcName varchar(255) NOT NULL
                                    );";
            //See https://sqlite.org/autoinc.html for more information on AutoIncrement
            //This article doesn't recommend its use, but for now it'll do

            ///SQLite Commands
            SQLiteCommand cmd = new SQLiteCommand(con);

            cmd.CommandText = createTblNpc;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO NPC(npcName) VALUES('Johnny');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO NPC(npcName) VALUES('Savaal');";
            cmd.ExecuteNonQuery();

            MessageBox.Show("Executed Non Queries");

            ///SQLite Close Connection
            con.Dispose();

        }

        private void tsOpenDB_Click(object sender, EventArgs e)
        {
            ///SQLite Connection
            SQLiteConnection con = new SQLiteConnection(conPath);
            con.Open();

            ///SQLiteCommands
            SQLiteCommand cmd = new SQLiteCommand(con);
            string query = "SELECT * FROM NPC";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
            DataSet set = new DataSet();
            adapter.Fill(set, "NPC");
            //No need to keep the connection up longer than needed.
            con.Close();
            grid.DataSource = set;
            grid.DataMember = "NPC";
            //set.Tables[0].Rows[0].ItemArray[1].ToString();
            //DataTable npc = set.Tables[0];

        }

    }
}
