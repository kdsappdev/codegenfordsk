using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace CodeGenForDsk.CodeGenForDsk.Utils
{
    public sealed class FileHelper
    {
        private FileHelper()
        { }
       
        public static void WriteXml(DataSet ds)
        {
           
            if (ds != null)
            {
                try
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        string path = FilePathHelper.SaveDBDataPath + dt.TableName + ".data";
                        CreateDirectory(path);
                        dt.WriteXml(path, XmlWriteMode.WriteSchema);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static DataSet ReadXml(DataSet ds, string dbConfigName, string dataType)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            bool status = isExist(dbConfigName, dataType);
            if (status)
            {
                try
                {
                    DataTable dt = new DataTable();
                    string path = FilePathHelper.SaveDBDataPath + dbConfigName + dataType + ".data";
                    CreateDirectory(path);
                    dt.ReadXml(path);
                    ds.Tables.Add(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ds;
        }
        public static bool isExist(string dbConfigName, string dataType)
        {
            bool status = false;
            if (!string.IsNullOrEmpty(dbConfigName) && !string.IsNullOrEmpty(dataType))
            {
                string path =  FilePathHelper.SaveDBDataPath + dbConfigName + dataType + ".data";
                CreateDirectory(path);
                if (File.Exists(path))
                {
                    status = true;
                }
            }
            return status;
        }
        public static bool Write(string fileName, string[] strs)
        {
            bool status = true;
            try
            {
                CreateDirectory(fileName);
                File.Delete(fileName);
                FileInfo f = new FileInfo(fileName);
                StreamWriter sw = f.AppendText();
                foreach (string str in strs)
                {
                    sw.WriteLine(str);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static string CreateDirectory(string fileName)
        {
            string path = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                fileName = fileName.Trim(new char[] { '\\' });
                string[] paths = fileName.Split(new char[] { '\\' });

                for (int i = 0; i < paths.Length - 1; i++)
                {
                    path = path + paths[i];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\";
                }
            }
            return path;
        }
    }
}
