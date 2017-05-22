namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="BossRank")]
    public class BossRank : IExtensible
    {
        private int _id;
        private int _index;
        private int _mapNum;
        private string _name = "";
        private readonly List<Rank> _ranks = new List<Rank>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="mapNum", DataFormat=DataFormat.TwosComplement)]
        public int mapNum
        {
            get
            {
                return this._mapNum;
            }
            set
            {
                this._mapNum = value;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

        [ProtoMember(5, Name="ranks", DataFormat=DataFormat.Default)]
        public List<Rank> ranks
        {
            get
            {
                return this._ranks;
            }
        }
    }
}

