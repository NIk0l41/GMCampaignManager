using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace NPC_Register
{
    public class DatabasePriest
    {
        readonly SQLiteConnection connection;
        readonly SQLiteCommand cmd;

        int updatesCompleted;

        public DataSet data;

        public DatabasePriest(string databasePath)
        {
            updatesCompleted = 0;
            connection = new SQLiteConnection(@"URI=file:" + databasePath);
            cmd = connection.CreateCommand();
        }

        #region On Project Load

        /// <summary>
        /// DataTable containing 'query' results
        /// </summary>
        /// <param name="query">SQLite Query</param>
        /// <returns>SQL Query Results</returns>
        DataTable SqliteQuery(string query) {
            try {
                var output = new DataTable();
                var adapter = new SQLiteDataAdapter(query, connection);
                adapter.Fill(output);
                adapter.Dispose();
                return output;
            }
            catch {
                return null;
            }
        }
        #endregion

        #region Project Save
        public void SaveProject(Dictionary<string, int> tableIndex, List<UpdateLog> logs)
        {
            connection.Open();
            if (logs.Count == updatesCompleted) {
                connection.Close();
                return;
            }
            for (int i = updatesCompleted; i < logs.Count; i++) {
                string command;
                var log = logs[i];

                switch (logs[i].updateType) {
                    case UpdateLogType.DELETE:
                        command = "DELETE FROM `" + log.tableName +"` WHERE " + GetPkConditions(tableIndex, log);
                        break;
                    case UpdateLogType.UPDATE:
                        command = "UPDATE `" + log.tableName + "` SET ";
                        foreach (KeyValuePair<int, object> pair in log.valueIndex) {
                            command += GetAttributeValue(log.tableName, pair, tableIndex);
                        }
                        command = command.Remove(command.Length - 2, 1);
                        command += "WHERE " + GetPkConditions(tableIndex, log);
                        break;
                    case UpdateLogType.CREATE:
                        command = "INSERT INTO " + log.tableName + " (";
                        foreach (KeyValuePair<int, object> pair in log.valueIndex) {
                            command += GetAttributeValue(log.tableName, pair, tableIndex);
                        }
                        command = command.Remove(command.Length - 2, 1);
                        command += ");";
                        break;
                }

                ///LMAO
                ///I know this is obsolete now, but I didn't even run an SQLiteNoQuery()
                ///NO change would've been made had I run this script.
                /// bruh.
                updatesCompleted++;
            }

            connection.Close();
        }

        string GetColumnName(string tblName, int colNumber, Dictionary<string, int> tableIndex) {
            string output;
            return output = data.Tables[tableIndex[tblName]].Columns[colNumber].ColumnName;
        }

        string GetAttributeValue(string tblName, KeyValuePair<int, object> pair, Dictionary<string, int> tableIndex) {
            string output = "";
            output += GetColumnName(tblName, pair.Key, tableIndex) + " = " + pair.Value + ", ";
            return output;
        }

        string GetPkConditions(Dictionary<string, int> tableIndex, UpdateLog log) {
            string output;
            if (log.tableName == "CatalogueEntries") {
                string[] pks = log.primaryKey.Split(new char[] { ',', ' ' });
                output = data.Tables[tableIndex[log.tableName]].Columns[0].ColumnName + " = " + pks[0] +"AND";
                output += data.Tables[tableIndex[log.tableName]].Columns[1].ColumnName + " = " + pks[1] + ";";
            }
            else {
                output = data.Tables[tableIndex[log.tableName]].Columns[0].ColumnName + " = " + log.primaryKey;
            }
            return output;
        }

        #endregion

        private void SqliteNoQuery(string command) {
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
        }

        public void CreateDatabase() {
            if (!File.Exists(connection.FileName))
            {
                connection.Open();
                string createTables = File.ReadAllText(@"C:\Users\Nicholas Maver\Desktop\GitHub\GMCampaignManager\SQLite Commands\Table Creation.sql");
                SqliteNoQuery(createTables);
                connection.Close();
            }
        }

        public void DeleteDatabase(string filePath) {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }
        }

    }
}
