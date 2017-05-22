namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="AlchemyClientIcon")]
    public class AlchemyClientIcon : IExtensible
    {
        private long _activityEndTime;
        private string _activityName = "";
        private long _activityStartTime;
        private string _alchemyDesc = "";
        private int _alchemyIcon;
        private int _backIcon;
        private string _NoActivityText = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(7, IsRequired=false, Name="activityEndTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long activityEndTime
        {
            get
            {
                return this._activityEndTime;
            }
            set
            {
                this._activityEndTime = value;
            }
        }

        [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="activityName", DataFormat=DataFormat.Default)]
        public string activityName
        {
            get
            {
                return this._activityName;
            }
            set
            {
                this._activityName = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="activityStartTime", DataFormat=DataFormat.TwosComplement)]
        public long activityStartTime
        {
            get
            {
                return this._activityStartTime;
            }
            set
            {
                this._activityStartTime = value;
            }
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="alchemyDesc", DataFormat=DataFormat.Default)]
        public string alchemyDesc
        {
            get
            {
                return this._alchemyDesc;
            }
            set
            {
                this._alchemyDesc = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="alchemyIcon", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int alchemyIcon
        {
            get
            {
                return this._alchemyIcon;
            }
            set
            {
                this._alchemyIcon = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="backIcon", DataFormat=DataFormat.TwosComplement)]
        public int backIcon
        {
            get
            {
                return this._backIcon;
            }
            set
            {
                this._backIcon = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="NoActivityText", DataFormat=DataFormat.Default), DefaultValue("")]
        public string NoActivityText
        {
            get
            {
                return this._NoActivityText;
            }
            set
            {
                this._NoActivityText = value;
            }
        }
    }
}

