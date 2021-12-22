using System.Collections.Generic;
using System.Data;

namespace NPC_Register
{
    /// <summary>
    /// May be Obselete. Here just in case
    /// </summary>
    class TableData
    {
        public Dictionary<string, int> tblIndex;
        public DataTable tbl;

        public TableData(DataTable Table, Dictionary<string, int> TableIndex)
        {
            tblIndex = TableIndex;
            tbl = Table;
        }
    }
}
