using System;
using System.Data;
using System.Collections.Generic;

namespace NPC_Register
{
    public class UpdateLog
    {
        public string primaryKey;
        public string tableName; //Index??
        public int updateType;
    }

    public class RowContents
    {
        public string colName;
        public Type colType;
        public string colContentsStr;
        public int colContentInt;

        void SetContents() {
            
        }
    }
}
