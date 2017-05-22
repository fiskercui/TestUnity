namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Position")]
    public class Position : IExtensible
    {
        private readonly List<Location> _avatarLocations = new List<Location>();
        private readonly List<Location> _beastLocations = new List<Location>();
        private readonly List<Location> _danLocations = new List<Location>();
        private int _employLocationId;
        private int _employShowLocationId;
        private readonly List<Location> _equipLocations = new List<Location>();
        private readonly List<Pair> _pairs = new List<Pair>();
        private readonly List<Partner> _partners = new List<Partner>();
        private int _positionId;
        private readonly List<Location> _skillLocations = new List<Location>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="avatarLocations", DataFormat=DataFormat.Default)]
        public List<Location> avatarLocations
        {
            get
            {
                return this._avatarLocations;
            }
        }

        [ProtoMember(10, Name="beastLocations", DataFormat=DataFormat.Default)]
        public List<Location> beastLocations
        {
            get
            {
                return this._beastLocations;
            }
        }

        [ProtoMember(9, Name="danLocations", DataFormat=DataFormat.Default)]
        public List<Location> danLocations
        {
            get
            {
                return this._danLocations;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="employLocationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int employLocationId
        {
            get
            {
                return this._employLocationId;
            }
            set
            {
                this._employLocationId = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="employShowLocationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int employShowLocationId
        {
            get
            {
                return this._employShowLocationId;
            }
            set
            {
                this._employShowLocationId = value;
            }
        }

        [ProtoMember(2, Name="equipLocations", DataFormat=DataFormat.Default)]
        public List<Location> equipLocations
        {
            get
            {
                return this._equipLocations;
            }
        }

        [ProtoMember(8, Name="pairs", DataFormat=DataFormat.Default)]
        public List<Pair> pairs
        {
            get
            {
                return this._pairs;
            }
        }

        [ProtoMember(6, Name="partners", DataFormat=DataFormat.Default)]
        public List<Partner> partners
        {
            get
            {
                return this._partners;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, Name="skillLocations", DataFormat=DataFormat.Default)]
        public List<Location> skillLocations
        {
            get
            {
                return this._skillLocations;
            }
        }
    }
}

