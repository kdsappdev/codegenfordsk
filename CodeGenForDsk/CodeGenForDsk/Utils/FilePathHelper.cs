using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace CodeGenForDsk.CodeGenForDsk.Utils
{
   public class FilePathHelper
    {
       private FilePathHelper()
       { }
       public static readonly string SystemConfig = Application.StartupPath + "\\data\\CGFD\\CodeGenForDsk.ini";

       public static readonly string ExportDataPath = Application.StartupPath + "\\data\\CGFD\\Sql\\";

       public static readonly string ExportDBDocPath = Application.StartupPath + "\\data\\CGFD\\Doc\\";

       public static readonly string SaveDBDataPath = Application.StartupPath + "\\data\\CGFD\\Data\\";

       public static readonly string LogPath = Application.StartupPath + "\\data\\CGFD\\Log\\";

       public static readonly string FxCopPath = Application.StartupPath + "\\data\\CGFD\\FxCop\\";     
    }
}
