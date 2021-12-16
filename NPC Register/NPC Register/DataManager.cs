using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace NPC_Register
{
    class DataManager
    {
        SQLiteConnection connection;
        SQLiteCommand cmd;

        public DataSet data;
        public bool debugging;

        public DataManager (string connectionPath)
        {
            connection = new SQLiteConnection(connectionPath);
            cmd = connection.CreateCommand();
            debugging = true;
            OnProjectLoad();
        }

        public void CreateDatabase() {
            if (!File.Exists(connection.FileName)) {
                connection.Open();
                string createTables = File.ReadAllText(@"C:\Users\Nicholas Maver\Desktop\GitHub\GMCampaignManager\SQLite Commands\Table Creation.sql");
                var cmd = connection.CreateCommand();
                cmd.CommandText = createTables;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #region Project Load
        public void OnProjectLoad()
        {
            ///     `Database >> DataSet`
            if (!File.Exists(connection.FileName))
            {
                CreateDatabase();
            }
            else
            {
                connection.Open();
                // >Load Tables Here<
                data.Tables.Add(ReturnTable("NPCs"));
                data.Tables.Add(ReturnTable("ItemTemplates"));
                data.Tables.Add(ReturnTable("ItemInstances"));

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
        public void OnProjectSave() {
            if (!File.Exists(connection.FileName))
            {
                CreateDatabase();
                
            }
            else {
                //Surely there's a way to update the database without rewriting it
                //      :/
                File.Delete(connection.FileName);
                CreateDatabase();

                var tblDictionary = GetDictionary();

                connection.Open();

                #region Write To Tables

                // Write Order is >IMPORTANT< because of Table Dependencies
                // Always check Foreign Keys before making changes here

                WriteToItemTemplates(tblDictionary["ItemTemplates"]);
                WriteToCatalogueData(tblDictionary["CatalogueData"]);
                WriteToItemInstances(tblDictionary["ItemInstances"]);
                WriteToCatalogueEntries(tblDictionary["CatalogueEntries"]);
                WriteToLocations(tblDictionary["Locations"]);
                WriteToNPCs(tblDictionary["NPCs"]);
                WriteToHasAccessToCatalogue(tblDictionary["HasAccessToCatalogue"]);

                #endregion

                connection.Close();
            }
        }

        #region Write To Tables

        void WriteToItemTemplates(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO ItemTemplates(itemName) VALUES('" + row.ItemArray[1] + "');";
                SqliteNoQuery(query);
            }
        }

        void WriteToCatalogueData(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO CatalogueData (catalogueLabel) VALUES('" + row.ItemArray[1] + "');";
                SqliteNoQuery(query);
            }
        }

        void WriteToItemInstances(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO ItemInstances(instanceName, inventoryID) VALUES('" + row.ItemArray[1] + "', " + row.ItemArray[2] + ");";
                SqliteNoQuery(query);
            }
        }

        void WriteToCatalogueEntries(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO CatalogueEntries(catalogueID, itemID, price) VALUES(" + row.ItemArray[0] + ", " + row.ItemArray[1] + ", '" + row.ItemArray[2] + "');";
                SqliteNoQuery(query);
            }
        }

        void WriteToLocations(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO Locations(locationName, parentLocationID, inventoryItemID) VALUES ('" + row.ItemArray[1] + "', " + row.ItemArray[2] + ", " + row.ItemArray[3] + ");";
                SqliteNoQuery(query);
            }
        }

        void WriteToNPCs(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO NPCs(npcName, currentLocation, inventoryItemID) VALUES('" + row.ItemArray[1] + "', " + row.ItemArray[2] + ", " + row.ItemArray[3] + ");";
                SqliteNoQuery(query);
            }
        }

        void WriteToHasAccessToCatalogue(DataTable table) {
            foreach (DataRow row in table.Rows) {
                var query = "INSERT INTO HasAccessToCatalogue(npcID, catalogueID) VALUES(" + row.ItemArray[0] + ", " + row.ItemArray[1] +  ");";
                SqliteNoQuery(query);
            }
        }

        #endregion

        private void SqliteNoQuery(string command) {
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
        }

        Dictionary<string, DataTable> GetDictionary() {
            Dictionary<string, DataTable> dic = new Dictionary<string, DataTable>();
            foreach (DataTable table in data.Tables) {
                dic.Add(table.TableName, table);
            }
            return dic;
        }

        #endregion
    }
}
