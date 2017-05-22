namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_EmBattleReq")]
    public class CG_EmBattleReq : IExtensible
    {
        private int _callback;
        private int _location1;
        private int _location2;
        private int _positionId;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="location1", DataFormat=DataFormat.TwosComplement)]
        public int location1
        {
            get
            {
                return this._location1;
            }
            set
            {
                this._location1 = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="location2", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int location2
        {
            get
            {
                return this._location2;
            }
            set
            {
                this._location2 = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement)]
        public int positionId
        {
            get
            {
                return this._positionId;
            }
            set
            {
                this._positionId = value;
            }
        }
    }
}

