namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="CycleRewardSet")]
    public class CycleRewardSet : IExtensible
    {
        private int _id;
        private int _showId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static CycleRewardSet LoadFromXml(SecurityElement element)
        {
            return new CycleRewardSet { 
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                showId = StrParser.ParseHexInt(element.Attribute("ShowId"), 0)
            };
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, IsRequired=false, Name="showId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int showId
        {
            get
            {
                return this._showId;
            }
            set
            {
                this._showId = value;
            }
        }
    }
}

