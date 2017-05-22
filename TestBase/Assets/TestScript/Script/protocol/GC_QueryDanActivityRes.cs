namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryDanActivityRes")]
    public class GC_QueryDanActivityRes : IExtensible
    {
        private string _acitvityName = "";
        private int _callback;
        private readonly List<DanActivityTap> _danActivityTaps = new List<DanActivityTap>();
        private bool _isNeedRefresh;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="acitvityName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string acitvityName
        {
            get
            {
                return this._acitvityName;
            }
            set
            {
                this._acitvityName = value;
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

        [ProtoMember(4, Name="danActivityTaps", DataFormat=DataFormat.Default)]
        public List<DanActivityTap> danActivityTaps
        {
            get
            {
                return this._danActivityTaps;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="isNeedRefresh", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isNeedRefresh
        {
            get
            {
                return this._isNeedRefresh;
            }
            set
            {
                this._isNeedRefresh = value;
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

