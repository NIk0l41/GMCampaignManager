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
            string[] npcNames = new string[publicData.Tables[tableIndex["NPCs"]].Rows.Count];
            foreach (string name in npcNames) {
                itemList.Items.Add(name);
            }
        }
        #endregion

        private void pnlWorkSpace_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Update Log Commands

        UpdateLog CreateInventoryInstance(string ownerName) {
            var valueIndex = new Dictionary<int, object>();
            valueIndex.Add(1, "_inventory-" + ownerName);
            var instance = new UpdateLog("", "ItemInstances", UpdateLogType.CREATE);
            return instance;
        }

        UpdateLog CreateNpcInstance(string npcName) {
            var valueIndex = new Dictionary<int, object>();
            valueIndex.Add(1, npcName);
            valueIndex.Add(3, rowIndexes[tableIndex["NPCs"]]["_inventory-"]);
            var instance = new UpdateLog("", "NPCs", UpdateLogType.CREATE, valueIndex);
            return instance;
        }

        object GetPrimaryKey() {
            return null;
        }

        #endregion

        #region UI Commands

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
            SetupProject();
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
            // Ooo spicy
            // Prototype Data Manager
            /// 1) Create Inventory Item
            // Since all ID based PKs run on autoincrement, the update log's
            // Primary Key attribute can be null.
            var logs = new UpdateLog[2];
            logs[0] = CreateInventoryInstance("Mr Shoebox");
            /// 2) Create NPC Entry
            /// ...
        }

        #endregion
    }
}
