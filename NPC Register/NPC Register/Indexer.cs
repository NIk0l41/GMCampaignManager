using System.Collections.Generic;
using System.Data;

namespace NPC_Register
{
    public class Indexer
    {
        // tableIndex[i] == entryIndexes[i] == attrIndexes[i]
        // Each Dictionary is for one collection:
        /// <summary>
        /// Table Name --> Table Position w/in DataSet
        /// </summary>
        public Dictionary<string, int> tableIndex;
        /// <summary>
        /// Entry PK --> Entry Position w/in Table
        /// </summary>
        public Dictionary<string, int>[] entryIndexes;
        /// <summary>
        /// Attribute Name --> Attribute Position w/in Table
        /// </summary>
        public Dictionary<string, int>[] attrIndexes;
        readonly DataSet dataSet;

        public Indexer(DataSet dataSet)
        {
            this.dataSet = dataSet;
            RefreshIndexes();

        }

        public void RefreshIndexes()
        {
            tableIndex = GetTableIndex();
            entryIndexes = GetRowIndexes();
        }

        /// <summary>
        /// Map the Table Names to their Position in the DataSet
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> GetTableIndex()
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
        Dictionary<string, int>[] GetRowIndexes()
        {
            var rwIndexes = new Dictionary<string, int>[dataSet.Tables.Count];
            for (int i = 0; i < rwIndexes.Length; i++)
            {
                rwIndexes[i] = GetRowIndex(i);
            }
            return rwIndexes;
        }

        /// <summary>
        /// Returns the indexes for the table's collection of entries
        /// </summary>
        /// <param name="tblNo">The Specific Table to get the Indexes for.</param>
        /// <returns>An Index of the table's entries, for easier data management.</returns>
        Dictionary<string, int> GetRowIndex(int tblNo)
        {
            var rwIndex = new Dictionary<string, int>();
            // If a Table's PK is not found within the first column, create another if
            // that creates the PK based off it's structure.
            if (dataSet.Tables[tblNo].TableName == "Catalogue")
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

        /// <summary>
        /// Map the Entire DataSet's attributes
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int>[] GetAttributeIndexes()
        {
            var atIndexes = new Dictionary<string, int>[dataSet.Tables.Count];
            for (int i = 0; i < atIndexes.Length; i++)
            {
                atIndexes[i] = GetAttributeIndex(i);
            }
            return atIndexes;
        }

        /// <summary>
        /// Returns the indexes for the tables collection of attributes
        /// </summary>
        /// <param name="tblNo"></param>
        /// <returns></returns>
        Dictionary<string, int> GetAttributeIndex(int tblNo)
        {
            var atIndex = new Dictionary<string, int>();

            return atIndex;
        }
    }
}
