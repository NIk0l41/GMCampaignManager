using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Register
{
    class SqlitePriest
    {
        SQLiteConnection conn;
        bool isOpenConnection;

        public SqlitePriest(string connectionPath) {
            conn = new SQLiteConnection(connectionPath);
            isOpenConnection = false;
        }

        public void OpenConnection() {
            if (!isOpenConnection)
                conn.Open();
        }

        public void CloseConnection() {
            if (isOpenConnection)
                conn.Close();
        }

        public void SqliteNoQuery(string noQuery) {
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
    }
}
