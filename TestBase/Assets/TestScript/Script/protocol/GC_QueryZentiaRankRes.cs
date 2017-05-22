namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryZentiaRankRes")]
    public class GC_QueryZentiaRankRes : IExtensible
    {
        private int _callback;
        private string _desc = "";
        private int _result;
        private int _totalZentiaPoint;
        private readonly List<ZentiaRank> _zentiaRanks = new List<ZentiaRank>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="desc", DataFormat=DataFormat.Default)]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="totalZentiaPoint", DataFormat=DataFormat.TwosComplement)]
        public int totalZentiaPoint
        {
            get
            {
                return this._totalZentiaPoint;
            }
            set
            {
                this._totalZentiaPoint = value;
            }
        }

        [ProtoMember(4, Name="zentiaRanks", DataFormat=DataFormat.Default)]
        public List<ZentiaRank> zentiaRanks
        {
            get
            {
                return this._zentiaRanks;
            }
        }
    }
}

