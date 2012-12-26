using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenForDsk.CodeGenForDsk.Utils
{
    /// <summary>
    /// 双向映射kev->value,value->key
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class BidirectionalMapping<T1, T2>
    {
        private Dictionary<T1, T2> dic = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> revdic = new Dictionary<T2, T1>();
        private object o = new object();

        public int Count
        {
            get
            {
                return dic.Count;
            }
        }
        public void Clear()
        {
            lock (o)
            {
                dic.Clear();
                revdic.Clear();
            }
        }
        public void Add(T1 t1, T2 t2)
        {
            lock (o)
            {
                if (dic.ContainsKey(t1))
                {
                    dic.Remove(t1);
                }
                dic.Add(t1, t2);
                if (revdic.ContainsKey(t2))
                {
                    revdic.Remove(t2);
                }
                revdic.Add(t2, t1);
            }
        }
        public T2 GetT2(T1 t1)
        {
           // lock (o)
            {
                if (!dic.ContainsKey(t1))
                {
                    return default(T2);
                }
                return dic[t1];
            }
        }
        public T1 GetT1(T2 t2)
        {
         //   lock (o)
            {
                if (!revdic.ContainsKey(t2))
                {
                    return default(T1);
                }
                return revdic[t2];
            }
        }

        public bool ContainsT2(T2 t2)
        {
            return revdic.ContainsKey(t2);
        }
        public bool ContainsT1(T1 t1)
        {
            return dic.ContainsKey(t1);
        }

        public void RemoveByT1(T1 t1)
        {            
            lock (o)
            {
                if (dic.ContainsKey(t1))
                {
                    T2 t2 = dic[t1];
                    dic.Remove(t1);
                    revdic.Remove(t2);
                }                
            }
        }

        public void RemoveByT2(T2 t2)
        {
         
            lock (o)
            {
                if (revdic.ContainsKey(t2))
                {
                    T1 t1 = revdic[t2];
                   revdic.Remove(t2);
                    dic.Remove(t1);
                }               
            }
        }

        public List<T1> GetAllT1()
        {
            List<T1> t1List = new List<T1>();
           // lock (o)
            {                 
                foreach (KeyValuePair<T1, T2> kvp in dic)
                {
                    t1List.Add(kvp.Key);
                }
            }
            return t1List;
        }
        public List<T2> GetAllT2()
        {
            List<T2> t2List = new List<T2>();
           // lock (o)
            {
                foreach (KeyValuePair<T1, T2> kvp in dic)
                {
                    t2List.Add(kvp.Value);
                }
            }
            return t2List;
        }
    }
}
