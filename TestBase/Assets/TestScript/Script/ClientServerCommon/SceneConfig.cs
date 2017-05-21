namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="SceneConfig")]
    public class SceneConfig : Configuration, IExtensible
    {
        private int _activityCampaignSceneId;
        private int _arenaSceneId;
        private int _bossBattleSceneId;
        private int _campaignSceneId;
        private int _gameMovieSceneId;
        private int _guildPointSceneId;
        private int _loginSceneId;
        private int _mainSceneId;
        private int _pveSceneId;
        private int _robSceneId;
        private readonly List<Scene> _scenes = new List<Scene>();
        private int _selectAvatarSceneId;
        private int _towerBattleSceneId;
        private int _towerSceneId;
        private int _viewBossBattleSceneId;
        private int _wolfSmokeSceneId;
        private IExtension extensionObject;
        private Dictionary<int, Scene> id_sceneMap = new Dictionary<int, Scene>();

        public static int ComposeBattlePosition(int row, int column)
        {
            return (((row & 0xffff) << 0x10) | (column & 0xffff));
        }

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Scene scene in this._scenes)
            {
                if (scene != null)
                {
                    if (this.id_sceneMap.ContainsKey(scene.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + scene.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_sceneMap.Add(scene.id, scene);
                    }
                }
            }
        }

        public static int GetBattlePositionColumn(int battlePosition)
        {
            return (battlePosition & 0xffff);
        }

        public static int GetBattlePositionRow(int battlePosition)
        {
            return ((battlePosition >> 0x10) & 0xffff);
        }

        public string GetBgMusicBySceneName(string sceneName)
        {
            foreach (Scene scene in this.scenes)
            {
                if (scene.levelName.Equals(sceneName))
                {
                    return scene.bgMusic;
                }
            }
            return "";
        }

        public Scene GetSceneByID(int id)
        {
            Scene scene;
            if (!this.id_sceneMap.TryGetValue(id, out scene))
            {
                Logger.Error(base.GetType().Name + " Invalid SceneId " + id.ToString("X"), new object[0]);
                return null;
            }
            return scene;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "SceneConfig")
            {
                this._loginSceneId = StrParser.ParseHexInt(element.Attribute("LoginSceneId"), this._loginSceneId);
                this._mainSceneId = StrParser.ParseHexInt(element.Attribute("MainSceneId"), this._mainSceneId);
                this._robSceneId = StrParser.ParseHexInt(element.Attribute("RobSceneId"), this._robSceneId);
                this._arenaSceneId = StrParser.ParseHexInt(element.Attribute("ArenaSceneId"), this._arenaSceneId);
                this._pveSceneId = StrParser.ParseHexInt(element.Attribute("PveSceneId"), this._pveSceneId);
                this._campaignSceneId = StrParser.ParseHexInt(element.Attribute("CampaignSceneId"), this._campaignSceneId);
                this._activityCampaignSceneId = StrParser.ParseHexInt(element.Attribute("ActivityCampaignSceneId"), this._activityCampaignSceneId);
                this._towerSceneId = StrParser.ParseHexInt(element.Attribute("TowerSceneId"), this._towerSceneId);
                this._selectAvatarSceneId = StrParser.ParseHexInt(element.Attribute("SelectAvatarSceneId"), 0);
                this._viewBossBattleSceneId = StrParser.ParseHexInt(element.Attribute("ViewBossBattleSceneId"), 0);
                this._bossBattleSceneId = StrParser.ParseHexInt(element.Attribute("BossBattleSceneId"), 0);
                this._towerBattleSceneId = StrParser.ParseHexInt(element.Attribute("TowerBattleSceneId"), 0);
                this._gameMovieSceneId = StrParser.ParseHexInt(element.Attribute("GameMovieSceneId"), 0);
                this._wolfSmokeSceneId = StrParser.ParseHexInt(element.Attribute("WolfSmokeSceneId"), 0);
                this._guildPointSceneId = StrParser.ParseHexInt(element.Attribute("GuildPointSceneId"), 0);
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "SceneSet"))
                    {
                        this.LoadSceneSetFromXml(element2);
                    }
                }
            }
        }

        private void LoadSceneSetFromXml(SecurityElement element)
        {
            foreach (SecurityElement element2 in element.Children)
            {
                if (element2.Tag == "Scene")
                {
                    Scene item = new Scene {
                        id = StrParser.ParseHexInt(element2.Attribute("Id"), 0),
                        levelName = StrParser.ParseStr(element2.Attribute("LevelName"), ""),
                        BGM = StrParser.ParseStr(element2.Attribute("BGM"), ""),
                        bgMusic = StrParser.ParseStr(element2.Attribute("BgMusic"), "")
                    };
                    this.scenes.Add(item);
                }
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="activityCampaignSceneId", DataFormat=DataFormat.TwosComplement)]
        public int activityCampaignSceneId
        {
            get
            {
                return this._activityCampaignSceneId;
            }
            set
            {
                this._activityCampaignSceneId = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="arenaSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int arenaSceneId
        {
            get
            {
                return this._arenaSceneId;
            }
            set
            {
                this._arenaSceneId = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="bossBattleSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int bossBattleSceneId
        {
            get
            {
                return this._bossBattleSceneId;
            }
            set
            {
                this._bossBattleSceneId = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="campaignSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int campaignSceneId
        {
            get
            {
                return this._campaignSceneId;
            }
            set
            {
                this._campaignSceneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(14, IsRequired=false, Name="gameMovieSceneId", DataFormat=DataFormat.TwosComplement)]
        public int gameMovieSceneId
        {
            get
            {
                return this._gameMovieSceneId;
            }
            set
            {
                this._gameMovieSceneId = value;
            }
        }

        [ProtoMember(0x10, IsRequired=false, Name="guildPointSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildPointSceneId
        {
            get
            {
                return this._guildPointSceneId;
            }
            set
            {
                this._guildPointSceneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="loginSceneId", DataFormat=DataFormat.TwosComplement)]
        public int loginSceneId
        {
            get
            {
                return this._loginSceneId;
            }
            set
            {
                this._loginSceneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="mainSceneId", DataFormat=DataFormat.TwosComplement)]
        public int mainSceneId
        {
            get
            {
                return this._mainSceneId;
            }
            set
            {
                this._mainSceneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="pveSceneId", DataFormat=DataFormat.TwosComplement)]
        public int pveSceneId
        {
            get
            {
                return this._pveSceneId;
            }
            set
            {
                this._pveSceneId = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="robSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int robSceneId
        {
            get
            {
                return this._robSceneId;
            }
            set
            {
                this._robSceneId = value;
            }
        }

        [ProtoMember(1, Name="scenes", DataFormat=DataFormat.Default)]
        public List<Scene> scenes
        {
            get
            {
                return this._scenes;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="selectAvatarSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int selectAvatarSceneId
        {
            get
            {
                return this._selectAvatarSceneId;
            }
            set
            {
                this._selectAvatarSceneId = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="towerBattleSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int towerBattleSceneId
        {
            get
            {
                return this._towerBattleSceneId;
            }
            set
            {
                this._towerBattleSceneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="towerSceneId", DataFormat=DataFormat.TwosComplement)]
        public int towerSceneId
        {
            get
            {
                return this._towerSceneId;
            }
            set
            {
                this._towerSceneId = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="viewBossBattleSceneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int viewBossBattleSceneId
        {
            get
            {
                return this._viewBossBattleSceneId;
            }
            set
            {
                this._viewBossBattleSceneId = value;
            }
        }

        [DefaultValue(0), ProtoMember(15, IsRequired=false, Name="wolfSmokeSceneId", DataFormat=DataFormat.TwosComplement)]
        public int wolfSmokeSceneId
        {
            get
            {
                return this._wolfSmokeSceneId;
            }
            set
            {
                this._wolfSmokeSceneId = value;
            }
        }

        [ProtoContract(Name="Scene")]
        public class Scene : IExtensible
        {
            private string _BGM = "";
            private string _bgMusic = "";
            private int _id;
            private string _levelName = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="BGM", DataFormat=DataFormat.Default)]
            public string BGM
            {
                get
                {
                    return this._BGM;
                }
                set
                {
                    this._BGM = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="bgMusic", DataFormat=DataFormat.Default), DefaultValue("")]
            public string bgMusic
            {
                get
                {
                    return this._bgMusic;
                }
                set
                {
                    this._bgMusic = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
            public int id
            {
                get
                {
                    return this._id;
                }
                set
                {
                    this._id = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="levelName", DataFormat=DataFormat.Default)]
            public string levelName
            {
                get
                {
                    return this._levelName;
                }
                set
                {
                    this._levelName = value;
                }
            }
        }
    }
}

