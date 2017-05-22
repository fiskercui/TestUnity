namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryEmailListInfoRes")]
    public class GC_QueryEmailListInfoRes : IExtensible
    {
        private int _callback;
        private readonly List<EmailPlayer> _emailPlayers = new List<EmailPlayer>();
        private long _lastQueryTime;
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

        [ProtoMember(4, Name="emailPlayers", DataFormat=DataFormat.Default)]
        public List<EmailPlayer> emailPlayers
        {
            get
            {
                return this._emailPlayers;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(3, IsRequired=false, Name="lastQueryTime", DataFormat=DataFormat.TwosComplement)]
        public long lastQueryTime
        {
            get
            {
                return this._lastQueryTime;
            }
            set
            {
                this._lastQueryTime = value;
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

