namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryDanDecomposeRes")]
    public class GC_QueryDanDecomposeRes : IExtensible
    {
        private long _activityEndTime;
        private string _activityName = "";
        private long _activityStartTime;
        private int _callback;
        private DecomposeInfo _decomposeInfo;
        private long _nextRefreshTime;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="activityEndTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="activityName", DataFormat=DataFormat.Default)]
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

        [ProtoMember(4, IsRequired=false, Name="activityStartTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="decomposeInfo", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public DecomposeInfo decomposeInfo
        {
            get
            {
                return this._decomposeInfo;
            }
            set
            {
                this._decomposeInfo = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="nextRefreshTime", DataFormat=DataFormat.TwosComplement)]
        public long nextRefreshTime
        {
            get
            {
                return this._nextRefreshTime;
            }
            set
            {
                this._nextRefreshTime = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}

