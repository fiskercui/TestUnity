using Pb;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestBase : MonoBehaviour {
    //private Button button;
    //private Image image;

    public class TestDelegate
    {
        public virtual string test() { return ""; }
    }

    public class TestJsonDelegate: TestDelegate
    {

        public override string test()
        {
            Debug.Log("TestJsonDelegate Test\n");
            TextAsset bindata = Resources.Load("configjson/AccessPathTable") as TextAsset;
            ConfigMgr.getInstance().initConfig<AccessPathTableProperty, AccessPathTableObject>("AccessPathTable", "AccessPathTable", "id");
            AccessPathTableObject t = ConfigMgr.getInstance().getObjectConfig<AccessPathTableObject>("2");

            string s = "Json解析测试";
            s += "Chapter:" + t.chapter + "\n";
            s += "Desc:" + t.desc + "\n";
            s += "Icon:" + t.icon + "\n";
            s += "Id:" + t.id + "\n";
            s += "Remark:" + t.remark + "\n";
            s += "Title:" + t.title + "\n";

            return s;
        }
    }


    public class TestProtobufDelegate : TestDelegate
    {
        public override string test()
        {

            string s = "";
            s = "战斗协议数据解析\n";
            TextAsset ta = Resources.Load("battleRecord") as TextAsset;
            FightAnswer fanswer = ProtoBufHelper.DeSerialize<FightAnswer>(ta.bytes);
            //FightAnswer fanswer = fightData;
            uint ret = fanswer.result;
            uint id = fanswer.res;
            List<FightData> datas = fanswer.fightdatas;
            for (int i = 0; i < datas.Count; i++)
            {
                Debug.Log("战斗场数:" + i);
                s += "战斗场数:" + i;
                FightData da = datas[i];
                FightArray fa = da.FightsArray;
                for (int ii = 0; ii < fa.positions.Count; ii++)
                {
                    uint roleId = fa.roleids[ii];
                    uint position = fa.positions[ii];
                    Debug.Log("roleId :" + roleId + " position :" + position);
                    s += "roleId :" + roleId + " position :" + position;
                }

                Debug.Log("初始状态");
                s += "初始状态";
                FighterStatu fStatu = null;
                for (int ii = 0; ii < da.fightersstatu.Count; ii++)
                {
                    fStatu = da.fightersstatu[ii];
                    uint position = fStatu.position;
                    uint anger = fStatu.anger;
                    U64Type hpTotal = fStatu.hptotal;
                    U64Type hp = fStatu.hp;
                    List<uint> buffs = fStatu.buffs;
                    Debug.Log("position:" + position + " anger:" + anger + " hpTotal:" + StringHelper.makeStrGUID(hpTotal) + " hp:" + StringHelper.makeStrGUID(hp));
                    s += "position:" + position + " anger:" + anger + " hpTotal:" + StringHelper.makeStrGUID(hpTotal) + " hp:" + StringHelper.makeStrGUID(hp);
                    for (int iii = 0; iii < buffs.Count; iii++)
                    {
                        uint buffId = buffs[iii];
                    }
                }

                List<FightRound> fightRound = da.round;
                for (int iRound = 0; iRound < fightRound.Count; iRound++)
                {
                    Debug.Log("当前回合" + iRound);
                    s += "当前回合" + iRound;
                    FightRound currRound = fightRound[iRound];
                    List<AttackData> attackPre = currRound.attackPre;
                    List<AttackData> attack = currRound.attack;

                    for (int iAttack = 0; iAttack < attackPre.Count; iAttack++)
                    {
                        Debug.Log("第" + iAttack + "手攻击");
                        s += "第" + iAttack + "手攻击";
                        AttackData atPre = attackPre[iAttack];
                        Debug.Log("技能id" + attack[iAttack].skillid);
                        s += "技能id" + attack[iAttack].skillid;
                        Debug.Log("攻击前attacks:");
                        s += "攻击前attacks:";
                        for (int j = 0; j < atPre.attackers.Count; j++)
                        {
                            Debug.Log("\tidx:" + j + "attackId:" + atPre.attackers[j]);
                            s += "\tidx:" + j + "attackId:" + atPre.attackers[j];
                        }

                        Debug.Log("\n攻击前beattacks:");
                        s += "\n攻击前beattacks:";

                        for (int j = 0; j < atPre.beattackers.Count; j++)
                        {
                            Debug.Log("\tidx:" + j + "beattackId:" + atPre.beattackers[j]);
                            s += "\tidx:" + j + "beattackId:" + atPre.beattackers[j]; 
                        }

                        for (int ii = 0; ii < atPre.newstatus.Count; ii++)
                        {
                            FighterStatu fStatu0 = atPre.newstatus[ii];
                            uint position = fStatu0.position;
                            uint anger = fStatu0.anger;
                            U64Type hpTotal = fStatu0.hptotal;
                            U64Type hp = fStatu0.hp;
                            List<uint> buffs = fStatu0.buffs;
                            Debug.Log("position:" + position + " anger:" + anger + " hpTotal:" + StringHelper.makeStrGUID(hpTotal) + " hp:" + StringHelper.makeStrGUID(hp));
                            s += "position:" + position + " anger:" + anger + " hpTotal:" + StringHelper.makeStrGUID(hpTotal) + " hp:" + StringHelper.makeStrGUID(hp);
                            for (int iii = 0; iii < buffs.Count; iii++)
                            {
                                uint buffId = buffs[iii];
                            }
                        }

                        AttackData at = attack[iAttack];
                        Debug.Log("攻击attacks:");
                        s += "攻击attacks:";
                        for (int j = 0; j < at.attackers.Count; j++)
                        {
                            Debug.Log("\tidx:" + j + " attackId:" + atPre.attackers[j]);
                            s += "\tidx:" + j + " attackId:" + atPre.attackers[j];
                        }

                        Debug.Log("\n攻击beattacks:");
                        s += "\n攻击beattacks:";
                        for (int j = 0; j < at.beattackers.Count; j++)
                        {
                            Debug.Log("\tidx:" + j + " beattackId:" + at.beattackers[j]);
                            s += "\tidx:" + j + " beattackId:" + at.beattackers[j];
                        }

                        for (int ii = 0; ii < at.newstatus.Count; ii++)
                        {
                            FighterStatu fStatu0 = at.newstatus[ii];
                            uint position = fStatu0.position;
                            uint anger = fStatu0.anger;
                            U64Type hpTotal = fStatu0.hptotal;
                            U64Type hp = fStatu0.hp;
                            StringHelper.makeStrGUID(hpTotal);
                            List<uint> buffs = fStatu0.buffs;
                            Debug.Log("position:" + position + " anger:" + anger + " hpTotal:" + StringHelper.makeStrGUID(hpTotal) + " hp:" + StringHelper.makeStrGUID(hp));
                            s += "position:" + position + " anger:" + anger + " hpTotal:" + StringHelper.makeStrGUID(hpTotal) + " hp:" + StringHelper.makeStrGUID(hp);
                            for (int iii = 0; iii < buffs.Count; iii++)
                            {
                                uint buffId = buffs[iii];
                            }
                        }
                    }
                }
            }
            return s;
        }
    }





    private Dictionary<string, TestDelegate> m_DictDelegate = new Dictionary<string, TestDelegate>();

    void testJson()
    {
        TextAsset bindata = Resources.Load("configjson/AccessPathTable") as TextAsset;
        ConfigMgr.getInstance().initConfig<AccessPathTableProperty, AccessPathTableObject>("AccessPathTable", "AccessPathTable", "id");
        AccessPathTableObject t = ConfigMgr.getInstance().getObjectConfig<AccessPathTableObject>("2");

        string s = "";
        GameObject text = GameObject.Find("Canvas/Text");
    }
    // Use this for initialization
    void Start () {

        m_DictDelegate.Add("testJsonButton", new TestJsonDelegate());
        m_DictDelegate.Add("testProtobufButton", new TestProtobufDelegate());


        List<string> list = new List<string>(m_DictDelegate.Keys);

        for (int i = 0; i < m_DictDelegate.Count; i++)
        {
            string name = list[i];
            //TestDelegate cb = m_DictDelegate[name];
            GameObject obj = new GameObject();
            Image img = obj.AddComponent<Image>();
            if (img == null)
            {
                img = obj.AddComponent<Image>();
            }
            Button btn = obj.GetComponent<Button>();
            if (btn == null)
            {
                btn = obj.AddComponent<Button>();
            }

            obj.transform.parent = transform;
            EventTriggerListener.Get(btn.gameObject).onClick = OnButtonClick;

            CanvasRenderer cr = obj.GetComponent<CanvasRenderer>();
            if (cr == null)
            {
                cr = obj.AddComponent<CanvasRenderer>();
            }

            GameObject textObj =  new GameObject();

            textObj.transform.parent = obj.transform;
            Text text = textObj.GetComponent<Text>();
            if (text == null)
            {
                text = textObj.AddComponent<Text>();
            }
            text.text = name;
            text.name = "Text";
            text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text.fontStyle = FontStyle.Normal;
            text.color = new Color(255,00,0);
            text.alignment = TextAnchor.MiddleCenter;
            //text
            RectTransform textRt = textObj.GetComponent<RectTransform>();
            if (textRt == null)
            {
                textRt = textObj.AddComponent<RectTransform>();
            }
            //textRt.st
            //set rect transform to stretch
            textRt.anchorMin = Vector2.zero;
            textRt.anchorMax = Vector2.one;
            textRt.anchoredPosition = Vector2.zero;
            textRt.sizeDelta = Vector2.zero;

            obj.name = name;
            //obj.transform.localPosition = new Vector3(160, -i*30, 0);

            RectTransform rt  = obj.GetComponent<RectTransform>();
            if (rt == null)
            {
                rt =  obj.AddComponent<RectTransform>();
            }
            rt.anchoredPosition3D = new Vector3(160, -40*(i+1), 0);
            rt.anchorMin = new Vector2(0,1);
            rt.anchorMax = new Vector2(0, 1);

            rt.sizeDelta = new Vector2(160, 40);
        }


        ////比较原始的添加事件的方法
        //GameObject btnObj = GameObject.Find("Canvas/TestJsonButton");
        //Button btn = (Button)btnObj.GetComponent<Button>();
        //btn.onClick.AddListener(onClick);

        ////一种遍历的方法
        //for (int i =0;i < transform.childCount; i++)
        //{
        //    Transform obj = transform.GetChild(i);
        //    EventTriggerListener.Get(btn.gameObject).onClick = OnButtonClick;
        //}

    }

    void onClick()
    {
        Debug.Log("onClick");
    }

    // Update is called once per frame
    void Update () {
 
	}



    private void OnButtonClick(GameObject go)
    {
        Debug.Log("onButtonClick"+ go.gameObject.name);
        //在这里监听按钮的点击事件
        TestDelegate dg = m_DictDelegate[go.gameObject.name];
        string ret  = dg.test();

        GameObject text = GameObject.Find("Scroll View/Viewport/Content/Text");
        Text textObj = text.GetComponent<Text>();
        if (textObj != null)
        {
            textObj.text = ret;
        }
        RectTransform textRt = text.GetComponent<RectTransform>();
        textRt.sizeDelta = new Vector2(textRt.sizeDelta.x, textObj.preferredHeight);

        GameObject content = text.transform.parent.gameObject;
        RectTransform contentRt = content.GetComponent<RectTransform>();
        contentRt.sizeDelta = new Vector2(0, textObj.preferredHeight);
    }

    void OnGUI()
    {
        //if (GUI.Button(new Rect(0, 0, 100, 50), "testJson"))
        //{
        //}

        //if (GUI.Button(new Rect(0, 50, 100, 50), "testProtobuf"))
        //{
        //}
    }
}
