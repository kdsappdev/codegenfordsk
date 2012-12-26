using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace CodeGenForDsk.CodeGenForDsk.Utils
{
    public sealed class CodeGenHelper
    {
        private CodeGenHelper()
        { }
        public static string GetDbProviderString(string dbType)
        {
            string str = "";
            switch (dbType)
            {
                case "Oracle":
                    str = "OracleHelper";
                    break;
                case "Sql Server":
                    str = "SqlHelper";
                    break;
            }
            return str;
        }

        public static void Gen(string dbType, CodeGenEnum type, DataRow[] drTables, DataSet dsTableColumns, DataSet dsTablePrimaryKeys, Gen.GenOptionInfo goi)
        {         
            CodeGenForDsk.Gen.IGen gen = CodeGenForDsk.Gen.GenFactory.CreateGen(dbType, type);
            if (gen != null)
            {
                 gen.GenCode(drTables, dsTableColumns,dsTablePrimaryKeys,goi);
            }          
        }

        public static string StrFirstToUpperRemoveUnderline(string str)
        {
            string temp = str;
            if (!string.IsNullOrEmpty(str))
            {
                temp = temp.ToLower();
                string[] temps = temp.ToLower().Split(new char[] { '_' });
                temp = "";
                foreach (string s in temps)
                {
                    temp += StrFirstToUpper(s);
                }
            }
            return temp;
        }
        public static string StrFirstToLowerRemoveUnderline(string str)
        {
            string temp = str;
            if (!string.IsNullOrEmpty(str))
            {
                temp = temp.ToLower();
                string[] temps = temp.ToLower().Split(new char[] { '_' });
               
                if (temps.Length > 0)
                {
                    temp = "";
                    temp += StrFirstToLower(temps[0]);
                    for (int i = 1; i < temps.Length; i++)
                    {
                        temp += StrFirstToUpper(temps[i]);
                    }
                }
                
            }
            return temp;
        }
        public static string StrFieldWithM(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str ="m_"+ StrFirstToLowerRemoveUnderline(str);
            }
            return str;
        }
        public static string StrProperty(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = StrFirstToUpperRemoveUnderline(str);
            }
            return str;
        }
        public static string StrFirstToUpper(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {               
                str = str[0].ToString().ToUpper() + str.Substring(1, str.Length - 1);
            }
            return str;
        }
        public static string StrFirstToLower(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str[0].ToString().ToLower() + str.Substring(1, str.Length - 1);
            }
            return str;
        }
        public static string GetDefaultValueByDataType(string str, string defaultValue)
        {
            string temp = "\"\"";
            if (!string.IsNullOrEmpty(str))
            {   
                switch (str)
                {
                    case "string":
                        if (!string.IsNullOrEmpty(defaultValue))
                        {
                            temp = "\"" + defaultValue + "\"";
                        }
                        else
                        {
                            temp = "\"\"";
                        }
                        break;
                    case "int":
                        if (!string.IsNullOrEmpty(defaultValue))
                        {
                            temp = defaultValue;
                        }
                        else
                        {
                            temp = "0";
                        }
                        break;
                    case "long":
                        if (!string.IsNullOrEmpty(defaultValue))
                        {
                            temp = defaultValue;
                        }
                        else
                        {
                            temp = "0";
                        }
                        break;
                    case "DateTime":
                        temp = "DateTime.Now";                        
                        break;
                    default:
                        temp = "\"\"";
                        break;
                }
            }
            return temp;
        }
    }

}
