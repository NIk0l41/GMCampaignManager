using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NPC_Register
{
    public enum hierarchyViewFilter {
        LOCATION,
        NPC,
        ITEMINSTANCE,
        ITEMTEMPLATE,
        CATALOGUE
    }

    // Just comparing the types of data found within the hierarchies...
    public enum hierarchy2ItemTypes {
        LOCATION,
        NPC, 
        ITEMINSTANCE,
        CATALOGUE
    }

    public partial class Form1 : Form
    {
        public const string path = @"C:\Users\Nicholas Maver\Documents\CSSQLtmp";
        public const string filePath = path + @"\data.db";
        public const string conPath = @"URI=file:" + filePath;

        public SqlitePriest priestSylas;

        hierarchyViewFilter h1ViewFilter;

        /// h1IndexNo <-> sqlPK
        Dictionary<int, int> h1ItemIndex;

        /// h2IndexNo <-> sqlPK
        Dictionary<int, int> h2ItemIndex;
        Dictionary<int, int> h2NpcIndex;
        Dictionary<int, int> h2CatalogueIndex;
        List<int> h2IndexTracker;

        // Note Movement in Workspace
        Point initMousePos;
        bool mouseDown;
        bool mouseMove;

        

        public Form1()
        {
            InitializeComponent();
            priestSylas = new SqlitePriest(conPath);

            h1ViewFilter = hierarchyViewFilter.LOCATION;
        }

        #region Setup Project
        public void SetupProject() {
            /// 1) Load Hierarchy 1 According to View Type
            /// 2) Load Hierarchy 2 According to H1 Selected Item
            /// 3) Load Workspace According to H2 Selected Item
        }

        #endregion

        #region Refresh UI Components After Data Change
        void RefreshUiComponents() {
            OnHierarchy1DataChange();
        }

        /// <summary>
        /// Called to Refresh Hierarchy 1
        /// </summary>
        public void OnHierarchy1DataChange() {
            // Clear old data holders
            hierarchy1.Items.Clear();
            h1ItemIndex = new Dictionary<int, int>();
            string query = "";
            // Determing Appropriate Query
            switch (h1ViewFilter) {
                case hierarchyViewFilter.LOCATION:
                    query += "SELECT locationID, locationName FROM `Locations`;";
                    break;
            }
            // Retrieve Query Results
            var results = priestSylas.SqliteQuery(query);
            // Index and Display New Data
            // (This is assuming PK in Row 1 and Display String in Row 2)
            for (int row = 0; row < results.Rows.Count; row++) {
                h1ItemIndex.Add(row, Convert.ToInt32(results.Rows[row].ItemArray[0]));
                hierarchy1.Items.Add(results.Rows[row].ItemArray[1]);
            }
        }

        /// <summary>
        /// Called to Refresh Hierarchy 2
        /// </summary>
        public void OnHierarchy2DataChange() {
            // Clear old data holders
            hierarchy2.Items.Clear();
            h2ItemIndex = new Dictionary<int, int>();
            h2NpcIndex = new Dictionary<int, int>();
            h2CatalogueIndex = new Dictionary<int, int>();
            h2IndexTracker = new List<int>();
            // Determine Hierarchy 1 Selected Item Primary Key
            int pkID = h1ItemIndex[hierarchy1.SelectedIndex];
            // Add Header to Hierarchy
            var newIndexNum = Hierarchy2Add(">>" + hierarchy1.SelectedItem.ToString() + "<<");
            // Determine Appropriate Query Collection
            var queries = Hierarchy2Query(pkID);
            // NB --> There needs to be a way to organise the queries generated from this function.
            //      I can hard code it in for the time being, but when we change how
            //      the hierarchyViewFilter interacts with hierarchy2, we need to update this script.

            var itemInstances = priestSylas.SqliteQuery(queries[0]);
            if (itemInstances.Rows.Count != 0)
                newIndexNum = Hierarchy2Add("-Items-");
            for (int item = 0; item < itemInstances.Rows.Count; item++) {
                h2IndexTracker.Add(newIndexNum);
                h2ItemIndex.Add(newIndexNum, Convert.ToInt32(itemInstances.Rows[item].ItemArray[0]));
                newIndexNum = Hierarchy2Add(itemInstances.Rows[item].ItemArray[1]);
            }

            var npcs = priestSylas.SqliteQuery(queries[1]);
            if (npcs.Rows.Count != 0)
                newIndexNum = Hierarchy2Add("-NPCs-");
            for (int npc = 0; npc < npcs.Rows.Count; npc++) {
                h2IndexTracker.Add(newIndexNum);
                h2NpcIndex.Add(newIndexNum, Convert.ToInt32(npcs.Rows[npc].ItemArray[0]));
                newIndexNum = Hierarchy2Add(npcs.Rows[npc].ItemArray[1]);
            }
        }

        int Hierarchy2Add(object item) {
            hierarchy2.Items.Add(item);
            return hierarchy2.Items.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkID"></param>
        /// <returns></returns>
        List<string> Hierarchy2Query(int pkID) {
            var queries = new List<string>();
            // Query Collections for different data types
            switch (h1ViewFilter) {
                case hierarchyViewFilter.LOCATION:
                    queries.Add("SELECT * FROM `ItemInstances` WHERE inventoryID = (SELECT inventoryItemID FROM `Locations` WHERE locationID = " + pkID + ");");
                    queries.Add("SELECT * FROM `NPCs` WHERE currentLocation = " + pkID);
                    break;                    
            }
            return queries;
        }

        #endregion

        #region UI Commands

        #region Hierarchy Commands

        private void hierarchy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hierarchy1.SelectedItem != null) {
                OnHierarchy2DataChange();
            }
            else {
                // If the hierarchy1 selection is blank, and there are still items being shown in hierarchy 2,
                // clear the hierarchy.  
                if (hierarchy2.Items.Count != 0) {
                    hierarchy2.Items.Clear();
                    h2ItemIndex = new Dictionary<int, int>();
                    h2NpcIndex = new Dictionary<int, int>();
                    h2CatalogueIndex = new Dictionary<int, int>();
                    h2IndexTracker = new List<int>();
                }
            }
        }

        private void hierarchy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (h2IndexTracker.Contains(hierarchy2.SelectedIndex) && hierarchy2.SelectedItem != null) {
                // Load Workspace Content
            }
        }
        #endregion

        #region Tool Strip Items
        private void tsCreateDB_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string deleteMessage = "Database Exists.";
                string deleteCaption = "Database found, would you like to clear its contents?";
                DialogResult deleteDb = MessageBox.Show(deleteMessage, deleteCaption, MessageBoxButtons.YesNo);
                if (deleteDb == DialogResult.Yes)
                {
                    priestSylas.ClearDbContents();
                    SetupProject();
                }
            }
            else {
                priestSylas.OpenConnection();
            }
        }

        private void tsOpenDB_Click(object sender, EventArgs e)
        {
            priestSylas.OpenConnection();
            RefreshUiComponents();
        }

        #region Load Test Databases
        private void tsDb1_Click(object sender, EventArgs e)
        {
            //priestSylas.LoadSqlScript(File.ReadAllText(@"C:\Users\Nicholas Maver\Desktop\GitHub\GMCampaignManager\SQLite Commands\testDB1.sql"));
            //publicData = priestSylas.ReadDatabase();
            SetupProject();
        }
        #endregion

        #endregion

        #endregion

        private void pnlNoteMoveTest_MouseDown(object sender, MouseEventArgs e)
        {
            lblNoteIsDown.Text = "True";
        }

        private void pnlNoteMoveTest_MouseUp(object sender, MouseEventArgs e)
        {
            lblNoteIsDown.Text = "False";
        }

        private void pnlNoteMoveTest_MouseMove(object sender, MouseEventArgs e)
        {
            lblNoteIsMove.Text = "True";
        }

        private void pnlNoteMoveTest_MouseHover(object sender, EventArgs e)
        {
            lblNoteIsMove.Text = "False";
        }
    }

}
