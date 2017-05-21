namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="LevelConfig")]
    public class LevelConfig : Configuration, IExtensible
    {
        private GiveMeFiveConfig _giveMeFiveConfig;
        private readonly List<Level> _levels = new List<Level>();
        private readonly List<PlayerLevel> _playerLevels = new List<PlayerLevel>();
        private int _playerMaxLevel;
        private IExtension extensionObject;

        public bool GetFunctionStatusByOpenFunction(int openFunction)
        {
            foreach (PlayerLevel level in this._playerLevels)
            {
                foreach (FunctionInfo info in level.functionInfos)
                {
                    if (info.openFunction == openFunction)
                    {
                        return info.status;
                    }
                }
            }
            return false;
        }

        public string GetGiveFiveUrlSettingByDeviceType(int deviceType)
        {
            foreach (GiveMeFiveConfig.UrlSetting setting in this.giveMeFiveConfig.urlSettings)
            {
                if (deviceType == setting.device)
                {
                    return setting.value;
                }
            }
            return string.Empty;
        }

        public Level GetLevelByLevel(int level)
        {
            int num = level - 1;
            if ((num >= 0) && (num < this.levels.Count))
            {
                return this.levels[num];
            }
            return null;
        }

        public PlayerLevel GetPlayerLevelByLevel(int level)
        {
            foreach (PlayerLevel level2 in this._playerLevels)
            {
                if (level2.playerLevel == level)
                {
                    return level2;
                }
            }
            return null;
        }

        public int GetPlayerLevelByOpenFunciton(int openFunction)
        {
            foreach (PlayerLevel level in this._playerLevels)
            {
                foreach (FunctionInfo info in level.functionInfos)
                {
                    if (info.openFunction == openFunction)
                    {
                        return level.playerLevel;
                    }
                }
            }
            return 0;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "LevelConfig")
            {
                this.playerMaxLevel = StrParser.ParseDecInt(element.Attribute("PlayerMaxLevel"), 0);
                if (element.Children != null)
                {
                    foreach (SecurityElement element2 in element.Children)
                    {
                        string tag = element2.Tag;
                        if (tag != null)
                        {
                            if (tag != "Level")
                            {
                                if (tag == "PlayerLevelSet")
                                {
                                    goto Label_0096;
                                }
                                if (tag == "GiveMeFiveConfig")
                                {
                                    goto Label_009F;
                                }
                            }
                            else
                            {
                                this.levels.Add(this.LoadLevelFromXml(element2));
                            }
                        }
                        continue;
                    Label_0096:
                        this.LoadPlayerLevelSetFromXml(element2);
                        continue;
                    Label_009F:
                        this.giveMeFiveConfig = this.LoadGiveMeFiveConfigFromXml(element2);
                    }
                }
            }
        }

        private FunctionInfo LoadFunctionInfoFromXml(SecurityElement element)
        {
            return new FunctionInfo { 
                status = StrParser.ParseBool(element.Attribute("Status"), false),
                openFunction = TypeNameContainer<_OpenFunctionType>.Parse(element.Attribute("OpenFunction"), 0)
            };
        }

        private GiveMeFiveConfig LoadGiveMeFiveConfigFromXml(SecurityElement element)
        {
            GiveMeFiveConfig config = new GiveMeFiveConfig {
                rewardSetId = StrParser.ParseHexInt(element.Attribute("RewardSetId"), 0)
            };
            foreach (SecurityElement element2 in element.Children)
            {
                string tag = element2.Tag;
                if (tag != null)
                {
                    if (tag == "URL")
                    {
                        GiveMeFiveConfig.UrlSetting item = new GiveMeFiveConfig.UrlSetting {
                            device = TypeNameContainer<_DeviceType>.Parse(element2.Attribute("Device"), 0),
                            value = element2.Attribute("Value")
                        };
                        config.urlSettings.Add(item);
                    }
                    else if (tag == "TipPlayerLevel")
                    {
                        goto Label_009F;
                    }
                }
                continue;
            Label_009F:
                config.tipPlayerLevels.Add(StrParser.ParseDecInt(element2.Attribute("PlayerLevel"), 0x7fffffff));
            }
            return config;
        }

        private Level LoadLevelFromXml(SecurityElement element)
        {
            return new Level { playerExp = StrParser.ParseDecInt(element.Attribute("PlayerExp"), 0) };
        }

        private PlayerLevel LoadPlayerLevelFromXml(SecurityElement element)
        {
            PlayerLevel level = new PlayerLevel {
                playerLevel = StrParser.ParseDecInt(element.Attribute("PlayerLevel"), 0),
                levelUpDesc = StrParser.ParseStr(element.Attribute("LevelUpDesc"), ""),
                linkedUIType = TypeNameContainer<_UIType>.Parse(element.Attribute("LinkedUIType"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "FunctionInfo"))
                    {
                        level.functionInfos.Add(this.LoadFunctionInfoFromXml(element2));
                    }
                }
            }
            return level;
        }

        private void LoadPlayerLevelSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "PlayerLevel")
                    {
                        this._playerLevels.Add(this.LoadPlayerLevelFromXml(element2));
                    }
                }
            }
        }

        [ProtoMember(4, IsRequired=false, Name="giveMeFiveConfig", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public GiveMeFiveConfig giveMeFiveConfig
        {
            get
            {
                return this._giveMeFiveConfig;
            }
            set
            {
                this._giveMeFiveConfig = value;
            }
        }

        [ProtoMember(2, Name="levels", DataFormat=DataFormat.Default)]
        public List<Level> levels
        {
            get
            {
                return this._levels;
            }
        }

        [ProtoMember(3, Name="playerLevels", DataFormat=DataFormat.Default)]
        public List<PlayerLevel> playerLevels
        {
            get
            {
                return this._playerLevels;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerMaxLevel", DataFormat=DataFormat.TwosComplement)]
        public int playerMaxLevel
        {
            get
            {
                return this._playerMaxLevel;
            }
            set
            {
                this._playerMaxLevel = value;
            }
        }

        [ProtoContract(Name="FunctionInfo")]
        public class FunctionInfo : IExtensible
        {
            private int _openFunction;
            private bool _status;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="openFunction", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int openFunction
            {
                get
                {
                    return this._openFunction;
                }
                set
                {
                    this._openFunction = value;
                }
            }

            [DefaultValue(false), ProtoMember(2, IsRequired=false, Name="status", DataFormat=DataFormat.Default)]
            public bool status
            {
                get
                {
                    return this._status;
                }
                set
                {
                    this._status = value;
                }
            }
        }

        [ProtoContract(Name="GiveMeFiveConfig")]
        public class GiveMeFiveConfig : IExtensible
        {
            private int _rewardSetId;
            private readonly List<int> _tipPlayerLevels = new List<int>();
            private readonly List<UrlSetting> _urlSettings = new List<UrlSetting>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="rewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int rewardSetId
            {
                get
                {
                    return this._rewardSetId;
                }
                set
                {
                    this._rewardSetId = value;
                }
            }

            [ProtoMember(1, Name="tipPlayerLevels", DataFormat=DataFormat.TwosComplement)]
            public List<int> tipPlayerLevels
            {
                get
                {
                    return this._tipPlayerLevels;
                }
            }

            [ProtoMember(3, Name="urlSettings", DataFormat=DataFormat.Default)]
            public List<UrlSetting> urlSettings
            {
                get
                {
                    return this._urlSettings;
                }
            }

            [ProtoContract(Name="UrlSetting")]
            public class UrlSetting : IExtensible
            {
                private int _device;
                private string _value = "";
                private IExtension extensionObject;

                IExtension IExtensible.GetExtensionObject(bool createIfMissing)
                {
                    return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
                }

                [ProtoMember(1, IsRequired=false, Name="device", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
                public int device
                {
                    get
                    {
                        return this._device;
                    }
                    set
                    {
                        this._device = value;
                    }
                }

                [ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.Default), DefaultValue("")]
                public string value
                {
                    get
                    {
                        return this._value;
                    }
                    set
                    {
                        this._value = value;
                    }
                }
            }
        }

        [ProtoContract(Name="Level")]
        public class Level : IExtensible
        {
            private int _playerExp;
            private readonly List<Reward> _rewards = new List<Reward>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="playerExp", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int playerExp
            {
                get
                {
                    return this._playerExp;
                }
                set
                {
                    this._playerExp = value;
                }
            }

            [ProtoMember(2, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> rewards
            {
                get
                {
                    return this._rewards;
                }
            }
        }

        [ProtoContract(Name="PlayerLevel")]
        public class PlayerLevel : IExtensible
        {
            private readonly List<LevelConfig.FunctionInfo> _functionInfos = new List<LevelConfig.FunctionInfo>();
            private string _levelUpDesc = "";
            private int _linkedUIType;
            private int _playerLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(4, Name="functionInfos", DataFormat=DataFormat.Default)]
            public List<LevelConfig.FunctionInfo> functionInfos
            {
                get
                {
                    return this._functionInfos;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="levelUpDesc", DataFormat=DataFormat.Default)]
            public string levelUpDesc
            {
                get
                {
                    return this._levelUpDesc;
                }
                set
                {
                    this._levelUpDesc = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="linkedUIType", DataFormat=DataFormat.TwosComplement)]
            public int linkedUIType
            {
                get
                {
                    return this._linkedUIType;
                }
                set
                {
                    this._linkedUIType = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
            public int playerLevel
            {
                get
                {
                    return this._playerLevel;
                }
                set
                {
                    this._playerLevel = value;
                }
            }
        }
    }
}

