using System.Collections.Generic;
using System.Data;

namespace NPC_Register
{
    public class DatasetEngineer
    {
        readonly DataSet data;
        readonly Dictionary<string, int> tableIndex;
        readonly Dictionary<string, int>[] rowIndexes;
        readonly List<UpdateLog> logs;
        readonly Indexer indexer;

        public DatasetEngineer(Form1 form)
        {
            data = form.publicData;
            tableIndex = form.tableIndex;
            rowIndexes = form.rowIndexes;
            logs = form.updateLogs;
            indexer = form.indexerMiles;
        }

        public void ReceiveUpdateLog(UpdateLog updateLog)
        {
            /// 1) Add to the list of updateLogs
            logs.Add(updateLog);

            /// 2) Modify Dataset
            // Grab table data
            var tblIndex = tableIndex[updateLog.tableName];
            var table = data.Tables[tblIndex];
            var row = table.Rows[rowIndexes[tblIndex][updateLog.primaryKey]];
            // Determine log type.
            switch (updateLog.updateType)
            {
                case UpdateLogType.DELETE:
                    table.Rows.Remove(row);
                    break;
                case UpdateLogType.UPDATE:
                    // Foreach change to take place in the row
                    foreach (KeyValuePair<int, object> change in updateLog.valueIndex)
                    {
                        row.ItemArray[change.Key] = change.Value;
                    }
                    break;
                case UpdateLogType.CREATE:
                    for(int j = 0; j < updateLog.valueIndex.Count; j++)
                    {
                        object[] values = new object[updateLog.valueIndex.Count];
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = updateLog.valueIndex[i];
                        }
                        table.Rows.Add(values);
                    }
                    break;
            }
            // Lastly, tell Miles that the indexes need to be redone.
            indexer.RefreshIndexes();
            // Should we have a queue? Asynchronous Programming?
            // When the queue is empty, ask Miles to refresh indexes,
            // Saves resources.

        }



    }
}
