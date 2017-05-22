namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_AnswerFriendReq")]
    public class CG_AnswerFriendReq : IExtensible
    {
        private bool _agree;
        private int _callback;
        private long _emailId;
        private int _invitorPlayerId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="agree", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool agree
        {
            get
            {
                return this._agree;
            }
            set
            {
                this._agree = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, IsRequired=false, Name="emailId", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long emailId
        {
            get
            {
                return this._emailId;
            }
            set
            {
                this._emailId = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="invitorPlayerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int invitorPlayerId
        {
            get
            {
                return this._invitorPlayerId;
            }
            set
            {
                this._invitorPlayerId = value;
            }
        }
    }
}

