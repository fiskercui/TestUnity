namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IllustrationConfig")]
    public class IllustrationConfig : Configuration, IExtensible
    {
        private readonly List<Illustration> _illustrations = new List<Illustration>();
        private Dictionary<int, Illustration> dic_fragments = new Dictionary<int, Illustration>();
        private IExtension extensionObject;
        private Dictionary<int, Illustration> illustrationMap = new Dictionary<int, Illustration>();

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (Illustration illustration in this._illustrations)
            {
                if (!this.illustrationMap.ContainsKey(illustration.Id))
                {
                    this.illustrationMap.Add(illustration.Id, illustration);
                }
                if (!this.dic_fragments.ContainsKey(illustration.FragmentId))
                {
                    this.dic_fragments.Add(illustration.FragmentId, illustration);
                }
            }
        }

        public Illustration GetIllustrationByFragmentId(int fragmentId)
        {
            if (this.dic_fragments.ContainsKey(fragmentId))
            {
                return this.dic_fragments[fragmentId];
            }
            return null;
        }

        public Illustration GetIllustrationById(int id)
        {
            if (this.illustrationMap.ContainsKey(id))
            {
                return this.illustrationMap[id];
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "IllustrationConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Illustration")
                    {
                        Illustration item = new Illustration {
                            Id = StrParser.ParseHexInt(element2.Attribute("Id"), 0),
                            SortIndex = StrParser.ParseDecInt(element2.Attribute("SortIndex"), 0)
                        };
                        foreach (SecurityElement element3 in element2.Children)
                        {
                            if (element3.Tag == "Cost")
                            {
                                Cost cost = new Cost {
                                    id = StrParser.ParseHexInt(element3.Attribute("Id"), 0),
                                    count = StrParser.ParseDecInt(element3.Attribute("Count"), 0)
                                };
                                item.Cost.Add(cost);
                            }
                            if (element3.Tag == "Fragment")
                            {
                                item.FragmentId = StrParser.ParseHexInt(element3.Attribute("Id"), 0);
                                item.FragmentCount = StrParser.ParseDecInt(element3.Attribute("Count"), 0);
                            }
                        }
                        this._illustrations.Add(item);
                    }
                }
            }
        }

        [ProtoMember(1, Name="illustrations", DataFormat=DataFormat.Default)]
        public List<Illustration> Illustrations
        {
            get
            {
                return this._illustrations;
            }
        }

        [ProtoContract(Name="Illustration")]
        public class Illustration : IExtensible
        {
            private readonly List<ClientServerCommon.Cost> _cost = new List<ClientServerCommon.Cost>();
            private int _fragmentCount;
            private int _fragmentId;
            private int _id;
            private int _sortIndex;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, Name="cost", DataFormat=DataFormat.Default)]
            public List<ClientServerCommon.Cost> Cost
            {
                get
                {
                    return this._cost;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="fragmentCount", DataFormat=DataFormat.TwosComplement)]
            public int FragmentCount
            {
                get
                {
                    return this._fragmentCount;
                }
                set
                {
                    this._fragmentCount = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="fragmentId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int FragmentId
            {
                get
                {
                    return this._fragmentId;
                }
                set
                {
                    this._fragmentId = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
            public int Id
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

            [ProtoMember(5, IsRequired=false, Name="sortIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int SortIndex
            {
                get
                {
                    return this._sortIndex;
                }
                set
                {
                    this._sortIndex = value;
                }
            }
        }
    }
}

