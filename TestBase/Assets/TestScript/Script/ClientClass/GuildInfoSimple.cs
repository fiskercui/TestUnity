namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class GuildInfoSimple
    {
        private string declaration;
        private int guildId;
        private int guildLevel;
        private string guildName;
        private List<WeihuaGames.ClientClass.GuildMemberInfo> members = new List<WeihuaGames.ClientClass.GuildMemberInfo>();

        public WeihuaGames.ClientClass.GuildInfoSimple FromProtobuf(com.kodgames.corgi.protocol.GuildInfoSimple guildInfoSimple)
        {
            if (guildInfoSimple != null)
            {
                this.guildId = guildInfoSimple.guildId;
                this.guildName = guildInfoSimple.guildName;
                this.guildLevel = guildInfoSimple.guildLevel;
                this.declaration = guildInfoSimple.declaration;
                if (guildInfoSimple.members != null)
                {
                    List<WeihuaGames.ClientClass.GuildMemberInfo> list = new List<WeihuaGames.ClientClass.GuildMemberInfo>();
                    foreach (com.kodgames.corgi.protocol.GuildMemberInfo info in guildInfoSimple.members)
                    {
                        list.Add(new WeihuaGames.ClientClass.GuildMemberInfo().FromProtobuf(info));
                    }
                    this.members = list;
                }
            }
            return this;
        }

        public string Declaration
        {
            get
            {
                return this.declaration;
            }
            set
            {
                this.declaration = value;
            }
        }

        public int GuildId
        {
            get
            {
                return this.guildId;
            }
            set
            {
                this.guildId = value;
            }
        }

        public int GuildLevel
        {
            get
            {
                return this.guildLevel;
            }
            set
            {
                this.guildLevel = value;
            }
        }

        public string GuildName
        {
            get
            {
                return this.guildName;
            }
            set
            {
                this.guildName = value;
            }
        }

        public List<WeihuaGames.ClientClass.GuildMemberInfo> Members
        {
            get
            {
                return this.members;
            }
            set
            {
                this.members = value;
            }
        }
    }
}

