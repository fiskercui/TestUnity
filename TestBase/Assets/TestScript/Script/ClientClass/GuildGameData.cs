namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class GuildGameData
    {
        private WeihuaGames.ClientClass.ConstructionInfo constructionInfo;
        private List<GuildApplyInfo> guildApplyInfos;
        private List<GuildMemberInfo> guildMembers;
        private WeihuaGames.ClientClass.GuildMiniInfo guildMiniInfo;
        private long publicShopLastNotifyTime;

        public GuildMemberInfo GetGuildMemberByPlayerId(int playerId)
        {
            if (this.guildMembers != null)
            {
                for (int i = 0; i < this.guildMembers.Count; i++)
                {
                    if (this.guildMembers[i].PlayerId == playerId)
                    {
                        return this.guildMembers[i];
                    }
                }
            }
            return null;
        }

        public void RemoveGuildMember(int playerId)
        {
            if (this.guildMembers != null)
            {
                for (int i = 0; i < this.guildMembers.Count; i++)
                {
                    if (this.guildMembers[i].PlayerId == playerId)
                    {
                        this.guildMembers.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        public WeihuaGames.ClientClass.ConstructionInfo ConstructionInfo
        {
            get
            {
                return this.constructionInfo;
            }
            set
            {
                this.constructionInfo = value;
            }
        }

        public List<GuildApplyInfo> GuildApplyInfos
        {
            get
            {
                return this.guildApplyInfos;
            }
            set
            {
                this.guildApplyInfos = value;
            }
        }

        public List<GuildMemberInfo> GuildMembers
        {
            get
            {
                return this.guildMembers;
            }
            set
            {
                this.guildMembers = value;
            }
        }

        public WeihuaGames.ClientClass.GuildMiniInfo GuildMiniInfo
        {
            get
            {
                return this.guildMiniInfo;
            }
            set
            {
                this.guildMiniInfo = value;
            }
        }

        public long PublicShopLastNotifyTime
        {
            get
            {
                return this.publicShopLastNotifyTime;
            }
            set
            {
                this.publicShopLastNotifyTime = value;
            }
        }
    }
}

