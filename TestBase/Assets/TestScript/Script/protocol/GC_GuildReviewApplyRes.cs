namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildReviewApplyRes")]
    public class GC_GuildReviewApplyRes : IExtensible
    {
        private int _callback;
        private int _playerId;
        private int _playerName;
        private bool _refuse;
        private int _result;
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

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="playerName", DataFormat=DataFormat.TwosComplement)]
        public int playerName
        {
            get
            {
                return this._playerName;
            }
            set
            {
                this._playerName = value;
            }
        }

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="refuse", DataFormat=DataFormat.Default)]
        public bool refuse
        {
            get
            {
                return this._refuse;
            }
            set
            {
                this._refuse = value;
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
    }
}

