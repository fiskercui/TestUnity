namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="Npc")]
    public class Npc : IExtensible
    {
        private int _battlePosition;
        private int _npcId;
        private int _npcType;
        private float _scale;
        private int _talentId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static ClientServerCommon.Npc LoadNpcFromXml(SecurityElement element)
        {
            return new ClientServerCommon.Npc { 
                npcId = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                npcType = TypeNameContainer<_NpcType>.Parse(element.Attribute("NpcType"), 1),
                scale = StrParser.ParseFloat(element.Attribute("Scale"), 1f),
                battlePosition = SceneConfig.ComposeBattlePosition(StrParser.ParseDecInt(element.Attribute("BattleRow"), 0), StrParser.ParseDecInt(element.Attribute("BattleColumn"), 0)),
                talentId = StrParser.ParseHexInt(element.Attribute("TalentId"), 0)
            };
        }

        [ProtoMember(4, IsRequired=false, Name="battlePosition", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int battlePosition
        {
            get
            {
                return this._battlePosition;
            }
            set
            {
                this._battlePosition = value;
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

        [ProtoMember(2, IsRequired=false, Name="npcType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int npcType
        {
            get
            {
                return this._npcType;
            }
            set
            {
                this._npcType = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="scale", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="talentId", DataFormat=DataFormat.TwosComplement)]
        public int talentId
        {
            get
            {
                return this._talentId;
            }
            set
            {
                this._talentId = value;
            }
        }
    }
}

