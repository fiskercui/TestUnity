using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;


class ConfigMgr
{
    private Dictionary<string, System.Object> m_dict = new Dictionary<string, System.Object>();

    public void TryAdd<TValue>(string path, string key, TValue value)
    {
        if (m_dict.ContainsKey(path) == false)
        {
            m_dict[path] = new Dictionary<string, TValue>();
        }
        else
        {
        }

        Dictionary<string, TValue> dt = m_dict[path] as Dictionary<string, TValue>;
        dt[key] = value;
    }
    public bool initConfig<T1, T2>(string file, string listproperty, string key)
    {
        string path = "configjson";
        //FileInfo fi = new FileInfo(path + "/" + file);
        //FileStream fs = fi.OpenRead();
        //byte[] data = new byte[(int)fi.Length];
        //fs.Read(data, 0, (int)fi.Length);
        TextAsset data = Resources.Load(path + "/" + file) as TextAsset;


        T1 t = default(T1);
        //string str = System.Text.Encoding.UTF8.GetString(data);
        string str = data.ToString();
 
        try
        {
            t = JsonConvert.DeserializeObject<T1>(str);
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());

        }
        //var propertys = t.GetType().GenericTypeArguments[0].GetProperties();
        var properties = t.GetType().GetProperties();
        foreach (var pi in properties)
        {
            var propertyInfo1 = t.GetType().GetProperty(pi.Name);
            List<T2> proValue = propertyInfo1.GetValue(t, null) as List<T2>;
            for (int i = 0; i < proValue.Count; i++)
            {
                var t2 = proValue[i].GetType().GetProperty(key);
                var t2val = t2.GetValue(proValue[i], null);
                string s2Val = (t2val).ToString();
                TryAdd<T2>(typeof(T2).ToString(), s2Val, proValue[i]);
            }
        }
        return true;
    }

    public T getObjectConfig<T>(string key)
    {
        string name = typeof(T).ToString();

        var ret = m_dict[name];
        Dictionary<string, T> retArray = (Dictionary<string, T>)m_dict[name];
        //return (T)retArray[key];

        //T t = default(T);
        return retArray[key];
    }

    private static ConfigMgr _instance = null;
    private ConfigMgr() { }
    public static ConfigMgr getInstance()
    {
        if (_instance == null)
        {
            _instance = new ConfigMgr();
        }
        return _instance;
    }
    //public getObject<>
}
