namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="MarvellousProto")]
    public class MarvellousProto : IExtensible
    {
        private readonly List<int> _completedMarvellousScenarios = new List<int>();
        private int _currentEventId;
        private int _currentmarvellousScenario;
        private int _marvellousId;
        private readonly List<int> _visitZones = new List<int>();
        private int _worldId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="completedMarvellousScenarios", DataFormat=DataFormat.TwosComplement)]
        public List<int> completedMarvellousScenarios
        {
            get
            {
                return this._completedMarvellousScenarios;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="currentEventId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int currentEventId
        {
            get
            {
                return this._currentEventId;
            }
            set
            {
                this._currentEventId = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="currentmarvellousScenario", DataFormat=DataFormat.TwosComplement)]
        public int currentmarvellousScenario
        {
            get
            {
                return this._currentmarvellousScenario;
            }
            set
            {
                this._currentmarvellousScenario = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="marvellousId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int marvellousId
        {
            get
            {
                return this._marvellousId;
            }
            set
            {
                this._marvellousId = value;
            }
        }

        [ProtoMember(3, Name="visitZones", DataFormat=DataFormat.TwosComplement)]
        public List<int> visitZones
        {
            get
            {
                return this._visitZones;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="worldId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int worldId
        {
            get
            {
                return this._worldId;
            }
            set
            {
                this._worldId = value;
            }
        }
    }
}

