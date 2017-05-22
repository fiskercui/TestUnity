namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="StartServerRewardInfo")]
    public class StartServerRewardInfo : IExtensible
    {
        private int _dayCont;
        private readonly List<int> _unPickIds = new List<int>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="dayCont", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dayCont
        {
            get
            {
                return this._dayCont;
            }
            set
            {
                this._dayCont = value;
            }
        }

        [ProtoMember(1, Name="unPickIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> unPickIds
        {
            get
            {
                return this._unPickIds;
            }
        }
    }
}

