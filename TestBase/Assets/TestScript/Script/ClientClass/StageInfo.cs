namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class StageInfo
    {
        private List<AvatarHp> avatarHps = new List<AvatarHp>();
        private int difficult;
        private int eventType;
        private List<ShowReward> extraShowRewards = new List<ShowReward>();
        private int iconId;
        private int index;
        private string name;
        private WeihuaGames.ClientClass.Player player = new WeihuaGames.ClientClass.Player();
        private List<ShowReward> showRewards = new List<ShowReward>();
        private int status;

        public WeihuaGames.ClientClass.StageInfo FromProtobuf(com.kodgames.corgi.protocol.StageInfo stageInfo)
        {
            if (stageInfo != null)
            {
                this.index = stageInfo.index;
                this.eventType = stageInfo.eventType;
                this.status = stageInfo.status;
                this.iconId = stageInfo.iconId;
                this.name = stageInfo.name;
                this.difficult = stageInfo.difficult;
                if (stageInfo.showRewards != null)
                {
                    this.showRewards = stageInfo.showRewards;
                }
                if (stageInfo.extraShowRewards != null)
                {
                    this.extraShowRewards = stageInfo.extraShowRewards;
                }
                if (stageInfo.player != null)
                {
                    WeihuaGames.ClientClass.Player player = new WeihuaGames.ClientClass.Player();
                    player.FromProtobuf(stageInfo.player);
                    this.player = player;
                }
                if (stageInfo.avatarHps != null)
                {
                    this.avatarHps = stageInfo.avatarHps;
                }
            }
            return this;
        }

        public List<AvatarHp> AvatarHps
        {
            get
            {
                return this.avatarHps;
            }
            set
            {
                this.avatarHps = value;
            }
        }

        public int Difficult
        {
            get
            {
                return this.difficult;
            }
            set
            {
                this.difficult = value;
            }
        }

        public int EventType
        {
            get
            {
                return this.eventType;
            }
            set
            {
                this.eventType = value;
            }
        }

        public List<ShowReward> ExtraShowRewards
        {
            get
            {
                return this.extraShowRewards;
            }
            set
            {
                this.extraShowRewards = value;
            }
        }

        public int IconId
        {
            get
            {
                return this.iconId;
            }
            set
            {
                this.iconId = value;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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

        public List<ShowReward> ShowRewards
        {
            get
            {
                return this.showRewards;
            }
            set
            {
                this.showRewards = value;
            }
        }

        public int Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
    }
}

