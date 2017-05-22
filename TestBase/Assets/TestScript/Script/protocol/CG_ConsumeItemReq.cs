namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_ConsumeItemReq")]
    public class CG_ConsumeItemReq : IExtensible
    {
        private int _amount;
        private int _callback;
        private int _index;
        private int _itemID;
        private string _phoneNum = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="amount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
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

        [ProtoMember(4, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="itemID", DataFormat=DataFormat.TwosComplement)]
        public int itemID
        {
            get
            {
                return this._itemID;
            }
            set
            {
                this._itemID = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="phoneNum", DataFormat=DataFormat.Default), DefaultValue("")]
        public string phoneNum
        {
            get
            {
                return this._phoneNum;
            }
            set
            {
                this._phoneNum = value;
            }
        }
    }
}

