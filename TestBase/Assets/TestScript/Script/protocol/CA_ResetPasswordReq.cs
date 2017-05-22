namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CA_ResetPasswordReq")]
    public class CA_ResetPasswordReq : IExtensible
    {
        private int _callback;
        private LocalResetPasswordReq _localResetPasswordReq;
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

        [DefaultValue((string) null), ProtoMember(2, IsRequired=false, Name="localResetPasswordReq", DataFormat=DataFormat.Default)]
        public LocalResetPasswordReq localResetPasswordReq
        {
            get
            {
                return this._localResetPasswordReq;
            }
            set
            {
                this._localResetPasswordReq = value;
            }
        }

        [ProtoContract(Name="LocalResetPasswordReq")]
        public class LocalResetPasswordReq : IExtensible
        {
            private string _email = "";
            private string _newPassword = "";
            private string _oldPassword = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="email", DataFormat=DataFormat.Default)]
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

            [ProtoMember(3, IsRequired=false, Name="newPassword", DataFormat=DataFormat.Default), DefaultValue("")]
            public string newPassword
            {
                get
                {
                    return this._newPassword;
                }
                set
                {
                    this._newPassword = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="oldPassword", DataFormat=DataFormat.Default), DefaultValue("")]
            public string oldPassword
            {
                get
                {
                    return this._oldPassword;
                }
                set
                {
                    this._oldPassword = value;
                }
            }
        }
    }
}

