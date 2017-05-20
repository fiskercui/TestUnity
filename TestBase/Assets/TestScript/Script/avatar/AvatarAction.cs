using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class AvatarAction
{
    public AvatarAction()
    {
    }
    public int actionType { get; set; }
    //public List<Animation> animations { get; }

    public int combatStateType { get; set; }
    //public List<Event> events { get; }
    public int id { get; set; }
    public bool loop { get; set; }
    public int sourceTurnId { get; set; }

    public int weaponType { get; set; }

    public static bool IsBuffActionID(int actionID)
    {
        return true;
    }
    public void AddEvent(Event newEvent)
    {

    }
    public string GetAnimationName(int avatarAssetId)
    {
        return "";
    }


    public class Event
    {
        public Event()
        {
        }

        public string boneName { get; set; }

        public int buffId { get; set; }

        public int buffType { get; set; }

        public float delay { get; set; }

        //public List<Effect> effects { get; }

        public int eventType { get; set; }

        public int index { get; set; }

        public int keyFrameId { get; set; }

        public bool loop { get; set; }

        //public List<PropertyModifierSet> modifierSets { get; }

        public int modifyType { get; set; }

        public bool playOnAllTarget { get; set; }

        public int sourceTurnId { get; set; }

        public int testType { get; set; }

        public int weaponId { get; set; }

        //    public bool IsLogicEvent()
        //    {

        //    }

        //    public class _Type : TypeNameContainer<_Type>
        //    {
        //        public const int AddBuff = 4;
        //        public const int AttributeChange = 31;
        //        public const int BuffTimeUp = 6;
        //        public const int ChangeBattlePosition = 28;
        //        public const int ChangeWeapon = 21;
        //        public const int CompositeSkillStart = 13;
        //        public const int CounterAttackStart = 24;
        //        public const int Damage = 2;
        //        public const int Dan_DamageHeal = 32;
        //        public const int DeleteBuff = 25;
        //        public const int EnterBattleGround = 15;
        //        public const int EnterState = 9;
        //        public const int Heal = 14;
        //        public const int HideWeapon = 19;
        //        public const int InactiveAvatar = 17;
        //        public const int LeaveState = 10;
        //        public const int PlayEffect = 1;
        //        public const int RecoverWeapon = 22;
        //        public const int RefreshBuff = 5;
        //        public const int RemoveAllBuff = 8;
        //        public const int RemoveBuff = 7;
        //        public const int SetBattleTrans = 29;
        //        public const int SetSkillPower = 23;
        //        public const int ShowAvatar = 16;
        //        public const int ShowBattleBar = 30;
        //        public const int ShowDialogue = 27;
        //        public const int ShowWeapon = 20;
        //        public const int SkillStart = 11;
        //        public const int SPDamage = 26;
        //        public const int SuperSkillEffect = 12;
        //        public const int ThrowDamage = 3;
        //        public const int Unknown = 0;

        //        public _Type();

        //        public static bool Initialize();
        //    }
        //}
        //public class _Type : TypeNameContainer<_Type>
        //{
        //    public const int BossAttack = 246;
        //    public const int BossGetHit = 247;
        //    public const int BossRoleDie = 248;
        //    public const int BuffTimeUp = 244;
        //    public const int ChangleCloth = 163;
        //    public const int CombatIdle = 1;
        //    public const int CompositeSkillStart = 25;
        //    public const int CompositeSupporterAction = 26;
        //    public const int Counter = 8;
        //    public const int CounterAttackStart = 24;
        //    public const int CounterAttack_MAP = 23;
        //    public const int CounterAttack_PAP = 22;
        //    public const int CoverPosition = 2;
        //    public const int Dan_DmgHeal = 27;
        //    public const int DefaultIdle = 253;
        //    public const int DefaultRole = 251;
        //    public const int Dialogue = 250;
        //    public const int Die = 11;
        //    public const int Die_KO = 12;
        //    public const int Dodge = 5;
        //    public const int DodgeBack = 6;
        //    public const int EnterBattleGround = 9;
        //    public const int EnterBlockingState = 240;
        //    public const int EnterScene = 10;
        //    public const int GetHit = 7;
        //    public const int Idle = 160;
        //    public const int IllusionUIIdle = 208;
        //    public const int IllusionUISelectRole = 209;
        //    public const int Interface = 28;
        //    public const int Lose = 16;
        //    public const int MaxRound = 245;
        //    public const int MelaleucaFloorIdle = 254;
        //    public const int NormalAttack = 3;
        //    public const int OnCreateBuff = 241;
        //    public const int OnDeleteBuff = 243;
        //    public const int OnUpdateBuff = 242;
        //    public const int RandomIdle = 161;
        //    public const int Revive = 17;
        //    public const int Run = 164;
        //    public const int SelectRole = 249;
        //    public const int Skill = 129;
        //    public const int SkillStart = 18;
        //    public const int SpecialRole = 252;
        //    public const int SuperSkillEffect = 20;
        //    public const int SuperSkillStart = 19;
        //    public const int SwitchColumn = 4;
        //    public const int TurnBack = 14;
        //    public const int TurnRush = 13;
        //    public const int Unknown = 0;
        //    public const int UseItem = 21;
        //    public const int Walk = 162;
        //    public const int Win = 15;

        //    public _Type();

        //    public static bool Initialize();
        //}
    }
}