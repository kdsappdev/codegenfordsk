using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace CodeGenForDsk.CodeGenForDsk.FxCop
{
    public partial class FxCopAnalyzeForm : Utils.BaseForm
    {
        private string filePath ="";

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        private Dictionary<string, List<FxCopResultInfo>> dic = new Dictionary<string, List<FxCopResultInfo>>();
        public FxCopAnalyzeForm()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("文件路径不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string tip =string.Format("分析成功");
            try
            {
                dic.Clear();
                analyze();
                saveFile();
            }
            catch (Exception ex)
            {
                tip = string.Format("分析失败[{0}]", ex.Message);
            }
            MessageBox.Show(tip, "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void saveFile()
        {
            List<string> temp = new List<string>();

            foreach (KeyValuePair<string, List<FxCopResultInfo>> kvp in dic)
            {
             
                string result = "";
                temp.Clear();
                List<FxCopResultInfo> fxCopResultList = FxCopResultFilter.Filter("OutPut", kvp.Value);
              
                for (int i = 0; i < fxCopResultList.Count; i++)
                {
                    result = fxCopResultList[i].ToString();
                    if (!temp.Contains(result))
                    {
                        temp.Add(result);
                    }
                }
                if (temp.Count > 0)
                {
                    string fileName = string.Format("{0}FxCop_{1}_{2}.txt", Utils.FilePathHelper.FxCopPath, kvp.Key, temp.Count);
                    temp.Insert(0, MessageTypeEnChMapping.getMessageTypeCH(kvp.Key.ToLower()));
                    Utils.FileHelper.Write(fileName, temp.ToArray());
                }
            }
        }

        private void analyze()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList xxList1 = xmlDoc.GetElementsByTagName("Target");

            string nameSpace = "";
            string type = "";
            string messageType = "";
            foreach (XmlNode xxNode1 in xxList1)
            {
                XmlNodeList xxList2 = xxNode1.SelectNodes("Modules/Module/Namespaces/Namespace");
                foreach (XmlNode xxNode2 in xxList2)//Namespace
                {
                    nameSpace = "";
                    nameSpace = xxNode2.Attributes["Name"].Value;
                    XmlNodeList xxList3 = xxNode2.SelectNodes("Types/Type");
                    foreach (XmlNode xxNode3 in xxList3)
                    {
                        XmlAttributeCollection xac3 = xxNode3.Attributes;
                        type = "";
                        type = xac3["Name"].Value;
                        XmlNodeList xxList4 = xxNode3.SelectNodes("Members/Member/Messages/Message");
                        foreach (XmlNode xxNode4 in xxList4)
                        {
                            XmlAttributeCollection xac4 = xxNode4.Attributes;
                            messageType = "";
                            messageType = xac4["TypeName"].Value;
                            if (!dic.ContainsKey(messageType))
                            {
                                List<FxCopResultInfo> lt = new List<FxCopResultInfo>();
                                dic.Add(messageType, lt);
                            }
                            List<FxCopResultInfo> temp = dic[messageType];
                            FxCopResultInfo fcri = new FxCopResultInfo();

                            if (!string.IsNullOrEmpty(nameSpace))
                            {
                                fcri.ClassName = nameSpace + "." + type;
                            }
                            else
                            {
                                fcri.ClassName = type;
                            }
                            fcri.MessageType = messageType;
                            fcri.Message = xxNode4.InnerXml;
                            temp.Add(fcri);
                        }
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
           DialogResult dr= openFileDialog1.ShowDialog();
           if (dr.Equals(DialogResult.OK))
           {              
               teFilePath.Text = openFileDialog1.FileName;
               btnAnalyze.Focus();
           }
        }

        private void teFilePath_EditValueChanged(object sender, EventArgs e)
        {
            filePath = teFilePath.Text.Trim();
        }
    }

    internal class FxCopResultInfo
    {
        private string className = "";

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        private string messageType = "";

        public string MessageType
        {
            get { return messageType; }
            set { messageType = value; }
        }

        private string message = "";

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", className);
        }
    }

    internal class MessageTypeEnChMapping
    {
        private MessageTypeEnChMapping()
        { }
        static MessageTypeEnChMapping()
        {
            dataDic();
        }
        static Utils.BidirectionalMapping<string, string> dic = new Utils.BidirectionalMapping<string, string>();
        public static string getMessageTypeCH(string en)
        {
            string str = "";
            if (dic.ContainsT1(en))
            {
                str = dic.GetT2(en);
            }
            return str;
        }
        public static string getMessageTypeEn(string ch)
        {
            string str = "";
            if (dic.ContainsT2(ch))
            {
                str = dic.GetT1(ch);
            }
            return str;
        }
        private static void dataDic()
        {
            design();

            globalization();

            interoperability();

            naming();

            performance();
        }

        #region Design
        private static void design()
        {
            //1-10
            dic.Add("Abstract types should not have constructors".Replace(" ", "").ToLower(), "抽象类不应该声明构造方法");
            dic.Add("Assemblies should have valid strong names".Replace(" ", "").ToLower(), "程序集应该具有强名称");
            dic.Add("Avoid empty interfaces ".Replace(" ", "").ToLower(), "避免使用空的接口");
            dic.Add("Avoid excessive parameters on generic types".Replace(" ", "").ToLower(), "避免在泛型类中使用过多的类型参数");
            dic.Add("Avoid namespaces with few types ".Replace(" ", "").ToLower(), "避免让名字空间含有过少的类型");
            dic.Add("Avoid out parameters ".Replace(" ", "").ToLower(), "避免使用 out类型的参数");
            dic.Add("Collections should implement generic interface ".Replace(" ", "").ToLower(), "集合类应该实现泛型接口");
            dic.Add(" Consider passing base types as parameters ".Replace(" ", "").ToLower(), "尽量使用基本类型作为参数");
            dic.Add("Declare event handlers correctly ".Replace(" ", "").ToLower(), "正确的声明事件处理器，事件处理器不应该具有返回值");
            dic.Add("Declare types in namespaces ".Replace(" ", "").ToLower(), "应该在名字空间里面定义类型，而不是外面");


            //11-20
            dic.Add("Default parameters should not be used ".Replace(" ", "").ToLower(), "不应该使用参数默认值（C#没有参数默认值");
            dic.Add("Define accessors for attribute arguments ".Replace(" ", "").ToLower(), "应该为特性（特性）的构造方法参数定义访问器，其名字跟构造方法参数仅首字母大小写不一样");
            dic.Add("Do not catch general exception types".Replace(" ", "").ToLower(), "不要捕捉普通的异常（即System.Exception）");
            dic.Add("Do not declare protected members in sealed types ".Replace(" ", "").ToLower(), "不要在封闭类型中定义受保护的成员");
            dic.Add("Do not declare static members on generic types ".Replace(" ", "").ToLower(), "不要在泛型类型中使用静态成员");
            dic.Add(" Do not declare virtual members in sealed types ".Replace(" ", "").ToLower(), "不要在封闭类型中定义虚成员");
            dic.Add("Do not declare visible instance fields ".Replace(" ", "").ToLower(), "不要定义可见的（public/internal）实例域变量");
            dic.Add("Do not expose generic lists ".Replace(" ", "").ToLower(), "不要直接暴露范型表");
            dic.Add("Do not hide base class methods".Replace(" ", "").ToLower(), "不要隐藏（使用或者不使用new）基类的方法");
            dic.Add("Do not nest generic types in member signatures ".Replace(" ", "").ToLower(), "不要在成员的签名（参数或者返回值）中嵌套泛型类");


            //21-30
            dic.Add("Do not override operator equals on reference types".Replace(" ", "").ToLower(), "不要在引用类型中重载==操作符");
            dic.Add("Do not pass types by reference ".Replace(" ", "").ToLower(), "不要使用引用（ref or out）传递类型");
            dic.Add("Enum Storage should be Int32 ".Replace(" ", "").ToLower(), "枚举应该是 Int32 类型的");
            dic.Add("Enumerators should be strongly typed ".Replace(" ", "").ToLower(), "枚举器应该是强类型的");
            dic.Add("Enums should have zero value".Replace(" ", "").ToLower(), "枚举应该具有0值");
            dic.Add(" Generic methods should provide type parameter ".Replace(" ", "").ToLower(), "泛型类的方法应该提供类型参数");
            dic.Add("ICollection implementations have strongly typed members ".Replace(" ", "").ToLower(), "集合接口的实现中应该使用强类型的成员");
            dic.Add("Implement standard exception constructors".Replace(" ", "").ToLower(), "自定义的异常应该实现异常类的四个标准构造方法");
            dic.Add("Indexers should not be multidimensional ".Replace(" ", "").ToLower(), "索引不应该是多维的");
            dic.Add(" Interface methods should be callable by child types".Replace(" ", "").ToLower(), "接口方法应该可以被子类调用");


            //31-40
            dic.Add("Lists are strongly typed".Replace(" ", "").ToLower(), "表应该是强类型的");
            dic.Add("Mark assemblies with assembly version".Replace(" ", "").ToLower(), "用程序集版本标示程序集");
            dic.Add("Mark assemblies with CLSCompliant".Replace(" ", "").ToLower(), "使用CLSCompliant特性标示程序集");
            dic.Add("Mark assemblies with ComVisible ".Replace(" ", "").ToLower(), "使用 System.Runtime.InteropServices.ComVisibleAttribute 特性标示程序集");
            dic.Add("Mark attributes with AttributeUsageAttribute".Replace(" ", "").ToLower(), "使用 AttributeUsageAttribute 特性标示特性类");
            dic.Add("Mark enums with FlagsAttribute".Replace(" ", "").ToLower(), "含有组合的枚举应该使用FlagsAttribute特性标示，相反则不应该");
            dic.Add("Members should not expose certain concrete types ".Replace(" ", "").ToLower(), "成员（返回值或者参数）不应该暴露具体类型，尽量使用接口");
            dic.Add("Move pinvokes to native methods class".Replace(" ", "").ToLower(), "将调用移到本地方法类（不是很理解）");
            dic.Add("Nested types should not be visible ".Replace(" ", "").ToLower(), "嵌套类型不应该是可见的");
            dic.Add("Override methods on comparable types".Replace(" ", "").ToLower(), "可比较类型应该重写 equals 等方法");

            //41-50
            dic.Add(" Override operator equals on overriding add and subtract ".Replace(" ", "").ToLower(), "在重写+和-运算的时候应该同时重写==操作符");
            dic.Add("Properties should not be write only".Replace(" ", "").ToLower(), "属性不应该是只写的");
            dic.Add(" Provide ObsoleteAttribute message ".Replace(" ", "").ToLower(), "过时的成员应该使用ObsoleteAttribute特性标示，并提供相应的Message提示使用者");
            dic.Add("Replace repetitive arguments with params array".Replace(" ", "").ToLower(), "使用参数数组代替重复的参数");
            dic.Add("Static holder types should be sealed ".Replace(" ", "").ToLower(), "仅含有静态成员的类型应该声明为封闭的");
            dic.Add(" Static holder types should not have constructors".Replace(" ", "").ToLower(), "仅含有静态成员的类型应该具有构造方法");
            dic.Add(" String uri overloads call system uri overloads".Replace(" ", "").ToLower(), "使用string类型的uri参数的重载应调用系统的使用URI类型参数的重载");
            dic.Add("Types should not extend certain base types".Replace(" ", "").ToLower(), "类型不应该从具体的类（已经过派生的类）继承，比如异常类不应该从ApplicationException继承，而应该从System.Exception继承");
            dic.Add("Types that own disposable fields should be disposable ".Replace(" ", "").ToLower(), "含有可释放成员的类型应该是可以释放的（实现IDisposable接口");
            dic.Add("Types that own native resources should be disposable ".Replace(" ", "").ToLower(), "使用了非托管资源的类型应该是可以释放的（实现IDisposable接口");

            //51-59
            dic.Add("Uri parameters should not be strings".Replace(" ", "").ToLower(), "Uri 参数不应该是string类型的");
            dic.Add(" Uri properties should not be strings ".Replace(" ", "").ToLower(), "Uri 属性不应该是string类型的");
            dic.Add("Uri return values should not be strings ".Replace(" ", "").ToLower(), "Uri 类型的返回值不应该是string类型的");
            dic.Add("Use events where appropriate ".Replace(" ", "").ToLower(), "在适当的时候使用事件");
            dic.Add("Use generic event handler instances ".Replace(" ", "").ToLower(), "使用泛型的事件处理器实例");
            dic.Add("Use generics where appropriate ".Replace(" ", "").ToLower(), "在适当的时候使用范型");
            dic.Add("Use integral or string argument for indexers ".Replace(" ", "").ToLower(), "索引器应该使用整数或者字符串类型的参数");
            dic.Add("Use properties where appropriate".Replace(" ", "").ToLower(), "在适当的时候使用属性（而不是以Get或者Set开头的方法）");
            dic.Add("Validate arguments of public methods".Replace(" ", "").ToLower(), "对public的方法的参数应该在方法开头处进行检验（比如是否为null的检验）");
        }
        #endregion

        #region Globalization
        private static void globalization()
        {
            //1-7
            dic.Add("Avoid duplicate accelerators".Replace(" ", "").ToLower(), "避免在顶层控件中使用重复的快捷键（加速键)");
            dic.Add("Do not hardcode locale specific strings".Replace(" ", "").ToLower(), "不要对本地的特殊字符串（比如特殊的系统路径）进行硬编码");
            dic.Add("Avoid empty interfaces ".Replace(" ", "").ToLower(), "避免使用空的接口");
            dic.Add("Do not pass literals as localized parameters".Replace(" ", "").ToLower(), "不要把文本作为需要本地化的参数直接传递（尽量使用资源文件)");
            dic.Add("Set locale for data types ".Replace(" ", "").ToLower(), "为某些数据类型设定区域和语言属性（DataSet和DataTable的locale属性)");
            dic.Add("Specify CultureInfo ".Replace(" ", "").ToLower(), "指定文化信息（地域和语言信息），在调用接受System.Globalization.CultureInfo 类型参数的方法时应该传递文化信息");
            dic.Add("Specify IFormatProvider ".Replace(" ", "").ToLower(), "指定格式供应器，在调用接受System.IFormatProvider 类型参数的方法时应该传递格式供应器");
            dic.Add("Specify MessageBoxOptions".Replace(" ", "").ToLower(), "指定MessageBox的选项，在调用MessageBox.Show方法时应该传递System.Windows.Forms.MessageBoxOptions，特别在某些从右向左阅读习惯的区域");

        }
        #endregion

        #region Interoperability
        private static void interoperability()
        {
            //1-10
            dic.Add("Auto layout types should not be ComVisible".Replace(" ", "").ToLower(), "自动布局的类型不应该对Com可见（设置System.Runtime.InteropServices.ComVisibleAttribute特性为false）");
            dic.Add("Avoid int64 arguments for VB6 clients".Replace(" ", "").ToLower(), "避免使用int64类型，如果成员可能被Visual Basic 6 COM clients调用");
            dic.Add(" Avoid non-public fields in ComVisible value types ".Replace(" ", "").ToLower(), "避免在一个标记有ComVisible特性的值类型里面包含非公有的实例域");
            dic.Add("Avoid overloads in ComVisible interfaces ".Replace(" ", "").ToLower(), "避免在一个标记有ComVisible特性的接口内声明重载");
            dic.Add("Avoid static members in ComVisible types ".Replace(" ", "").ToLower(), "避免在一个标记有ComVisible特性的类型");
            dic.Add("Call GetLastError immediately after pinvoke ".Replace(" ", "").ToLower(), "进行pinvoke以后应该立即使用GetLastError读取错误信息");
            dic.Add("Com registration methods should be matched ".Replace(" ", "").ToLower(), "Com注册方法（标记有System.Runtime.InteropServices.ComRegisterFunctionAttribute特性的方法）应该是配对的（同时具有一个标记有System.Runtime.InteropServices.ComUnregisterFunctionAttribute的方法与之匹配）");
            dic.Add("Com registration methods should not be visible ".Replace(" ", "").ToLower(), "Com注册方法应该是不可见的");
            dic.Add("Com visible type base types should be ComVisible".Replace(" ", "").ToLower(), "标记有ComVisible特性的类型的基类同样应从标记有ComVisible特性的类继承");
            dic.Add("Com visible types should be creatable ".Replace(" ", "").ToLower(), "标记有ComVisible特性的类型应该能够使用默认构造器构造");


            //11-16
            dic.Add("Declare PInvokes correctly".Replace(" ", "").ToLower(), "正确定义PInvokes");
            dic.Add("Do not use AutoDual ClassInterfaceType ".Replace(" ", "").ToLower(), "不要把System.Runtime.InteropServices.ClassInterfaceAttribute特性的值设置为System.Runtime.InteropServices.ClassInterfaceType.AutoDual");
            dic.Add("Mark boolean pinvoke arguments with MarshalAs".Replace(" ", "").ToLower(), "布尔型的pinvoke参数应该使用System.Runtime.InteropServices.MarshalAsAttribute特性标记");
            dic.Add("Mark ComSource interfaces as IDispatch  ".Replace(" ", "").ToLower(), "将System.Runtime.InteropServices.ComSourceInterfacesAttribute特性标记为System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIDispatch.");
            dic.Add("PInvoke entry points should exist ".Replace(" ", "").ToLower(), "Pinvoke应该存在入口点");
            dic.Add("PInvokes should not be visible".Replace(" ", "").ToLower(), "Pinvoke应该是可见的");

        }
        #endregion

        #region Naming
        private static void naming()
        {
            //1-10
            dic.Add(" Avoid language specific type names in parameters".Replace(" ", "").ToLower(), "避免在参数中使用与特定语言相关的类型（用Uint16代替Ushort）");
            dic.Add(" Avoid type names in parameters ".Replace(" ", "").ToLower(), "避免在外部可见的参数中使用类型名");
            dic.Add("Compound words should be cased correctly ".Replace(" ", "").ToLower(), "复合词应该使用正确的大小写（不要将Mutlipart写成MultiPart，也不要将ToolBar写成Toolbar，FileName写成Filename）");
            dic.Add(" Do not name enum values 'Reserved' ".Replace(" ", "").ToLower(), "不要在枚举值中使用保留字");
            dic.Add("Do not prefix enum values with type name ".Replace(" ", "").ToLower(), "不要在枚举值使用类型前缀（比如不要使用Digital之类的前缀）");
            dic.Add("Events should not have before or after prefix ".Replace(" ", "").ToLower(), "事件的名称不应该包含before和after前缀（尽量使用ing和ed的后缀）");
            dic.Add("Flags enums should have plural names  ".Replace(" ", "").ToLower(), "标记有System.FlagsAttribute特性的枚举应该使用复数形式的名称");
            dic.Add("Identifiers should be cased correctly ".Replace(" ", "").ToLower(), "标示符（名字空间、类名、属性名、接口名、方法名等）应该使用正确的大小写（通常以大写开头，以后的每个单词都首字母大写）");
            dic.Add("Identifiers should be spelled correctly ".Replace(" ", "").ToLower(), "标示符应该可以被正确的划分为不同的单词");
            dic.Add("Identifiers should differ by more than case ".Replace(" ", "").ToLower(), "标示符应该不止有大小写上的不同（因为某些语言是不区分大小写的）");


            //11-20
            dic.Add("Identifiers should have correct prefix ".Replace(" ", "").ToLower(), "标示符应该使用正确的前缀（接口应该使用字母I开头）");
            dic.Add("Identifiers should not contain underscores ".Replace(" ", "").ToLower(), "标示符不应该使用下划线");
            dic.Add(" Identifiers should not have incorrect prefix ".Replace(" ", "").ToLower(), "标示符不应该使用不正确的前缀（比如不应使用一个字母作为前缀）");
            dic.Add("  Identifiers should not match keywords ".Replace(" ", "").ToLower(), "标示符不应该与系统关键字冲突");
            dic.Add("Long acronyms should be pascal-cased ".Replace(" ", "").ToLower(), "长度大于等于3的缩写词应该使用pascal的命名规则，即首字母大写");
            dic.Add("Only FlagsAttribute enums should have plural names ".Replace(" ", "").ToLower(), "只有标记有System.FlagsAttribute特性的枚举的名称才应该使用复数，其他时候应该使用单数");
            dic.Add(" Parameter names should match base declaration ".Replace(" ", "").ToLower(), "派生项的参数名应该同基项相吻合（派生类重写或实现的方法应该同基项具有相同的参数名）");
            dic.Add(" Parameter names should not match member names ".Replace(" ", "").ToLower(), "方法的参数名不应该同类或接口的成员名一样");
            dic.Add("Property names should not match get methods ".Replace(" ", "").ToLower(), "属性名字不应该同Get开头的方法的名称的后半部分相同");
            dic.Add("Resource string compound words should be cased correctly ".Replace(" ", "").ToLower(), "包含符合单词的资源字符串应该使用正确的大小写（每个单词的首字母大写）");


            //21-24
            dic.Add("Resource strings should be spelled correctly ".Replace(" ", "").ToLower(), "资源字符串应该正确的拼写");
            dic.Add("Short acronyms should be uppercase ".Replace(" ", "").ToLower(), "短的首字母缩写词应该全部大写（比如DB，CR）");
            dic.Add("Type names should not match namespaces".Replace(" ", "").ToLower(), "类型的名字不应该与名字空间的名字相同");
            dic.Add("Use preferred terms".Replace(" ", "").ToLower(), "优先使用某些项目或者名称，以下这些，后者为优先使用的");


        }
        #endregion

        #region Performance
        private static void performance()
        {
            //1-10
            dic.Add("Avoid calls that require unboxing ".Replace(" ", "").ToLower(), "避免调用一个方法，它返回object类型，而你需要的是一个值类型（需要对返回值进行拆箱操作）");
            dic.Add("Avoid costly calls where possible ".Replace(" ", "").ToLower(), "尽可能的避免进行代价高昂的调用");
            dic.Add("Avoid excessive locals".Replace(" ", "").ToLower(), "避免使用过多的局部变量（多于64个，部分可能是编译器生成的）");
            dic.Add("Avoid uncalled private code".Replace(" ", "").ToLower(), @"避免声明在程序集内从来未被调用的私有成员（private和internal），以下除外：? 明确的接口成员\r\n? 静态构造方法\r\n? 静态的Main方法（不含参数或仅包含一个string数组的参数的）\r\n? 序列化构造方法\rn? 标记有System.Runtime.InteropServices.ComRegisterFunctionAttribute或者 System.Runtime.InteropServices.ComUnregisterFunctionAttribute.特性的\r\n? 重写的方法");
            dic.Add("Avoid uninstantiated internal classes".Replace(" ", "").ToLower(), @"避免声明不会被实例化的内部类，以下情况除外
\r\n? 值类型
\r\n? 抽象类型
\r\n? 枚举
\r\n? 委托
\r\n? 编译器生成的数组类型
\r\n? 仅含有静态成员的内部类");
            dic.Add("Avoid unnecessary string creation ".Replace(" ", "").ToLower(), @"避免创建不必要的string实例（犹指‘通过ToLower和ToUpper创建的string’），含以下情况
? 对于同一个string实例多次调用ToLower和ToUpper（建议：将返回值赋给一个局部变量，然后使用此局部变量）
? 使用equals,’==‘,!=比较‘通过ToLower和ToUpper创建的string’（建议：使用String.Compare比较）
? 向一个System.Collections.Specialized.HybridDictionary类型的成员传递‘通过ToLower和ToUpper创建的string’（建议：HybridDictionary具有一个指示是否忽略大小写的参数的构造方法重载，使用此重载并传递一个true值进去）");
            dic.Add("Avoid unsealed attributes ".Replace(" ", "").ToLower(), "避免声明未封闭的特性（attributes）（建议：声明为sealed/ NotInheritable-vb.net或者abstract）");
            dic.Add("Avoid unused parameters".Replace(" ", "").ToLower(), @"避免在方法声明中包含不会被使用的参数，以下情况除外
? 代理引用的方法
? 作为事件处理程序的方法
? 抽象方法(abstract)
? 虚方法（virtual）
? 重写的方法（override）
? 外部方法（extern）");
            dic.Add(" Dispose methods should call SuppressFinalize".Replace(" ", "").ToLower(), "Dispose方法应该调用SuppressFinalize，以请求系统不要调用其Finalize方法");
            dic.Add("Do not call properties that clone values in loops".Replace(" ", "").ToLower(), "不要在循环中使用‘返回一个Clone的对象的属性’（每次返回‘引用不同’的对象，会导致创建大量的相同的对象）");


            //11-20
            dic.Add(" Do not cast unnecessarily ".Replace(" ", "").ToLower(), "不要进行不必要的类型转换（特别是尝试性的转换，建议：在转换前可以使用is操作符来判断转换能够成功）");
            dic.Add(" Do not concatenate strings inside loops ".Replace(" ", "").ToLower(), "不要在循环内串联string（建议：使用StringBuilder代替string）");
            dic.Add("  Do not ignore method results ".Replace(" ", "").ToLower(), "不要忽略方法的返回值（通常调用string的方法会返回新的string）");
            dic.Add(" Do not initialize unnecessarily".Replace(" ", "").ToLower(), "不要进行不必要的初始化（比如将类成员初始化为它的默认值）");
            dic.Add("Initialize reference type static fields inline".Replace(" ", "").ToLower(), @"在静态成员声明的时候直接初始化或者调用静态方法初始化（不要使用静态构造方法来初始化静态成员，静态构造方法会影响性能），以下情况除外：
? 初始化对全局状态的影响是代价高昂的，而且类型在使用前不需要进行初始化的
? 在不需要访问该类型的静态成员的情况下，全局状态的影响就可以被访问到的");
            dic.Add("Override equals and operator equals on value types".Replace(" ", "").ToLower(), "对于公有的值类型，重写equals方法和’==‘操作符（如果你期望用户对实例进行比较或者排序，或者作为哈希表的键）");
            dic.Add("Prefer jagged arrays over multidimensional ".Replace(" ", "").ToLower(), @"使用锯齿形数组代替多维数组（当数组各元素的长度可能不一致时）
注意：公共语言规范（CLS）不支持锯齿数组");
            dic.Add("Properties should not return arrays ".Replace(" ", "").ToLower(), "公有类型的属性不应该返回数组（数组类型的属性无法进行写保护，即使是只读的，除非每次返回不同的拷贝，但是这样会让调用者产生迷惑。建议：改成方法）");
            dic.Add("Property names should not match get methods ".Replace(" ", "").ToLower(), "属性名字不应该同Get开头的方法的名称的后半部分相同");
            dic.Add("Remove empty finalizers".Replace(" ", "").ToLower(), "移除空的终结器");


            //21-24
            dic.Add("Test for empty strings using string length".Replace(" ", "").ToLower(), @"使用length属性测试字符串是否为空（原因：不要使用==””、==String..Empty、Equals(“”)等方法，使用Length属性的效率是最高的；null==empty比较不会抛出异常；在DotNetFrameWork2里面可以使用IsNullOrEmpty方法来判断字符串是否为null或者empty）");
            dic.Add(" Use literals where appropriate".Replace(" ", "").ToLower(), "在适当的时候使用const代替static readonly（const是编译时赋值的）");
        }
        #endregion


        #region
        #endregion
    }

    internal class FxCopResultFilter
    {
        private static Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        private FxCopResultFilter()
        { }
        static FxCopResultFilter()
        {
            dic.Add("OutPut", new List<string>());
            OutPutFilterValues();
        }
        private static void OutPutFilterValues()
        {
            List<string> outPutList = dic["OutPut"];
            outPutList.Add("fyiReporting");
            outPutList.Add("DSKHelper");
        }
        public static List<FxCopResultInfo> Filter(string type, List<FxCopResultInfo> fxCopList)
        {
            List<FxCopResultInfo> temp = new List<FxCopResultInfo>();
            if (!string.IsNullOrEmpty(type) && fxCopList != null)
            {
                if (dic.ContainsKey(type))
                {
                    List<string> lt = dic[type];
                    foreach (FxCopResultInfo fcri in fxCopList)
                    {
                        bool exist = false;
                        foreach (string str in lt)
                        {
                            if (fcri.ToString().ToLower().Contains(str.ToLower()))
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (!exist)
                        {
                            temp.Add(fcri);
                        }
                    }
                }
            }
            return temp;
        }
    }
}
