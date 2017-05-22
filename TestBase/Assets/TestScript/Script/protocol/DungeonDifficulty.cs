namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="DungeonDifficulty")]
    public class DungeonDifficulty : IExtensible
    {
        private readonly List<int> _boxPickedIndexs = new List<int>();
        private int _difficultyType;
        private readonly List<Dungeon> _dungeons = new List<Dungeon>();
        private readonly List<TravelData> _travelDatas = new List<TravelData>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="boxPickedIndexs", DataFormat=DataFormat.TwosComplement)]
        public List<int> boxPickedIndexs
        {
            get
            {
                return this._boxPickedIndexs;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="difficultyType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int difficultyType
        {
            get
            {
                return this._difficultyType;
            }
            set
            {
                this._difficultyType = value;
            }
        }

        [ProtoMember(3, Name="dungeons", DataFormat=DataFormat.Default)]
        public List<Dungeon> dungeons
        {
            get
            {
                return this._dungeons;
            }
        }

        [ProtoMember(4, Name="travelDatas", DataFormat=DataFormat.Default)]
        public List<TravelData> travelDatas
        {
            get
            {
                return this._travelDatas;
            }
        }
    }
}

