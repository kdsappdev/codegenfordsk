using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenForDsk.CodeGenForDsk.Gen
{
   internal class GenFactory
    {
       private GenFactory()
       { }
       public static IGen CreateGen(string dbType, Utils.CodeGenEnum type)
       {
           IGen gen = null;           
           switch (dbType)
           {
               default:
                   switch (type)
                   {
                       case Utils.CodeGenEnum.Model:

                           gen = new GenProvider.GenDbModel();
                           break;
                       case Utils.CodeGenEnum.DBWord:

                           gen = new GenProvider.GenDbWord();
                           break;
                       case Utils.CodeGenEnum.DBData:

                           gen = new GenProvider.GenDbData();
                           break;
                       case Utils.CodeGenEnum.MQTG:
                           gen = new GenProvider.GenMQTGSP();
                           break;
                   }
                   break;
           }
           return gen;
       }
    }
}
