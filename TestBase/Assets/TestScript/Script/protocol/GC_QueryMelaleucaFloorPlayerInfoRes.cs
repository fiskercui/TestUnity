namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryMelaleucaFloorPlayerInfoRes")]
    public class GC_QueryMelaleucaFloorPlayerInfoRes : IExtensible
    {
        private int _callback;
        private bool _isResetPlayerInfo;
        private int _lastWeeekRank;
        private int _lastWeekLayer;
        private int _lastWeekPoint;
        private MelaleucaFloorInfo _melaleucaFloorInfo;
        private int _result;
        private int _thisWeekLayer;
        private int _thisWeekPoint;
        private int _thisWeekRank;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [ProtoMember(10, IsRequired=false, Name="isResetPlayerInfo", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isResetPlayerInfo
        {
            get
            {
                return this._isResetPlayerInfo;
            }
            set
            {
                this._isResetPlayerInfo = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="lastWeeekRank", DataFormat=DataFormat.TwosComplement)]
        public int lastWeeekRank
        {
            get
            {
                return this._lastWeeekRank;
            }
            set
            {
                this._lastWeeekRank = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="lastWeekLayer", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int lastWeekLayer
        {
            get
            {
                return this._lastWeekLayer;
            }
            set
            {
                this._lastWeekLayer = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="lastWeekPoint", DataFormat=DataFormat.TwosComplement)]
        public int lastWeekPoint
        {
            get
            {
                return this._lastWeekPoint;
            }
            set
            {
                this._lastWeekPoint = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="melaleucaFloorInfo", DataFormat=DataFormat.Default)]
        public MelaleucaFloorInfo melaleucaFloorInfo
        {
            get
            {
                return this._melaleucaFloorInfo;
            }
            set
            {
                this._melaleucaFloorInfo = value;
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

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="thisWeekLayer", DataFormat=DataFormat.TwosComplement)]
        public int thisWeekLayer
        {
            get
            {
                return this._thisWeekLayer;
            }
            set
            {
                this._thisWeekLayer = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="thisWeekPoint", DataFormat=DataFormat.TwosComplement)]
        public int thisWeekPoint
        {
            get
            {
                return this._thisWeekPoint;
            }
            set
            {
                this._thisWeekPoint = value;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="thisWeekRank", DataFormat=DataFormat.TwosComplement)]
        public int thisWeekRank
        {
            get
            {
                return this._thisWeekRank;
            }
            set
            {
                this._thisWeekRank = value;
            }
        }
    }
}

