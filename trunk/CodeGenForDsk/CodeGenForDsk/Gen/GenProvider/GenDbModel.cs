using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace CodeGenForDsk.CodeGenForDsk.Gen.GenProvider
{
    /// <summary>
    /// 实体类属性生成器
    /// </summary>
    internal class GenDbModel : AbstractGen
    {
        public override string GenCode(DataRow drTable, DataRow[] drTableColumns,Gen.GenOptionInfo goi)
        {
            StringBuilder sb = new StringBuilder();
           
            #region 引入命名空间
            sb.AppendFormat("using System;").AppendFormat("\r\n");
            sb.AppendFormat("using System.Collections.Generic;").AppendFormat("\r\n");
            sb.AppendFormat("using System.Text;").AppendFormat("\r\n");
            sb.AppendFormat("using System.Xml.Serialization;").AppendFormat("\r\n"); 
            #endregion

            #region 命名空间
            sb.AppendFormat("namespace {0}",goi.NameSpace).AppendFormat("\r\n");
            sb.Append("{").AppendFormat("\r\n");            
            
            #region 类名
            string className =drTable["name"] as string;
            className = Utils.CodeGenHelper.StrFirstToUpperRemoveUnderline(className);
            sb.AppendFormat("\t").AppendFormat("public class {0}",className).AppendFormat("\r\n");
            sb.Append("\t{").AppendFormat("\r\n");
           
            #region 字段
            sb.AppendFormat("\t\t").AppendFormat("#region 字段").AppendFormat("\r\n").AppendFormat("\r\n");
            foreach (DataRow dr in drTableColumns)
            {
                string dataType = "string";
                if (goi.GenOption.Equals(CodeGenForDsk.Gen.GenOptionEnum.GenStringType))
                {
                    dataType = "string";
                }
                if (goi.GenOption.Equals(CodeGenForDsk.Gen.GenOptionEnum.GenDBType))
                {
                    dataType=Utils.DataTypeMappingHelper.GetCSharpDataTypeByDbType(goi.DbConfigInfo.DbType,dr["DATA_TYPE"] as string,dr["DATA_SCALE"] as string,dr["DATA_LENGTH"] as string);
                }
                string columnName=dr["COLUMN_NAME"] as string;
                string fieldName= Utils.CodeGenHelper.StrFieldWithM(columnName);
                string defaultValue = dr["DATA_DEFAULT"] as string;
                string nullAble = dr["NULLABLE"] as string;
               
                string comments = dr["COMMENTS"] as string;
                sb.AppendFormat("\t\t").AppendFormat("private {0} {1}", dataType, fieldName);
                if (nullAble.Equals("N") || !string.IsNullOrEmpty(defaultValue))
                {
                    defaultValue = Utils.CodeGenHelper.GetDefaultValueByDataType(dataType, defaultValue);
                    sb.AppendFormat(" = {0}", defaultValue);
                }
                sb.AppendFormat(";");
                sb.AppendFormat("//{0}", comments);
                sb.AppendFormat("\r\n");
            }
            sb.AppendFormat("\r\n");
            sb.AppendFormat("\t\t").AppendFormat("#endregion").AppendFormat("\r\n");
            #endregion
            sb.AppendFormat("\r\n");
          
            #region 属性
            sb.AppendFormat("\t\t").AppendFormat("#region 属性").AppendFormat("\r\n").AppendFormat("\r\n");
            foreach (DataRow dr in drTableColumns)
            {
                string dataType = "string";
                if (goi.GenOption.Equals(CodeGenForDsk.Gen.GenOptionEnum.GenStringType))
                {
                    dataType = "string";
                }
                if (goi.GenOption.Equals(CodeGenForDsk.Gen.GenOptionEnum.GenDBType))
                {
                    dataType = Utils.DataTypeMappingHelper.GetCSharpDataTypeByDbType(goi.DbConfigInfo.DbType, dr["DATA_TYPE"] as string, dr["DATA_SCALE"] as string, dr["DATA_LENGTH"] as string);
                }
                string columnName = dr["COLUMN_NAME"] as string;
                string fieldName= Utils.CodeGenHelper.StrFieldWithM(columnName);
                string propertyName=Utils.CodeGenHelper.StrProperty(columnName);
                sb.AppendFormat("\t\t").AppendFormat("public {0} {1}",dataType,propertyName).AppendFormat("\r\n");
                sb.AppendFormat("\t\t").Append("{").AppendFormat("\r\n");
                sb.AppendFormat("\t\t\t").AppendFormat("get ").Append("{ ").AppendFormat("return {0};", fieldName).Append(" }").AppendFormat("\r\n");

                sb.AppendFormat("\t\t\t").AppendFormat("set ").Append("{ ").AppendFormat("{0} = value;", fieldName).Append(" }").AppendFormat("\r\n");
                sb.AppendFormat("\t\t").Append("}").AppendFormat("\r\n");
                sb.AppendFormat("\r\n");
            }
            sb.AppendFormat("\t\t").AppendFormat("#endregion").AppendFormat("\r\n");
            sb.AppendFormat("\r\n");
            #endregion

            sb.Append("\t}").AppendFormat("\r\n");
            #endregion

            sb.Append("}").AppendFormat("\r\n");
            #endregion

            string title = Utils.CodeGenHelper.StrFirstToUpperRemoveUnderline(drTable["name"] as string) + ".cs";
            ModelForm mf = new ModelForm(goi.CodeGenForDskGui.mdiPanel1.MdiForm, sb.ToString(), title);
            mf.Show();
            return sb.ToString();
        }
    }
}
