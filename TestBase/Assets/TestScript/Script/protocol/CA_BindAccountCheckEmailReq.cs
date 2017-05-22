namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_BindAccountCheckEmailReq")]
    public class CA_BindAccountCheckEmailReq : IExtensible
    {
        private int _callback;
        private LocalBindAccountCheckEmailReq _localBindAccountCheckEmailReq;
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

        [ProtoMember(2, IsRequired=false, Name="localBindAccountCheckEmailReq", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public LocalBindAccountCheckEmailReq localBindAccountCheckEmailReq
        {
            get
            {
                return this._localBindAccountCheckEmailReq;
            }
            set
            {
                this._localBindAccountCheckEmailReq = value;
            }
        }

        [ProtoContract(Name="LocalBindAccountCheckEmailReq")]
        public class LocalBindAccountCheckEmailReq : IExtensible
        {
            private string _email = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="email", DataFormat=DataFormat.Default), DefaultValue("")]
            public string email
            {
                get
                {
                    return this._email;
                }
                set
                {
                    this._email = value;
                }
            }
        }
    }
}

