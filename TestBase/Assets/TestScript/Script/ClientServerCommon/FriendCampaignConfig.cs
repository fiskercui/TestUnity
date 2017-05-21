namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="FriendCampaignConfig")]
    public class FriendCampaignConfig : Configuration, IExtensible
    {
        private int _friendOffLineTime;
        private readonly List<ClientServerCommon.MainType> _mainTypes = new List<ClientServerCommon.MainType>();
        private int _maxHelpFriendCount;
        private readonly List<Stage> _stages = new List<Stage>();
        private IExtension extensionObject;

        public float GetEnemyAdditionByStageId(int stageId)
        {
            Stage stageById = this.GetStageById(stageId);
            if (stageById != null)
            {
                return stageById.EnemyRecoverHp;
            }
            return 0f;
        }

        public Stage GetFirstStage()
        {
            return this._stages[0];
        }

        public int GetNexStageById(int stageId)
        {
            int num = 1;
            if (stageId == 0)
            {
                return num;
            }
            for (int i = 0; i < this._stages.Count; i++)
            {
                num++;
                if (stageId == this._stages[i].StageId)
                {
                    break;
                }
            }
            if (num <= this._stages.Count)
            {
                return num;
            }
            return (num - 1);
        }

        public int GetNextStageIdById(int stageId)
        {
            if (stageId == 0)
            {
                if ((this._stages != null) && (this._stages.Count > 0))
                {
                    return this._stages[0].StageId;
                }
            }
            else
            {
                for (int i = 0; i < this._stages.Count; i++)
                {
                    if (this._stages[i].StageId == stageId)
                    {
                        if (i < (this._stages.Count - 1))
                        {
                            return this._stages[i + 1].StageId;
                        }
                        return this._stages[i].StageId;
                    }
                }
            }
            return 0;
        }

        public Stage GetStageById(int stageId)
        {
            foreach (Stage stage in this._stages)
            {
                if (stage.StageId == stageId)
                {
                    return stage;
                }
            }
            return null;
        }

        public int GetStageIndex(int stageId)
        {
            int num = 0;
            if (stageId != 0)
            {
                foreach (Stage stage in this._stages)
                {
                    num++;
                    if (stage.StageId == stageId)
                    {
                        return num;
                    }
                }
            }
            return num;
        }

        public string GetStageNameById(int stageId)
        {
            if (stageId != 0)
            {
                foreach (Stage stage in this._stages)
                {
                    if (stage.StageId == stageId)
                    {
                        return stage.StageName;
                    }
                }
            }
            return string.Empty;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _FriendRenderIcon.Initialize();
        }

        public bool JudgeStageIsJoinById(int stageId, int maxStageId)
        {
            if (maxStageId != 0)
            {
                if (stageId == maxStageId)
                {
                    return true;
                }
                for (int i = 0; i < this._stages.Count; i++)
                {
                    if (stageId == this._stages[i].StageId)
                    {
                        return true;
                    }
                    if (maxStageId == this._stages[i].StageId)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool JudgeStageIsPassById(int stageId)
        {
            if ((this._stages == null) || (this._stages.Count <= 0))
            {
                return false;
            }
            return (stageId == this._stages[this._stages.Count - 1].StageId);
        }

        private EmBattleAttribute LoadAdditionsFromXml(SecurityElement element)
        {
            EmBattleAttribute attribute = new EmBattleAttribute {
                type = TypeNameContainer<PositionConfig._EmBattleType>.Parse(element.Attribute("AffectType"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), null),
                desc = StrParser.ParseStr(element.Attribute("Desc"), null)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "PropertyModifier")
                    {
                        PropertyModifier item = PropertyModifier.LoadFromXml(element2);
                        attribute.modifiers.Add(item);
                    }
                }
            }
            return attribute;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "FriendCampaignConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "MaxHelpFriendCount")
                        {
                            if (tag == "FriendOffLineTime")
                            {
                                goto Label_008F;
                            }
                            if (tag == "StageSet")
                            {
                                goto Label_00A3;
                            }
                            if (tag == "MainTypeSet")
                            {
                                goto Label_00AC;
                            }
                        }
                        else
                        {
                            this._maxHelpFriendCount = StrParser.ParseDecInt(element2.Text, 0);
                        }
                    }
                    continue;
                Label_008F:
                    this._friendOffLineTime = StrParser.ParseDecInt(element2.Text, 0);
                    continue;
                Label_00A3:
                    this.LoadStagesFromXml(element2);
                    continue;
                Label_00AC:
                    this.LoadMainTypeSetFromXml(element2);
                }
            }
        }

        private ClientServerCommon.MainType LoadMainTypeFromXml(SecurityElement element)
        {
            ClientServerCommon.MainType type = new ClientServerCommon.MainType {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    ClientServerCommon.SubType item = this.LoadSubTypeFromXml(element2);
                    if (item != null)
                    {
                        type.subTypes.Add(item);
                    }
                }
            }
            return type;
        }

        private void LoadMainTypeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "MainType")
                    {
                        this._mainTypes.Add(this.LoadMainTypeFromXml(element2));
                    }
                }
            }
        }

        private Stage LoadStageFromXml(SecurityElement element)
        {
            Stage stage = new Stage {
                StageId = StrParser.ParseHexInt(element.Attribute("StageId"), 0),
                StageName = StrParser.ParseStr(element.Attribute("StageName"), ""),
                StageSequence = StrParser.ParseDecInt(element.Attribute("StageSequence"), 0),
                IsUseRobot = StrParser.ParseBool(element.Attribute("IsUseRobot"), false),
                EnemyRecoverHp = StrParser.ParseFloat(element.Attribute("EnemyRecoverHp"), 0f),
                RobotName = StrParser.ParseStr(element.Attribute("RobotName"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "PassRewards")
                        {
                            if (element2.Children != null)
                            {
                                foreach (SecurityElement element3 in element2.Children)
                                {
                                    Reward item = Reward.LoadFromXml(element3);
                                    stage.PassRewards.Add(item);
                                }
                            }
                        }
                        else if (tag == "FirstPassRewards")
                        {
                            goto Label_014F;
                        }
                    }
                    continue;
                Label_014F:
                    if (element2.Children != null)
                    {
                        foreach (SecurityElement element4 in element2.Children)
                        {
                            Reward reward2 = Reward.LoadFromXml(element4);
                            stage.FirstPassRewards.Add(reward2);
                        }
                    }
                }
            }
            return stage;
        }

        private void LoadStagesFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Stage"))
                    {
                        this.Stages.Add(this.LoadStageFromXml(element2));
                    }
                }
            }
        }

        private ClientServerCommon.SubType LoadSubTypeFromXml(SecurityElement element)
        {
            return new ClientServerCommon.SubType { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                name = StrParser.ParseStr(element.Attribute("Name"), "", true),
                desc = StrParser.ParseStr(element.Attribute("Desc"), "", true),
                assetIconId = StrParser.ParseHexInt(element.Attribute("AssetIconId"), 0),
                assetIconType = TypeNameContainer<_FriendRenderIcon>.Parse(element.Attribute("AssetIconType"), 0)
            };
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="friendOffLineTime", DataFormat=DataFormat.TwosComplement)]
        public int FriendOffLineTime
        {
            get
            {
                return this._friendOffLineTime;
            }
            set
            {
                this._friendOffLineTime = value;
            }
        }

        [ProtoMember(3, Name="mainTypes", DataFormat=DataFormat.Default)]
        public List<ClientServerCommon.MainType> MainTypes
        {
            get
            {
                return this._mainTypes;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="maxHelpFriendCount", DataFormat=DataFormat.TwosComplement)]
        public int MaxHelpFriendCount
        {
            get
            {
                return this._maxHelpFriendCount;
            }
            set
            {
                this._maxHelpFriendCount = value;
            }
        }

        [ProtoMember(1, Name="stages", DataFormat=DataFormat.Default)]
        public List<Stage> Stages
        {
            get
            {
                return this._stages;
            }
        }

        public class _FriendRenderIcon : TypeNameContainer<FriendCampaignConfig._FriendRenderIcon>
        {
            public const int RenderLevel = 1;
            public const int Unknow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<FriendCampaignConfig._FriendRenderIcon>.RegisterType("RenderLevel", 1, "RenderLevel"));
            }
        }

        [ProtoContract(Name="RandomEnemy")]
        public class RandomEnemy : IExtensible
        {
            private int _maxNum;
            private readonly List<FriendCampaignConfig.RandomRange> _randomRanges = new List<FriendCampaignConfig.RandomRange>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="maxNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int MaxNum
            {
                get
                {
                    return this._maxNum;
                }
                set
                {
                    this._maxNum = value;
                }
            }

            [ProtoMember(2, Name="randomRanges", DataFormat=DataFormat.Default)]
            public List<FriendCampaignConfig.RandomRange> RandomRanges
            {
                get
                {
                    return this._randomRanges;
                }
            }
        }

        [ProtoContract(Name="RandomRange")]
        public class RandomRange : IExtensible
        {
            private float _lowLimit;
            private int _stageId;
            private float _upLimit;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="lowLimit", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float LowLimit
            {
                get
                {
                    return this._lowLimit;
                }
                set
                {
                    this._lowLimit = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement)]
            public int StageId
            {
                get
                {
                    return this._stageId;
                }
                set
                {
                    this._stageId = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(2, IsRequired=false, Name="upLimit", DataFormat=DataFormat.FixedSize)]
            public float UpLimit
            {
                get
                {
                    return this._upLimit;
                }
                set
                {
                    this._upLimit = value;
                }
            }
        }

        [ProtoContract(Name="Stage")]
        public class Stage : IExtensible
        {
            private EmBattleAttribute _enemyAddition;
            private float _enemyRecoverHp;
            private readonly List<Reward> _firstPassRewards = new List<Reward>();
            private bool _isUseRobot;
            private readonly List<Reward> _passRewards = new List<Reward>();
            private string _robotName = "";
            private int _stageId;
            private string _stageName = "";
            private int _stageSequence;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, IsRequired=false, Name="enemyAddition", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public EmBattleAttribute EnemyAddition
            {
                get
                {
                    return this._enemyAddition;
                }
                set
                {
                    this._enemyAddition = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(9, IsRequired=false, Name="enemyRecoverHp", DataFormat=DataFormat.FixedSize)]
            public float EnemyRecoverHp
            {
                get
                {
                    return this._enemyRecoverHp;
                }
                set
                {
                    this._enemyRecoverHp = value;
                }
            }

            [ProtoMember(8, Name="firstPassRewards", DataFormat=DataFormat.Default)]
            public List<Reward> FirstPassRewards
            {
                get
                {
                    return this._firstPassRewards;
                }
            }

            [DefaultValue(false), ProtoMember(5, IsRequired=false, Name="isUseRobot", DataFormat=DataFormat.Default)]
            public bool IsUseRobot
            {
                get
                {
                    return this._isUseRobot;
                }
                set
                {
                    this._isUseRobot = value;
                }
            }

            [ProtoMember(7, Name="passRewards", DataFormat=DataFormat.Default)]
            public List<Reward> PassRewards
            {
                get
                {
                    return this._passRewards;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="robotName", DataFormat=DataFormat.Default)]
            public string RobotName
            {
                get
                {
                    return this._robotName;
                }
                set
                {
                    this._robotName = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int StageId
            {
                get
                {
                    return this._stageId;
                }
                set
                {
                    this._stageId = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="stageName", DataFormat=DataFormat.Default)]
            public string StageName
            {
                get
                {
                    return this._stageName;
                }
                set
                {
                    this._stageName = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="stageSequence", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int StageSequence
            {
                get
                {
                    return this._stageSequence;
                }
                set
                {
                    this._stageSequence = value;
                }
            }
        }
    }
}

