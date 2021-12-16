using System;
using System.Data;
using System.Data.SQLite;

namespace NPC_Register
{
    class DataWorker
    {

        SQLiteConnection connection;
        public DataSet data;

        public DataWorker(SQLiteConnection connection)
        {
            this.connection = connection;
            OnProjectLoad();
        }
        
        public void OnProjectLoad() {
            ///     `Database >> DataSet`
            connection.Open();
            data.Tables.Add(ReturnTable("NPCs"));
            data.Tables.Add(ReturnTable("ItemTemplates"));
            data.Tables.Add(ReturnTable("ItemInstances"));
            connection.Close();
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



        public class Writer
        {
            public Writer() {
                
            }

            public void CreateNpc() {
                
            }

            public void CreateItem() {
                
            }
        }
    }
}
