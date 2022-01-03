using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace NPC_Register
{
    public partial class Form1 : Form
    {
        public const string path = @"C:\Users\Nicholas Maver\Documents\CSSQLtmp";
        public const string filePath = path + @"\data.db";
        public const string conPath = @"URI=file:" + filePath;

        ///Agents
        public DatabasePriest priestSylas;
        public Indexer indexerMiles;
        public DatasetEngineer engineerLicia;

        ///Data Objects
        // Global Dataset
        public DataSet publicData;

        // Global TableIndex
        public Dictionary<string, int> tableIndex;
        // Global RowIndexes
        public Dictionary<string, int>[] rowIndexes;

        // Update Logs
        public List<UpdateLog> updateLogs;


        public Form1()
        {
            InitializeComponent();

            ///Variable Delcaration
            publicData = new DataSet();

            priestSylas = new DatabasePriest(filePath);

            indexerMiles = new Indexer();
            engineerLicia = new DatasetEngineer();

        }

        #region Setup Project
        public void SetupProject() {
            publicData = priestSylas.ReadDatabase();
            tableIndex = indexerMiles.GetTableIndex(publicData);
            rowIndexes = indexerMiles.GetRowIndexes(publicData);
        }

        #endregion

        #region Refresh UI Components After Data Change
        void RefreshUiComponents() {
            RefreshItemList();
        }

        void RefreshItemList() {
            SqlitePriest priestJulia = new SqlitePriest(conPath);
            var locationTable = priestJulia.SqliteQuery("SELECT * FROM NPCs");
            string[] locationNameList = new string[locationTable.Rows.Count];
            for (int i = 0; i < locationTable.Rows.Count; i++) {
                locationNameList[i] = locationTable.Rows[i].ItemArray[1].ToString();
            }
            foreach (string name in locationNameList) {
                hierarchy1.Items.Add(name);
            }
        }
        #endregion

        #region SQL Command Constructors


        #endregion

        #region UI Commands

        #region Hierarchy Commands

        private void hierarchy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlitePriest priestGelignite = new SqlitePriest(conPath);
            var npcTable = priestGelignite.SqliteNoQuery("SELECT * FROM NPCs WHERE");
        }

        private void hierarchy2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Tool Strip Items
        private void tsCreateDB_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string deleteMessage = "Database Exists.";
                string deleteCaption = "Database found, would you like to delete it and create a new one?";
                DialogResult deleteDb =  MessageBox.Show(deleteMessage, deleteCaption, MessageBoxButtons.YesNo);
                if (deleteDb == DialogResult.Yes) {
                    File.Delete(filePath);
                    priestSylas.CreateDatabase();
                    SetupProject();
                }
            }
        }

        private void tsOpenDB_Click(object sender, EventArgs e)
        {
            //SetupProject();
            SqlitePriest priestDyson = new SqlitePriest(conPath);
            priestDyson.OpenConnection();
            RefreshItemList();
        }

        #region Load Test Databases
        private void tsDb1_Click(object sender, EventArgs e)
        {
            priestSylas.LoadSqlScript(File.ReadAllText(@"C:\Users\Nicholas Maver\Desktop\GitHub\GMCampaignManager\SQLite Commands\testDB1.sql"));
            publicData = priestSylas.ReadDatabase();
            SetupProject();
        }
        #endregion

        #endregion

        private void btnNpcCreate_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

    }
}
