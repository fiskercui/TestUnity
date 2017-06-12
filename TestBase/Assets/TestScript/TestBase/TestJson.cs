
using System;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class TestJson : MonoBehaviour {

    // Use this for initialization



    [Serializable]
    public class MyObject
    {
        public string name;
        public MyNewObject newOjbect;
    }
    [Serializable]
    public class MyNewObject
    {
        public int level;
    }

    void testJson1()
    {
        MyObject myObject = new MyObject();
        myObject.name = "11";
        myObject.newOjbect = new MyNewObject() { level = 100 };

        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);

        myObject = JsonUtility.FromJson<MyObject>(json);
        Debug.Log(myObject.name + " " + myObject.newOjbect.level);

        JsonUtility.FromJsonOverwrite(json, myObject);
    }


    void testJson2()
    {
        TextAsset bindata = Resources.Load("configjson/AccessPathTable") as TextAsset;

        ConfigMgr.getInstance().initConfig<AccessPathTableProperty, AccessPathTableObject>("AccessPathTable", "AccessPathTable", "id");

        AccessPathTableObject t = ConfigMgr.getInstance().getObjectConfig<AccessPathTableObject>("2");
        
        //AccessPathTable table = JsonUtility.FromJson<AccessPathTable>(bindata.ToString());
        //Debug.Log("" + table.itemID);

    }
    void Start () {

        //testJson1();
        testJson2();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
