using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace CodeGenForDsk.CodeGenForDsk.Gen
{
    public abstract class AbstractGen : IGen
    {
        public virtual void GenCode(DataRow[] drTables, DataSet dsTableColumns, DataSet dsTablePrimaryKeys, Gen.GenOptionInfo goi)
        {
            string[] strs = null;
            if (drTables != null && dsTableColumns != null && goi != null)
            {
                strs = new string[drTables.Length];

                for (int i = 0; i < drTables.Length; i++)
                {
                    DataRow drTable = drTables[i];
                    DataRow[] drTableColumns = dsTableColumns.Tables[goi.DbConfigInfo.DbConfigName + goi.CodeGenForDskGui.tablesColumns].Select("TABLE_NAME = '" + drTable["name"].ToString() + "'","COLUMN_ID ASC");
                    strs[i] = GenCode(drTable, drTableColumns, goi);

                }
            }          
        }
        public abstract string GenCode(DataRow drTable, DataRow[] drTableColumns, Gen.GenOptionInfo goi);
    }
}
