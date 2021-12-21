using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace NPC_Register
{
    public class DatasetEngineer
    {
        DataSet data;

        public DatasetEngineer(DataSet data) {
            this.data = data;

        }
    }
}
