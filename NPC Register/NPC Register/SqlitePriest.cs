using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Register
{
    public class SqlitePriest
    {
        SQLiteConnection conn;
        bool isOpenConnection;

        public SqlitePriest(string connectionPath) {
            conn = new SQLiteConnection(connectionPath);
            isOpenConnection = false;
        }

        public void OpenConnection() {
            if (!isOpenConnection) {
                conn.Open();
                isOpenConnection = true;
            }
        }

        public void CloseConnection() {
            if (isOpenConnection) {
                conn.Close();
                isOpenConnection = false;
            }
        }

        public void SqliteCommand(string noQuery) {
            var cmd = conn.CreateCommand();
            cmd.CommandText = noQuery;
            cmd.ExecuteNonQuery();
        }

        public DataTable SqliteQuery(string query) {
            var result = new DataTable();
            var adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(result);
            adapter.Dispose();
            return result;
        }

        #region Dependent Commands
        public void ClearDbContents() {
            SqliteCommand("DELETE FROM `Notes` WHERE noteID IS NOT NULL;");
            SqliteCommand("DELETE FROM `HasAccessToCatalogue` WHERE npcName IS NOT NULL;");
            SqliteCommand("DELETE FROM `NPCs` WHERE npcName IS NOT NULL;");
            SqliteCommand("DELETE FROM `Locations` WHERE locationID IS NOT NULL;");
            SqliteCommand("DELETE FROM `CatalogueEntries` WHERE catalogueID IS NOT NULL;");
            SqliteCommand("DELETE FROM `ItemInstances` WHERE instanceID IS NOT NULL;");
            SqliteCommand("DELETE FROM `CatalogueData` WHERE catalogueID IS NOT NULL;");
            SqliteCommand("DELETE FROM `itemTemplates` WHERE itemID IS NOT NULL;");
        }
        #endregion
    }
}
