using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace NPC_Register
{
    public class DatabasePriest
    {
        SQLiteConnection connection;
        SQLiteCommand cmd;

        Dictionary<string, int> tableIndex;
        Dictionary<string, int>[] rowIndexes; 



        public DataSet data;

        public DatabasePriest(string connectionPath) {
            connection = new SQLiteConnection(connectionPath);
            cmd = connection.CreateCommand();
        }

        public void SetIndexes(Dictionary<string, int> tableIndex, Dictionary<string, int>[] rowIndexes) {
            this.tableIndex = tableIndex;
            this.rowIndexes = rowIndexes;
        }

        #region On Project Load
        public void ReadDatabase()
        {
            if (!File.Exists(connection.FileName))
            {
                // Do something idk
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
        public void OnProjectSave(bool specificSave)
        {
            if (specificSave)
            {

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

        #endregion

    }
}
