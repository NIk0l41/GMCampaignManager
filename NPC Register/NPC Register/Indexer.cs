using System;
using System.Collections.Generic;
using System.Data;

namespace NPC_Register
{
    class Indexer
    {
        // tableIndex[i] == rowIndexes[i]
        public Dictionary<string, int> tableIndex;
        public Dictionary<string, int>[] rowIndexes;
        DataSet dataSet;

        public Indexer(DataSet dataSet) {
            this.dataSet = dataSet;
            tableIndex = GetTableIndex();
            rowIndexes = GetRowIndexes();
        }

        /// <summary>
        /// Map the Table Names to their Position in the DataSet
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> GetTableIndex() {
            var tblIndex = new Dictionary<string, int>();
            for (int i = 0; i < dataSet.Tables.Count; i++) {
                tblIndex.Add(dataSet.Tables[i].TableName, i);
            }
            return tblIndex;
        }

        /// <summary>
        /// Map the entire dataSet's indexes.
        /// </summary>
        /// <returns>A Collection of a DataSets RowIndexes.</returns>
        Dictionary<string, int>[] GetRowIndexes() {
            var rwIndexes = new Dictionary<string, int>[dataSet.Tables.Count];
            for (int i = 0; i < rwIndexes.Length; i++) {
                rwIndexes[i] = GetRowIndex(i);
            }
            return rwIndexes;
        }

        /// <summary>
        /// Returns the indexes for the table's collection of entries
        /// </summary>
        /// <param name="tblNo">The Specific Table to get the Indexes for.</param>
        /// <returns>An Index of the table's entries, for easier data management.</returns>
        Dictionary<string, int> GetRowIndex(int tblNo) {
            var rwIndex = new Dictionary<string, int>();
            // If a Table's PK is not found within the first column, create another if
            // that creates the PK based off it's structure.
            if (dataSet.Tables[tblNo].TableName == "Catalogue") {
                for (int i = 0; i < dataSet.Tables[tblNo].Rows.Count; i++) {
                    rwIndex.Add(dataSet.Tables[tblNo].Rows[i].ItemArray[0] + ", "
                        + dataSet.Tables[tblNo].Rows[i].ItemArray[1], i);
                }
            } else {
                for (int i = 0; i < dataSet.Tables[tblNo].Rows.Count; i++) {
                    rwIndex.Add(dataSet.Tables[tblNo].Rows[i].ItemArray[0].ToString(), i);
                }
            }
            return rwIndex;
        }
    }
}
