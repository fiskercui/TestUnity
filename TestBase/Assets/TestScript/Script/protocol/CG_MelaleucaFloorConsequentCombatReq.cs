namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MelaleucaFloorConsequentCombatReq")]
    public class CG_MelaleucaFloorConsequentCombatReq : IExtensible
    {
        private int _callback;
        private int _combatCount;
        private int _layers;
        private Position _position;
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

        [ProtoMember(3, IsRequired=false, Name="combatCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int combatCount
        {
            get
            {
                return this._combatCount;
            }
            set
            {
                this._combatCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="layers", DataFormat=DataFormat.TwosComplement)]
        public int layers
        {
            get
            {
                return this._layers;
            }
            set
            {
                this._layers = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="position", DataFormat=DataFormat.Default)]
        public Position position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }
    }
}

