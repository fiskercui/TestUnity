﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_FetchRandomPlayerNamesReq")]
    public class CG_FetchRandomPlayerNamesReq : IExtensible
    {
        private int _callback;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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
    }
}
