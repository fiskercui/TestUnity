namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="RewardTypeCount")]
    public class RewardTypeCount : IExtensible
    {
        private int _count;
        private float _possibility;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static RewardTypeCount LoadFromXml(SecurityElement element)
        {
            RewardTypeCount count = new RewardTypeCount {
                possibility = StrParser.ParseFloat(element.Attribute("Possibility"), 1f)
            };
            count.count = StrParser.ParseDecInt(element.Attribute("Count"), count.count);
            return count;
        }

        [ProtoMember(2, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="possibility", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
        public float possibility
        {
            get
            {
                return this._possibility;
            }
            set
            {
                this._possibility = value;
            }
        }
    }
}

