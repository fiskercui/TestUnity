﻿namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_PickStartServerRewardReq")]
    public class CG_PickStartServerRewardReq : IExtensible
    {
        private int _callback;
        private int _pickId;
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

        [ProtoMember(2, IsRequired=false, Name="pickId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int pickId
        {
            get
            {
                return this._pickId;
            }
            set
            {
                this._pickId = value;
            }
        }
    }
}

