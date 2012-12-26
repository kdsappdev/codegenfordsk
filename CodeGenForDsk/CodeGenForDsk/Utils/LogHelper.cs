using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace CodeGenForDsk.CodeGenForDsk.Utils
{
    public sealed class LogHelper
    {       

        private LogHelper()
        { }
        public static void Error(Exception ex)
        {
            string msg = string.Format("{0}\tError\t{1}", DateTime.Now, ex.StackTrace);
            write(msg, FilePathHelper.LogPath + "\\Error.log");
        }
        public static void Info(string message)
        {
            string msg = string.Format("{0}\tInfo\t{1}", DateTime.Now, message);
            write(msg, FilePathHelper.LogPath + "\\Info.log");
        }
        private static void write(string message, string path)
        {
            FileHelper.CreateDirectory(path);
            FileInfo fi = new FileInfo(path);
            StreamWriter sw = fi.AppendText();
            sw.WriteLine(message);
            sw.Close();
        }
    }
}
