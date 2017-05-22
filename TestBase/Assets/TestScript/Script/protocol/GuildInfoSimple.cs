namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GuildInfoSimple")]
    public class GuildInfoSimple : IExtensible
    {
        private string _declaration = "";
        private int _guildId;
        private int _guildLevel;
        private string _guildName = "";
        private readonly List<GuildMemberInfo> _members = new List<GuildMemberInfo>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="declaration", DataFormat=DataFormat.Default)]
        public string declaration
        {
            get
            {
                return this._declaration;
            }
            set
            {
                this._declaration = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="guildId", DataFormat=DataFormat.TwosComplement)]
        public int guildId
        {
            get
            {
                return this._guildId;
            }
            set
            {
                this._guildId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="guildLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int guildLevel
        {
            get
            {
                return this._guildLevel;
            }
            set
            {
                this._guildLevel = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="guildName", DataFormat=DataFormat.Default)]
        public string guildName
        {
            get
            {
                return this._guildName;
            }
            set
            {
                this._guildName = value;
            }
        }

        [ProtoMember(5, Name="members", DataFormat=DataFormat.Default)]
        public List<GuildMemberInfo> members
        {
            get
            {
                return this._members;
            }
        }
    }
}

