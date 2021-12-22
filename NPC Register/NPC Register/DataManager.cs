using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace NPC_Register
{
    class DataManager
    {
        readonly SQLiteConnection connection;
        readonly SQLiteCommand cmd;

        public DataSet data;

        //Dictionary Mapping
        public Dictionary<string, int> tableIndex;
        public Dictionary<string, int>[] rowIndexes;


        public bool debugging;

        public DataManager(string connectionPath, bool debugging)
        {
            //Intialise Variables
            this.debugging = debugging;

            connection = new SQLiteConnection(connectionPath);
            cmd = connection.CreateCommand();

            tableIndex = GetTableIndex();
            rowIndexes = GetRowIndexes();

            //Begin Managing
            OnProjectLoad();
        }

        public void CreateDatabase()
        {
            if (!File.Exists(connection.FileName))
            {
                connection.Open();
                string createTables = File.ReadAllText(@"C:\Users\Nicholas Maver\Desktop\GitHub\GMCampaignManager\SQLite Commands\Table Creation.sql");
                var cmd = connection.CreateCommand();
                cmd.CommandText = createTables;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #region Index Creation

        Dictionary<string, int> GetTableIndex()
        {
            var tblIndex = new Dictionary<string, int>();
            for (int i = 0; i < data.Tables.Count; i++)
            {
                tblIndex.Add(data.Tables[i].TableName, i);
            }
            return tblIndex;
        }

        Dictionary<string, int>[] GetRowIndexes()
        {
            var rwIndexes = new Dictionary<string, int>[data.Tables.Count];
            for (int i = 0; i < data.Tables.Count; i++)
            {
                rwIndexes[i] = GetRowIndex(i);
            }
            return rwIndexes;
        }

        Dictionary<string, int> GetRowIndex(int tblIndex)
        {
            var rwIndex = new Dictionary<string, int>();
            // If a Tables PK is not found in the first column, create a new `if`
            // statement. Like CatalogueEntries.
            if (data.Tables[tblIndex].TableName == "CatalogueEntries")
            {
                for (int i = 0; i < data.Tables[tblIndex].Rows.Count; i++)
                {
                    // Since this tables PK is two attributes, it is combinted
                    // then seperated by a comma
                    rwIndex.Add(data.Tables[tblIndex].Rows[i].ItemArray[0] + ", "
                        + data.Tables[tblIndex].Rows[i].ItemArray[1], i);
                }
            }
            //If a Table PK is found within the first column.
            else
            {
                for (int i = 0; i < data.Tables[tblIndex].Rows.Count; i++)
                {
                    rwIndex.Add(data.Tables[tblIndex].Rows[i].ItemArray[0].ToString(), i);
                }
            }
            return rwIndex;
        }

        #endregion

        #region Project Load
        public void OnProjectLoad()
        {
            if (!File.Exists(connection.FileName))
            {
                CreateDatabase();
            }
            else
            {
                connection.Open();

                #region Load Tables

                data.Tables.Add(ReturnTable("ItemTemplates"));
                data.Tables.Add(ReturnTable("CatalogueData"));
                data.Tables.Add(ReturnTable("ItemInstances"));
                data.Tables.Add(ReturnTable("CatalogueEntries"));
                data.Tables.Add(ReturnTable("NPCs"));
                data.Tables.Add(ReturnTable("Locations"));
                data.Tables.Add(ReturnTable("HasAccessToCatalogue"));

                #endregion

                connection.Close();
            }
        }

        public DataTable ReturnTable(string tableName)
        {
            if (string.IsNullOrEmpty(tableName.Trim()))
                return null;
            var query = "SELECT * FROM " + tableName;
            var output = new DataTable(tableName);

            try
            {
                var adapter = new SQLiteDataAdapter(query, connection);
                adapter.Fill(output);
                adapter.Dispose();
            }
            catch
            {
                return null;
            }
            return output;
        }
        #endregion

        #region Project Save
        public void OnProjectSave()
        {
            if (!File.Exists(connection.FileName))
            {
                CreateDatabase();
                WriteToTables();
            }
            else
            {
                //Surely there's a way to update the database without rewriting it
                //      :/
                File.Delete(connection.FileName);
                CreateDatabase();

                WriteToTables();
            }
        }

        #region Write To Tables Functions

        void WriteToItemTemplates(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO ItemTemplates(itemName) VALUES('" + row.ItemArray[1] + "');";
                SqliteNoQuery(query);
            }
        }

        void WriteToCatalogueData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO CatalogueData (catalogueLabel) VALUES('" + row.ItemArray[1] + "');";
                SqliteNoQuery(query);
            }
        }

        void WriteToItemInstances(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO ItemInstances(instanceName, inventoryID) VALUES('" + row.ItemArray[1] + "', " + row.ItemArray[2] + ");";
                SqliteNoQuery(query);
            }
        }

        void WriteToCatalogueEntries(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO CatalogueEntries(catalogueID, itemID, price) VALUES(" + row.ItemArray[0] + ", " + row.ItemArray[1] + ", '" + row.ItemArray[2] + "');";
                SqliteNoQuery(query);
            }
        }

        void WriteToLocations(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO Locations(locationName, parentLocationID, inventoryItemID) VALUES ('" + row.ItemArray[1] + "', " + row.ItemArray[2] + ", " + row.ItemArray[3] + ");";
                SqliteNoQuery(query);
            }
        }

        void WriteToNPCs(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO NPCs(npcName, currentLocation, inventoryItemID) VALUES('" + row.ItemArray[1] + "', " + row.ItemArray[2] + ", " + row.ItemArray[3] + ");";
                SqliteNoQuery(query);
            }
        }

        void WriteToHasAccessToCatalogue(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var query = "INSERT INTO HasAccessToCatalogue(npcID, catalogueID) VALUES(" + row.ItemArray[0] + ", " + row.ItemArray[1] + ");";
                SqliteNoQuery(query);
            }
        }

        #endregion

        void WriteToTables()
        {

            connection.Open();

            // Write Order is >IMPORTANT< because of Table Dependencies
            // Always check Foreign Keys before making changes here

            WriteToItemTemplates(data.Tables[tableIndex["ItemTemplates"]]);
            WriteToCatalogueData(data.Tables[tableIndex["CatalogueData"]]);
            WriteToItemInstances(data.Tables[tableIndex["ItemInstances"]]);
            WriteToCatalogueEntries(data.Tables[tableIndex["CatalogueEntries"]]);
            WriteToLocations(data.Tables[tableIndex["Locations"]]);
            WriteToNPCs(data.Tables[tableIndex["NPCs"]]);
            WriteToHasAccessToCatalogue(data.Tables[tableIndex["HasAccessToCatalogue"]]);

            connection.Close();
        }

        private void SqliteNoQuery(string command)
        {
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
        }

        #endregion
    }
}
