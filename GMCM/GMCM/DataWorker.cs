using System;
using System.Data;
using System.Data.SQLite;

namespace GMCM
{
    class DataWorker
    {

        SQLiteConnection connection;
        public DataSet data;

        public DataWorker(SQLiteConnection connection)
        {
            this.connection = connection;
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
            string query = "SELECT * FROM " + tableName;
            DataTable output = new DataTable(tableName);

            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
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
