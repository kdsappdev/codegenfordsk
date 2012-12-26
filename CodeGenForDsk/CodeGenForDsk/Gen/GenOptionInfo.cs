using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenForDsk.CodeGenForDsk.Gen
{
   public class GenOptionInfo
    {
        private Model.DbConfigInfo dbConfigInfo;

        public Model.DbConfigInfo DbConfigInfo
        {
            get { return dbConfigInfo; }
            set { dbConfigInfo = value; }
        }
        public GenOptionInfo(CodeGenForDskGui codeGenForDskGui, Model.DbConfigInfo dbConfigInfo)
       {
           this.codeGenForDskGui = codeGenForDskGui;
           this.dbConfigInfo = dbConfigInfo;
       }
        private GenOptionEnum genOption = GenOptionEnum.GenDBType;

        public GenOptionEnum GenOption
        {
            get { return genOption; }
            set { genOption = value; }
        }
        private string nameSpace = "CodeGenForDsk";

        public string NameSpace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
        }

        private string dbWordName = "CodeGenForDsk";

        public string DbWordName
        {
            get { return dbWordName; }
            set { dbWordName = value; }
        }
        private CodeGenForDskGui codeGenForDskGui;

        public CodeGenForDskGui CodeGenForDskGui
        {
            get { return codeGenForDskGui; }
            set { codeGenForDskGui = value; }
        }

        private Encoding originalEncoding = null;

        public Encoding OriginalEncoding
        {
            get { return originalEncoding; }
            set { originalEncoding = value; }
        }
        private Encoding targetEncoding = null;

        public Encoding TargetEncoding
        {
            get { return targetEncoding; }
            set { targetEncoding = value; }
        }

        #region MQTGSP 参数
        private string prodcedureName = "SP_STP_$TABLENAME";

        public string ProdcedureName
        {
            get { return prodcedureName; }
            set { prodcedureName = value; }
        }
        private string triggerName = "TG_STP_IN_$TABLENAME";

        public string TriggerName
        {
            get { return triggerName; }
            set { triggerName = value; }
        }
        private string topicName = "'ATS.' || $LOCATION || '.$TABLENAME.CHANGED'";

        public string TopicName
        {
            get { return topicName; }
            set { topicName = value; }
        }
        #endregion

    }
   public enum GenOptionEnum
   {
       GenStringType,//生成字符串类型
       GenDBType//依据数据库类型生成
   }
}
