namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryTravelRes")]
    public class GC_QueryTravelRes : IExtensible
    {
        private int _callback;
        private int _result;
        private TravelData _travelData;
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

        [ProtoMember(3, IsRequired=false, Name="travelData", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public TravelData travelData
        {
            get
            {
                return this._travelData;
            }
            set
            {
                this._travelData = value;
            }
        }
    }
}

