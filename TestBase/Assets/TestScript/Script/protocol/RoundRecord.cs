namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="RoundRecord")]
    public class RoundRecord : IExtensible
    {
        private readonly List<ConfigParameter> _customRoundParameters = new List<ConfigParameter>();
        private int _roundIndex;
        private int _roundType;
        private int _rowIndex;
        private int _teamIndex;
        private readonly List<TurnRecord> _turnRecords = new List<TurnRecord>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, Name="customRoundParameters", DataFormat=DataFormat.Default)]
        public List<ConfigParameter> customRoundParameters
        {
            get
            {
                return this._customRoundParameters;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="roundIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int roundIndex
        {
            get
            {
                return this._roundIndex;
            }
            set
            {
                this._roundIndex = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="roundType", DataFormat=DataFormat.TwosComplement)]
        public int roundType
        {
            get
            {
                return this._roundType;
            }
            set
            {
                this._roundType = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="rowIndex", DataFormat=DataFormat.TwosComplement)]
        public int rowIndex
        {
            get
            {
                return this._rowIndex;
            }
            set
            {
                this._rowIndex = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="teamIndex", DataFormat=DataFormat.TwosComplement)]
        public int teamIndex
        {
            get
            {
                return this._teamIndex;
            }
            set
            {
                this._teamIndex = value;
            }
        }

        [ProtoMember(5, Name="turnRecords", DataFormat=DataFormat.Default)]
        public List<TurnRecord> turnRecords
        {
            get
            {
                return this._turnRecords;
            }
        }
    }
}

