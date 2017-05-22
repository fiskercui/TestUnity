namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_FetchRandomPlayerNamesRes")]
    public class GC_FetchRandomPlayerNamesRes : IExtensible
    {
        private int _callback;
        private readonly List<string> _playerNames = new List<string>();
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(3, Name="playerNames", DataFormat=DataFormat.Default)]
        public List<string> playerNames
        {
            get
            {
                return this._playerNames;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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
    }
}

