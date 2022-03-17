using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using System.Diagnostics;
using System.Data.Common;
namespace Model
{
    abstract class Model
    {
        public int id = 0;
        private string sql = "";
        Dictionary<string, T> ObjectToDictionary<T>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dico = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
            return dico;
        }
        private dynamic DictionaryToObject(Dictionary<String, object> dico)
        {
            var expandoObj = new ExpandoObject();
            var expandoObjCollection = (ICollection<KeyValuePair<String, Object>>)expandoObj;

            foreach (var keyValuePair in dico)
            {
                expandoObjCollection.Add(keyValuePair);
            }
            dynamic eoDynamic = expandoObj;
            return eoDynamic;
        }
        public int save()
        {

            Dictionary<string, string> dico = new Dictionary<string, string>();
            dico = ObjectToDictionary<string>(this);
            if (id == 0)
            {
                sql = "insert into " + this.GetType().Name + "{0} values {1};";
                string attributes="(";
                string values="(";
                int i = 0;
                foreach (var keyValuePair in dico)
                {
                    if (i < dico.Count-1)
                    {
                        attributes += keyValuePair.Key + ",";
                        values += keyValuePair.Value + ",";
                    }
                    else
                    {
                        attributes = keyValuePair.Key+")";
                        values= keyValuePair.Value+")";
                    }
                    i++;
                }

                string a= string.Format(sql, attributes, values);


            }


            else
            {
                sql = "update " + this.GetType().Name + "set {0} where id=" + id+";";
                string pairs="";
                foreach (var keyValuePair in dico) pairs += keyValuePair.Key + " = "+keyValuePair.Value;
                    
                string a=string.Format(sql, pairs);
            }

            return 0;



        }
    public dynamic find()
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            Dictionary<string, string> ch = new Dictionary<string, string>();
            sql = "select * from " + this.GetType().Name + " where id=" + id;
    return DictionaryToObject(dico);
        }
        public int delete()
        {
            sql = "delete from " + this.GetType().Name + " where id=" + id + ";";
            return 0;
        }
        public List<dynamic> All()
        {
          sql="select * from "+ this.GetType().Name+";";
          

           
        }
        public static List<dynamic> all<T>()
        {
            

        }
        public List<dynamic> Select(Dictionary<string, object> dico)
        {
        }
        public static List<dynamic> select<T>(Dictionary<string, object> dico)
        {
            
           
        }
    }

3. Pour tester
}
