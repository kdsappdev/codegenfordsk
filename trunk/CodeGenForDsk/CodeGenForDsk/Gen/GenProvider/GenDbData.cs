using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace CodeGenForDsk.CodeGenForDsk.Gen.GenProvider
{
    public class GenDbData : AbstractGen
    {
        public override void GenCode(DataRow[] drTables, DataSet dsTableColumns, DataSet dsTablePrimaryKeys, GenOptionInfo goi)
        {
            goi.CodeGenForDskGui.setBtnEnable(false);
            Stopwatch sw = Stopwatch.StartNew();
            goi.CodeGenForDskGui.setStatusBar(string.Format("正在导出{0}数据库数据", goi.DbConfigInfo.DbConfigName));
            goi.CodeGenForDskGui.setProgreesEditValue(0);
            goi.CodeGenForDskGui.setProgress(0);
            goi.CodeGenForDskGui.setProgressMax(drTables.Length);

            base.GenCode(drTables, dsTableColumns, dsTablePrimaryKeys, goi);
            sw.Stop();
            goi.CodeGenForDskGui.setStatusBar(string.Format("{0}数据库数据导出成功;耗时[{1}]", goi.DbConfigInfo.DbConfigName, sw.Elapsed));
            goi.CodeGenForDskGui.setBtnEnable(true);
        }
        public override string GenCode(System.Data.DataRow drTable, System.Data.DataRow[] drTableColumns, GenOptionInfo goi)
        {
            string str = "OK";
            string tableName = drTable["name"] as string;
            DataSet ds = null;
            try
            {

                goi.CodeGenForDskGui.setStatusBar(string.Format("正在导出{0}中{1}表数据", goi.DbConfigInfo.DbConfigName, tableName));
                DNCCFrameWork.DataAccess.IDbHelper db = new DNCCFrameWork.DataAccess.DbFactory(goi.DbConfigInfo.ConnectionString.Trim(new char[] { '"' }), Utils.CodeGenHelper.GetDbProviderString(goi.DbConfigInfo.DbType)).IDbHelper;
                ds = new DataSet();
                if (Utils.FileHelper.isExist(goi.DbConfigInfo.DbConfigName, "_" + tableName))
                {
                    Utils.FileHelper.ReadXml(ds, goi.DbConfigInfo.DbConfigName, "_" + tableName);
                }
                else
                {
                    string sql = "select " + tableColumnNameSql(drTableColumns) + " from " + tableName;
                    db.Fill(sql, ds, new string[] { goi.DbConfigInfo.DbConfigName + "_" + tableName });
                    Utils.FileHelper.WriteXml(ds);

                }
                string[] sqls = genSqlData(ds, tableName, drTableColumns, goi);
                bool status = Utils.FileHelper.Write(Utils.FilePathHelper.ExportDataPath + goi.DbConfigInfo.DbConfigName + "_" + tableName + ".sql", sqls);
                if (!status)
                {
                    Utils.LogHelper.Info(string.Format("{0}导出数据库数据丢失{1}表数据", goi.DbConfigInfo.DbConfigName, tableName));
                }


            }
            catch (Exception ex)
            {
                str = "Failure";
                Utils.LogHelper.Error(ex);
                goi.CodeGenForDskGui.setStatusBar(string.Format("{0}导出数据库数据数据丢失{1}表数据[2]", goi.DbConfigInfo.DbConfigName, tableName, ex.Message));
                Utils.LogHelper.Info(string.Format("{0}导出数据库数据丢失{1}表数据", goi.DbConfigInfo.DbConfigName, tableName));

            }
            finally
            {
                goi.CodeGenForDskGui.setProgress(1);
            }
            return str;
        }
        private string tableColumnNameSql(DataRow[] drTableColumns)
        {
            string columnNameSql = "";
            foreach (DataRow dr in drTableColumns)
            {
                columnNameSql += dr["COLUMN_NAME"] as string + ",";
            }
            return columnNameSql.Trim(new char[] { ',' });
        }
        private string[] genSqlData(DataSet ds, string tableName, DataRow[] drTableColumns, GenOptionInfo goi)
        {
            string[] insertSql = new string[ds.Tables[0].Rows.Count + 2];
            //insertSql[0] = "SET DEFINE OFF;";
            //insertSql[ds.Tables[0].Rows.Count + 1] = "COMMIT;";
            DataRowCollection drcs = ds.Tables[0].Rows;
            for (int i = 0; i < insertSql.Length - 2; i++)
            {
                string values = "";
                for (int j = 0; j < drTableColumns.Length; j++)
                {
                    string nullAble = drTableColumns[j]["NULLABLE"] as string;
                    string columnName = drTableColumns[j]["COLUMN_NAME"] as string;
                    object o = drcs[i][columnName];
                    string dataType = drTableColumns[j]["DATA_TYPE"] as string;
                    string dataScale = drTableColumns[j]["DATA_SCALE"].ToString();
                    string dataLength = drTableColumns[j]["DATA_LENGTH"].ToString();
                    dataType = Utils.DataTypeMappingHelper.GetCSharpDataTypeByDbType(goi.DbConfigInfo.DbType, dataType, dataScale, dataLength);
                    if (nullAble.Equals("N"))
                    {
                        values += "'" + o + "'" + ",";
                    }
                    else
                    {
                        if (o == DBNull.Value)
                        {
                            o = "NULL";
                            values += o + ",";
                        }
                        else
                            if (dataType.Equals("string"))
                            {
                                values += "'" + o + "'" + ",";
                            }
                            else
                                if (dataType.Equals("DateTime"))
                                {
                                    DateTime dt = (DateTime)o;
                                    o = dt.ToString();
                                    values += "TO_DATE('" + o + "', 'YYYY/MM/DD HH24:MI:SS')" + ",";
                                }
                                else
                                {
                                    values += o + ",";

                                }
                    }
                }
                values = values.Trim(new char[] { ',' });
                if (goi.OriginalEncoding != null && goi.TargetEncoding != null)
                {
                    Byte[] b =goi.OriginalEncoding.GetBytes(values);
                    values =  goi.TargetEncoding.GetString(b);
                }
                insertSql[i + 1] = string.Format("Insert into {0}({1}) Values({2});", tableName, tableColumnNameSql(drTableColumns), values);
            }
            return insertSql;
        }
    }
}
