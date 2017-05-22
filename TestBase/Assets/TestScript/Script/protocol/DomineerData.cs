namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="DomineerData")]
    public class DomineerData : IExtensible
    {
        private readonly List<Domineer> _domineers = new List<Domineer>();
        private readonly List<Domineer> _unsaveDomineers = new List<Domineer>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="domineers", DataFormat=DataFormat.Default)]
        public List<Domineer> domineers
        {
            get
            {
                return this._domineers;
            }
        }

        [ProtoMember(2, Name="unsaveDomineers", DataFormat=DataFormat.Default)]
        public List<Domineer> unsaveDomineers
        {
            get
            {
                return this._unsaveDomineers;
            }
        }
    }
}

