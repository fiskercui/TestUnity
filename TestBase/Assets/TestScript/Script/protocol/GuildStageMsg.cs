namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildStageMsg")]
    public class GuildStageMsg : IExtensible
    {
        private string _msg = "";
        private long _time;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="msg", DataFormat=DataFormat.Default)]
        public string msg
        {
            get
            {
                return this._msg;
            }
            set
            {
                this._msg = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="time", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
    }
}

