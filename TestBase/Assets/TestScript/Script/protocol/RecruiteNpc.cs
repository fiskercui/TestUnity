namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="RecruiteNpc")]
    public class RecruiteNpc : IExtensible
    {
        private readonly List<com.kodgames.corgi.protocol.Attribute> _attributes = new List<com.kodgames.corgi.protocol.Attribute>();
        private int _avatarId;
        private int _breakthroughLevel;
        private int _level;
        private string _name = "";
        private string _npcDesc = "";
        private int _npcId;
        private int _qualityType;
        private readonly List<int> _skillIds = new List<int>();
        private int _traitType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, Name="attributes", DataFormat=DataFormat.Default)]
        public List<com.kodgames.corgi.protocol.Attribute> attributes
        {
            get
            {
                return this._attributes;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="avatarId", DataFormat=DataFormat.TwosComplement)]
        public int avatarId
        {
            get
            {
                return this._avatarId;
            }
            set
            {
                this._avatarId = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="breakthroughLevel", DataFormat=DataFormat.TwosComplement)]
        public int breakthroughLevel
        {
            get
            {
                return this._breakthroughLevel;
            }
            set
            {
                this._breakthroughLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="level", DataFormat=DataFormat.TwosComplement)]
        public int level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [DefaultValue(""), ProtoMember(10, IsRequired=false, Name="npcDesc", DataFormat=DataFormat.Default)]
        public string npcDesc
        {
            get
            {
                return this._npcDesc;
            }
            set
            {
                this._npcDesc = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="npcId", DataFormat=DataFormat.TwosComplement)]
        public int npcId
        {
            get
            {
                return this._npcId;
            }
            set
            {
                this._npcId = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="qualityType", DataFormat=DataFormat.TwosComplement)]
        public int qualityType
        {
            get
            {
                return this._qualityType;
            }
            set
            {
                this._qualityType = value;
            }
        }

        [ProtoMember(5, Name="skillIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> skillIds
        {
            get
            {
                return this._skillIds;
            }
        }

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="traitType", DataFormat=DataFormat.TwosComplement)]
        public int traitType
        {
            get
            {
                return this._traitType;
            }
            set
            {
                this._traitType = value;
            }
        }
    }
}

