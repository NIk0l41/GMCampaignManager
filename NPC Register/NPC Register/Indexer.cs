using System.Collections.Generic;
using System.Data;

namespace NPC_Register
{
    public class Indexer
    {
        // tableIndex[i] == entryIndexes[i] == attrIndexes[i]

        /// <summary>
        /// Map the Table Names to their Position in the DataSet
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetTableIndex(DataSet dataSet)
        {
            var tblIndex = new Dictionary<string, int>();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                tblIndex.Add(dataSet.Tables[i].TableName, i);
            }
            return tblIndex;
        }

        /// <summary>
        /// Map the entire DataSet's entries
        /// </summary>
        /// <returns>A Collection of a DataSets RowIndexes.</returns>
        public Dictionary<string, int>[] GetRowIndexes(DataSet dataSet)
        {
            var rwIndexes = new Dictionary<string, int>[dataSet.Tables.Count];
            for (int i = 0; i < rwIndexes.Length; i++)
            {
                rwIndexes[i] = GetRowIndex(i, dataSet);
            }
            return rwIndexes;
        }

        /// <summary>
        /// Returns the indexes for the table's collection of entries
        /// </summary>
        /// <param name="tblNo">The Specific Table to get the Indexes for.</param>
        /// <returns>An Index of the table's entries, for easier data management.</returns>
        Dictionary<string, int> GetRowIndex(int tblNo, DataSet dataSet)
        {
            var rwIndex = new Dictionary<string, int>();
            // If a Table's PK is not found within the first column, create another if
            // that creates the PK based off it's structure.
            if (dataSet.Tables[tblNo].TableName == "CatalogueEntries")
            {
                for (int i = 0; i < dataSet.Tables[tblNo].Rows.Count; i++)
                {
                    rwIndex.Add(dataSet.Tables[tblNo].Rows[i].ItemArray[0] + ", "
                        + dataSet.Tables[tblNo].Rows[i].ItemArray[1], i);
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[tblNo].Rows.Count; i++)
                {
                    rwIndex.Add(dataSet.Tables[tblNo].Rows[i].ItemArray[0].ToString(), i);
                }
            }
            return rwIndex;
        }
    }
}
