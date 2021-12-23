using System.Collections.Generic;
using System.Data;

namespace NPC_Register
{
    public class DatasetEngineer
    {
        List<UpdateLog> updateQueue;

        public DatasetEngineer()
        {
            updateQueue = new List<UpdateLog>();
        }

        // >> Workflow<<
        // 1. Engineer tells the Form that 
        // 2. Manager tells Engineer those are all the items in the queue and
        // 3. Engineer starts exectuting the update logs. (BeginUpdatingDataSet)
        /// <summary>
        /// Add an Update Log to the DataSet Engineers Queue
        /// </summary>
        /// <param name="updateLog"></param>
        public List<UpdateLog> AddUpdateLog(List<UpdateLog> updateLogs, UpdateLog log) {
            /// 1) Add to the list of updateLogs
            updateLogs.Add(log);
            updateQueue.Add(log);
            return updateLogs;
        }

        public DataSet BeginUpdatingDataSet(DataSet inputData, Dictionary<string, int> tableIndex, Dictionary<string, int>[] rowIndexes) {
            for (int log = 0; log < updateQueue.Count; log++) {
                var updateLog = updateQueue[log];

                /// 2) Modify Dataset
                // Grab table data
                var tblIndex = tableIndex[updateLog.tableName];
                var table = inputData.Tables[tblIndex];
                var row = table.Rows[rowIndexes[tblIndex][updateLog.primaryKey]];
                // Determine log type.
                switch (updateLog.updateType) {
                    case UpdateLogType.DELETE:
                        table.Rows.Remove(row);
                        break;
                    case UpdateLogType.UPDATE:
                        // Foreach change to take place in the row
                        foreach (KeyValuePair<int, object> change in updateLog.valueIndex) {
                            row.ItemArray[change.Key] = change.Value;
                        }
                        break;
                    case UpdateLogType.CREATE:
                        for (int j = 0; j < updateLog.valueIndex.Count; j++) {
                            object[] values = new object[updateLog.valueIndex.Count];
                            for (int i = 0; i < values.Length; i++)
                            {
                                values[i] = updateLog.valueIndex[i];
                            }
                            table.Rows.Add(values);
                        }
                        break;
                }
                //Finalise Modification
                updateQueue[log] = updateLog;

                // Lastly, tell Miles that the indexes need to be redone.

                // Should we have a queue? Asynchronous Programming?
                // When the queue is empty, ask Miles to refresh indexes,
                // Saves resources.
            }
            return inputData;

        }



    }
}
