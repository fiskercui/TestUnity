using Pb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextAsset ta = Resources.Load("battleRecord") as TextAsset;
        //FileInfo fi = new FileInfo("Assets/Resources/battleRecord.bytes");
        //FileStream fs = fi.OpenRead();
        //byte[] data = new byte[(int)fi.Length];
        //fs.Read(data, 0, (int)fi.Length);

        FightAnswer fanswer = ProtoBufHelper.DeSerialize<FightAnswer>(ta.bytes);
        dumpFightData(fanswer);
    }


    void dumpFightData(FightAnswer fightData)
    {
        FightAnswer fanswer = fightData;
        uint ret = fanswer.result;
        uint id = fanswer.res;
        List<FightData> datas = fanswer.fightdatas;
        for (int i = 0; i < datas.Count; i++)
        {
            Debug.Log("战斗场数:" + i);
            FightData da = datas[i];
            FightArray fa = da.FightsArray;
            for (int ii = 0; ii < fa.positions.Count; ii++)
            {
                uint roleId = fa.roleids[ii];
                uint position = fa.positions[ii];
                Debug.Log("roleId :" + roleId + " position :" + position);
            }

            Debug.Log("初始状态");
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
                for (int iii = 0; iii < buffs.Count; iii++)
                {
                    uint buffId = buffs[iii];
                }
            }

            List<FightRound> fightRound = da.round;
            for (int iRound = 0; iRound < fightRound.Count; iRound++)
            {
                Debug.Log("当前回合" + iRound);
                FightRound currRound = fightRound[iRound];
                List<AttackData> attackPre = currRound.attackPre;
                List<AttackData> attack = currRound.attack;

                for (int iAttack = 0; iAttack < attackPre.Count; iAttack++)
                {
                    Debug.Log("第" + iAttack + "手攻击");
                    AttackData atPre = attackPre[iAttack];
                    Debug.Log("技能id" + attack[iAttack].skillid);
                    Debug.Log("攻击前attacks:");
                    for (int j = 0; j < atPre.attackers.Count; j++)
                    {
                        Debug.Log("\tidx:" + j + "attackId:" + atPre.attackers[j]);
                    }

                    Debug.Log("\n攻击前beattacks:");
                    for (int j = 0; j < atPre.beattackers.Count; j++)
                    {
                        Debug.Log("\tidx:" + j + "beattackId:" + atPre.beattackers[j]);
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
                        for (int iii = 0; iii < buffs.Count; iii++)
                        {
                            uint buffId = buffs[iii];
                        }
                    }

                    AttackData at = attack[iAttack];
                    Debug.Log("攻击attacks:");
                    for (int j = 0; j < at.attackers.Count; j++)
                    {
                        Debug.Log("\tidx:" + j + " attackId:" + atPre.attackers[j]);
                    }

                    Debug.Log("\n攻击beattacks:");
                    for (int j = 0; j < at.beattackers.Count; j++)
                    {
                        Debug.Log("\tidx:" + j + " beattackId:" + at.beattackers[j]);
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
                        for (int iii = 0; iii < buffs.Count; iii++)
                        {
                            uint buffId = buffs[iii];
                        }
                    }
                }
            }
        }
    }

    void StartBattle(FightAnswer fightData)
    {


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
