namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class FriendCampaignPosition
    {
        private List<WeihuaGames.ClientClass.HpInfo> avatarHpInfos = new List<WeihuaGames.ClientClass.HpInfo>();
        private List<WeihuaGames.ClientClass.Location> locations = new List<WeihuaGames.ClientClass.Location>();
        private WeihuaGames.ClientClass.Player player;
        private double totalLeftHpPercent;

        public WeihuaGames.ClientClass.FriendCampaignPosition FromProtobuf(com.kodgames.corgi.protocol.FriendCampaignPosition friendCampaignPosition)
        {
            if (friendCampaignPosition != null)
            {
                WeihuaGames.ClientClass.Player player = new WeihuaGames.ClientClass.Player();
                player.FromProtobuf(friendCampaignPosition.player);
                this.player = player;
                this.totalLeftHpPercent = friendCampaignPosition.totalLeftHpPercent;
                this.locations.Clear();
                foreach (com.kodgames.corgi.protocol.Location location in friendCampaignPosition.locations)
                {
                    WeihuaGames.ClientClass.Location item = new WeihuaGames.ClientClass.Location();
                    item.FromProtobuf(location);
                    this.locations.Add(item);
                }
                this.avatarHpInfos.Clear();
                foreach (com.kodgames.corgi.protocol.HpInfo info in friendCampaignPosition.avatarHpInfos)
                {
                    WeihuaGames.ClientClass.HpInfo info2 = new WeihuaGames.ClientClass.HpInfo();
                    info2.FromProtobuf(info);
                    this.avatarHpInfos.Add(info2);
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.HpInfo> AvatarHpInfos
        {
            get
            {
                return this.avatarHpInfos;
            }
            set
            {
                this.avatarHpInfos = value;
            }
        }

        public List<WeihuaGames.ClientClass.Location> Locations
        {
            get
            {
                return this.locations;
            }
            set
            {
                this.locations = value;
            }
        }

        public WeihuaGames.ClientClass.Player Player
        {
            get
            {
                return this.player;
            }
            set
            {
                this.player = value;
            }
        }

        public double TotalLeftHpPercent
        {
            get
            {
                return this.totalLeftHpPercent;
            }
            set
            {
                this.totalLeftHpPercent = value;
            }
        }
    }
}

