namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="QinInfoRank")]
    public class QinInfoRank : IExtensible
    {
        private int _maxContinueRightCount;
        private string _name = "";
        private int _rank;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="maxContinueRightCount", DataFormat=DataFormat.TwosComplement)]
        public int maxContinueRightCount
        {
            get
            {
                return this._maxContinueRightCount;
            }
            set
            {
                this._maxContinueRightCount = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

        [ProtoMember(1, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }
    }
}

