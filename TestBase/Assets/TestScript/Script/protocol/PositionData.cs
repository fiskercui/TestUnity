namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="PositionData")]
    public class PositionData : IExtensible
    {
        private int _masterPositionId;
        private readonly List<Position> _positions = new List<Position>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="masterPositionId", DataFormat=DataFormat.TwosComplement)]
        public int masterPositionId
        {
            get
            {
                return this._masterPositionId;
            }
            set
            {
                this._masterPositionId = value;
            }
        }

        [ProtoMember(1, Name="positions", DataFormat=DataFormat.Default)]
        public List<Position> positions
        {
            get
            {
                return this._positions;
            }
        }
    }
}

