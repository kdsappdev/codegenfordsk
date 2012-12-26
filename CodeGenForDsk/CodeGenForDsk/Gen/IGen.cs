using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace CodeGenForDsk.CodeGenForDsk.Gen
{
   public interface IGen
    {
       void GenCode(DataRow[] drTables, DataSet dsTableColumns,DataSet dsTablePrimaryKeys, Gen.GenOptionInfo goi);        
    }
}
