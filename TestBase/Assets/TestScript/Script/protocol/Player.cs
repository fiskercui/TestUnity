namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Player")]
    public class Player : IExtensible
    {
        private readonly List<int> _appleGoodIds = new List<int>();
        private readonly List<Avatar> _avatars = new List<Avatar>();
        private int _badge;
        private readonly List<Beast> _beasts = new List<Beast>();
        private int _cancelEvaluateLevel;
        private int _challengePoint;
        private readonly List<Consumable> _consumables = new List<Consumable>();
        private int _curentPickedLevel;
        private int _currentChatCount;
        private readonly List<Dan> _dans = new List<Dan>();
        private bool _didCharge;
        private int _energy;
        private int _energyBuyCount;
        private long _energyBuyCountLastResetTime;
        private long _energyLastCalculateTime;
        private readonly List<Equipment> _equipments = new List<Equipment>();
        private int _gameMoney;
        private int _gradePoint;
        private long _gradePointLastCalculateTime;
        private int _guildBossCount;
        private int _guildMoney;
        private int _guildUnreadChatCount;
        private bool _hasEvaluate;
        private HireDinerData _hireDinerData;
        private IllusionData _illusionData;
        private int _iron;
        private long _lastResetChatTime;
        private LevelAttrib _levelAttrib;
        private long _loginTime;
        private int _medals;
        private int _mfDayPoint;
        private string _name = "";
        private int _newCombatEmailCount;
        private int _newFriendEmailCount;
        private int _newGuildEmailCount;
        private int _newSystemEmailCount;
        private int _playerId;
        private PositionData _positionData;
        private int _power;
        private int _qinInfoAnswerCount;
        private long _qinInfoAnswerCountRecoverTime;
        private QuestQuick _questQuick;
        private int _realMoney;
        private int _remainningCostRMB;
        private long _resetChallengePointTime;
        private SignData _signData;
        private readonly List<Skill> _skills = new List<Skill>();
        private int _soul;
        private int _spirit;
        private int _stamina;
        private int _staminaBuyCount;
        private long _staminaBuyCountLastResetTime;
        private long _staminaLastCalculateTime;
        private StartServerRewardInfo _startServerRewardInfo;
        private int _threeToken;
        private int _timeZone;
        private int _totalCostRMB;
        private int _trialStamp;
        private readonly List<int> _unDoneTutorialIds = new List<int>();
        private int _unreadPrivateMsgCount;
        private int _vipLevel;
        private int _wineSoul;
        private int _zentia;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(0x31, Name="appleGoodIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> appleGoodIds
        {
            get
            {
                return this._appleGoodIds;
            }
        }

        [ProtoMember(15, Name="avatars", DataFormat=DataFormat.Default)]
        public List<Avatar> avatars
        {
            get
            {
                return this._avatars;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="badge", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int badge
        {
            get
            {
                return this._badge;
            }
            set
            {
                this._badge = value;
            }
        }

        [ProtoMember(0x3f, Name="beasts", DataFormat=DataFormat.Default)]
        public List<Beast> beasts
        {
            get
            {
                return this._beasts;
            }
        }

        [ProtoMember(0x2a, IsRequired=false, Name="cancelEvaluateLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int cancelEvaluateLevel
        {
            get
            {
                return this._cancelEvaluateLevel;
            }
            set
            {
                this._cancelEvaluateLevel = value;
            }
        }

        [ProtoMember(0x19, IsRequired=false, Name="challengePoint", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int challengePoint
        {
            get
            {
                return this._challengePoint;
            }
            set
            {
                this._challengePoint = value;
            }
        }

        [ProtoMember(0x12, Name="consumables", DataFormat=DataFormat.Default)]
        public List<Consumable> consumables
        {
            get
            {
                return this._consumables;
            }
        }

        [ProtoMember(0x25, IsRequired=false, Name="curentPickedLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int curentPickedLevel
        {
            get
            {
                return this._curentPickedLevel;
            }
            set
            {
                this._curentPickedLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="currentChatCount", DataFormat=DataFormat.TwosComplement)]
        public int currentChatCount
        {
            get
            {
                return this._currentChatCount;
            }
            set
            {
                this._currentChatCount = value;
            }
        }

        [ProtoMember(0x39, Name="dans", DataFormat=DataFormat.Default)]
        public List<Dan> dans
        {
            get
            {
                return this._dans;
            }
        }

        [DefaultValue(false), ProtoMember(0x21, IsRequired=false, Name="didCharge", DataFormat=DataFormat.Default)]
        public bool didCharge
        {
            get
            {
                return this._didCharge;
            }
            set
            {
                this._didCharge = value;
            }
        }

        [DefaultValue(0), ProtoMember(50, IsRequired=false, Name="energy", DataFormat=DataFormat.TwosComplement)]
        public int energy
        {
            get
            {
                return this._energy;
            }
            set
            {
                this._energy = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x34, IsRequired=false, Name="energyBuyCount", DataFormat=DataFormat.TwosComplement)]
        public int energyBuyCount
        {
            get
            {
                return this._energyBuyCount;
            }
            set
            {
                this._energyBuyCount = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x35, IsRequired=false, Name="energyBuyCountLastResetTime", DataFormat=DataFormat.TwosComplement)]
        public long energyBuyCountLastResetTime
        {
            get
            {
                return this._energyBuyCountLastResetTime;
            }
            set
            {
                this._energyBuyCountLastResetTime = value;
            }
        }

        [ProtoMember(0x33, IsRequired=false, Name="energyLastCalculateTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long energyLastCalculateTime
        {
            get
            {
                return this._energyLastCalculateTime;
            }
            set
            {
                this._energyLastCalculateTime = value;
            }
        }

        [ProtoMember(0x10, Name="equipments", DataFormat=DataFormat.Default)]
        public List<Equipment> equipments
        {
            get
            {
                return this._equipments;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="gameMoney", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int gameMoney
        {
            get
            {
                return this._gameMoney;
            }
            set
            {
                this._gameMoney = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x17, IsRequired=false, Name="gradePoint", DataFormat=DataFormat.TwosComplement)]
        public int gradePoint
        {
            get
            {
                return this._gradePoint;
            }
            set
            {
                this._gradePoint = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x18, IsRequired=false, Name="gradePointLastCalculateTime", DataFormat=DataFormat.TwosComplement)]
        public long gradePointLastCalculateTime
        {
            get
            {
                return this._gradePointLastCalculateTime;
            }
            set
            {
                this._gradePointLastCalculateTime = value;
            }
        }

        [ProtoMember(0x3b, IsRequired=false, Name="guildBossCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildBossCount
        {
            get
            {
                return this._guildBossCount;
            }
            set
            {
                this._guildBossCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x3a, IsRequired=false, Name="guildMoney", DataFormat=DataFormat.TwosComplement)]
        public int guildMoney
        {
            get
            {
                return this._guildMoney;
            }
            set
            {
                this._guildMoney = value;
            }
        }

        [ProtoMember(60, IsRequired=false, Name="guildUnreadChatCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildUnreadChatCount
        {
            get
            {
                return this._guildUnreadChatCount;
            }
            set
            {
                this._guildUnreadChatCount = value;
            }
        }

        [DefaultValue(false), ProtoMember(0x29, IsRequired=false, Name="hasEvaluate", DataFormat=DataFormat.Default)]
        public bool hasEvaluate
        {
            get
            {
                return this._hasEvaluate;
            }
            set
            {
                this._hasEvaluate = value;
            }
        }

        [ProtoMember(40, IsRequired=false, Name="hireDinerData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public HireDinerData hireDinerData
        {
            get
            {
                return this._hireDinerData;
            }
            set
            {
                this._hireDinerData = value;
            }
        }

        [ProtoMember(0x36, IsRequired=false, Name="illusionData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public IllusionData illusionData
        {
            get
            {
                return this._illusionData;
            }
            set
            {
                this._illusionData = value;
            }
        }

        [DefaultValue(0), ProtoMember(10, IsRequired=false, Name="iron", DataFormat=DataFormat.TwosComplement)]
        public int iron
        {
            get
            {
                return this._iron;
            }
            set
            {
                this._iron = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(14, IsRequired=false, Name="lastResetChatTime", DataFormat=DataFormat.TwosComplement)]
        public long lastResetChatTime
        {
            get
            {
                return this._lastResetChatTime;
            }
            set
            {
                this._lastResetChatTime = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="levelAttrib", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public LevelAttrib levelAttrib
        {
            get
            {
                return this._levelAttrib;
            }
            set
            {
                this._levelAttrib = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x1c, IsRequired=false, Name="loginTime", DataFormat=DataFormat.ZigZag)]
        public long loginTime
        {
            get
            {
                return this._loginTime;
            }
            set
            {
                this._loginTime = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x2b, IsRequired=false, Name="medals", DataFormat=DataFormat.TwosComplement)]
        public int medals
        {
            get
            {
                return this._medals;
            }
            set
            {
                this._medals = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x30, IsRequired=false, Name="mfDayPoint", DataFormat=DataFormat.TwosComplement)]
        public int mfDayPoint
        {
            get
            {
                return this._mfDayPoint;
            }
            set
            {
                this._mfDayPoint = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [DefaultValue(0), ProtoMember(30, IsRequired=false, Name="newCombatEmailCount", DataFormat=DataFormat.TwosComplement)]
        public int newCombatEmailCount
        {
            get
            {
                return this._newCombatEmailCount;
            }
            set
            {
                this._newCombatEmailCount = value;
            }
        }

        [ProtoMember(0x1f, IsRequired=false, Name="newFriendEmailCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int newFriendEmailCount
        {
            get
            {
                return this._newFriendEmailCount;
            }
            set
            {
                this._newFriendEmailCount = value;
            }
        }

        [ProtoMember(0x3d, IsRequired=false, Name="newGuildEmailCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int newGuildEmailCount
        {
            get
            {
                return this._newGuildEmailCount;
            }
            set
            {
                this._newGuildEmailCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x20, IsRequired=false, Name="newSystemEmailCount", DataFormat=DataFormat.TwosComplement)]
        public int newSystemEmailCount
        {
            get
            {
                return this._newSystemEmailCount;
            }
            set
            {
                this._newSystemEmailCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [ProtoMember(0x2f, IsRequired=false, Name="positionData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public PositionData positionData
        {
            get
            {
                return this._positionData;
            }
            set
            {
                this._positionData = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x3e, IsRequired=false, Name="power", DataFormat=DataFormat.TwosComplement)]
        public int power
        {
            get
            {
                return this._power;
            }
            set
            {
                this._power = value;
            }
        }

        [ProtoMember(0x2d, IsRequired=false, Name="qinInfoAnswerCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int qinInfoAnswerCount
        {
            get
            {
                return this._qinInfoAnswerCount;
            }
            set
            {
                this._qinInfoAnswerCount = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x2e, IsRequired=false, Name="qinInfoAnswerCountRecoverTime", DataFormat=DataFormat.TwosComplement)]
        public long qinInfoAnswerCountRecoverTime
        {
            get
            {
                return this._qinInfoAnswerCountRecoverTime;
            }
            set
            {
                this._qinInfoAnswerCountRecoverTime = value;
            }
        }

        [ProtoMember(0x26, IsRequired=false, Name="questQuick", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public QuestQuick questQuick
        {
            get
            {
                return this._questQuick;
            }
            set
            {
                this._questQuick = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="realMoney", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int realMoney
        {
            get
            {
                return this._realMoney;
            }
            set
            {
                this._realMoney = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x23, IsRequired=false, Name="remainningCostRMB", DataFormat=DataFormat.TwosComplement)]
        public int remainningCostRMB
        {
            get
            {
                return this._remainningCostRMB;
            }
            set
            {
                this._remainningCostRMB = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(0x1a, IsRequired=false, Name="resetChallengePointTime", DataFormat=DataFormat.TwosComplement)]
        public long resetChallengePointTime
        {
            get
            {
                return this._resetChallengePointTime;
            }
            set
            {
                this._resetChallengePointTime = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(0x1b, IsRequired=false, Name="signData", DataFormat=DataFormat.Default)]
        public SignData signData
        {
            get
            {
                return this._signData;
            }
            set
            {
                this._signData = value;
            }
        }

        [ProtoMember(0x11, Name="skills", DataFormat=DataFormat.Default)]
        public List<Skill> skills
        {
            get
            {
                return this._skills;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="soul", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int soul
        {
            get
            {
                return this._soul;
            }
            set
            {
                this._soul = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="spirit", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int spirit
        {
            get
            {
                return this._spirit;
            }
            set
            {
                this._spirit = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x13, IsRequired=false, Name="stamina", DataFormat=DataFormat.TwosComplement)]
        public int stamina
        {
            get
            {
                return this._stamina;
            }
            set
            {
                this._stamina = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x15, IsRequired=false, Name="staminaBuyCount", DataFormat=DataFormat.TwosComplement)]
        public int staminaBuyCount
        {
            get
            {
                return this._staminaBuyCount;
            }
            set
            {
                this._staminaBuyCount = value;
            }
        }

        [ProtoMember(0x16, IsRequired=false, Name="staminaBuyCountLastResetTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long staminaBuyCountLastResetTime
        {
            get
            {
                return this._staminaBuyCountLastResetTime;
            }
            set
            {
                this._staminaBuyCountLastResetTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(20, IsRequired=false, Name="staminaLastCalculateTime", DataFormat=DataFormat.TwosComplement)]
        public long staminaLastCalculateTime
        {
            get
            {
                return this._staminaLastCalculateTime;
            }
            set
            {
                this._staminaLastCalculateTime = value;
            }
        }

        [ProtoMember(0x27, IsRequired=false, Name="startServerRewardInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public StartServerRewardInfo startServerRewardInfo
        {
            get
            {
                return this._startServerRewardInfo;
            }
            set
            {
                this._startServerRewardInfo = value;
            }
        }

        [DefaultValue(0), ProtoMember(11, IsRequired=false, Name="threeToken", DataFormat=DataFormat.TwosComplement)]
        public int threeToken
        {
            get
            {
                return this._threeToken;
            }
            set
            {
                this._threeToken = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x1d, IsRequired=false, Name="timeZone", DataFormat=DataFormat.TwosComplement)]
        public int timeZone
        {
            get
            {
                return this._timeZone;
            }
            set
            {
                this._timeZone = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x22, IsRequired=false, Name="totalCostRMB", DataFormat=DataFormat.TwosComplement)]
        public int totalCostRMB
        {
            get
            {
                return this._totalCostRMB;
            }
            set
            {
                this._totalCostRMB = value;
            }
        }

        [ProtoMember(12, IsRequired=false, Name="trialStamp", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int trialStamp
        {
            get
            {
                return this._trialStamp;
            }
            set
            {
                this._trialStamp = value;
            }
        }

        [ProtoMember(0x24, Name="unDoneTutorialIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> unDoneTutorialIds
        {
            get
            {
                return this._unDoneTutorialIds;
            }
        }

        [ProtoMember(0x2c, IsRequired=false, Name="unreadPrivateMsgCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int unreadPrivateMsgCount
        {
            get
            {
                return this._unreadPrivateMsgCount;
            }
            set
            {
                this._unreadPrivateMsgCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="vipLevel", DataFormat=DataFormat.TwosComplement)]
        public int vipLevel
        {
            get
            {
                return this._vipLevel;
            }
            set
            {
                this._vipLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x37, IsRequired=false, Name="wineSoul", DataFormat=DataFormat.TwosComplement)]
        public int wineSoul
        {
            get
            {
                return this._wineSoul;
            }
            set
            {
                this._wineSoul = value;
            }
        }

        [DefaultValue(0), ProtoMember(0x38, IsRequired=false, Name="zentia", DataFormat=DataFormat.TwosComplement)]
        public int zentia
        {
            get
            {
                return this._zentia;
            }
            set
            {
                this._zentia = value;
            }
        }
    }
}

