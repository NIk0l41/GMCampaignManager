using System.Collections.Generic;

namespace NPC_Register
{
    public class UpdateLog
    {
        public string primaryKey;
        public string tableName;
        public UpdateLogType updateType;
        /// <summary>
        /// A package the Domain Manager must manufacture.
        /// Each entry contains the row index from the specified table,
        /// and the int/string value of the row change.
        /// </summary>
        public Dictionary<int, object> valueIndex;

        public UpdateLog(string primaryKey, string tableName, UpdateLogType updateType, Dictionary<int, object> valueIndex = null)
        {
            this.primaryKey = primaryKey;
            this.tableName = tableName;
            this.updateType = updateType;
            this.valueIndex = valueIndex;

        }
    }

    public enum UpdateLogType
    {
        CREATE,
        UPDATE,
        DELETE
    }
}
