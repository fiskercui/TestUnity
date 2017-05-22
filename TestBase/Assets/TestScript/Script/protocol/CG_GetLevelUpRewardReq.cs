namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GetLevelUpRewardReq")]
    public class CG_GetLevelUpRewardReq : IExtensible
    {
        private int _callback;
        private int _wantPickLevel;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="wantPickLevel", DataFormat=DataFormat.TwosComplement)]
        public int wantPickLevel
        {
            get
            {
                return this._wantPickLevel;
            }
            set
            {
                this._wantPickLevel = value;
            }
        }
    }
}

