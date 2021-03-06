﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="CG_QueryTreasureBowlReq")]
    public class CG_QueryTreasureBowlReq : IExtensible
    {
        private int _callback;
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
    }
}

