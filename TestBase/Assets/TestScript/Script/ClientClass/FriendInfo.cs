namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class FriendInfo
    {
        private bool isOnLine;
        private long lastLoginTime;
        private int level;
        private long makeFriendTime;
        private string name;
        private int playerId;
        private int power;
        private int showAvatarId;
        private int status;
        private int vipLevel;

        public WeihuaGames.ClientClass.FriendInfo FromProtobuf(com.kodgames.corgi.protocol.FriendInfo friendInfo)
        {
            if (friendInfo != null)
            {
                this.playerId = friendInfo.playerId;
                this.name = friendInfo.name;
                this.level = friendInfo.level;
                this.vipLevel = friendInfo.vipLevel;
                this.lastLoginTime = friendInfo.lastLoginTime;
                this.isOnLine = friendInfo.isOnLine;
                this.status = friendInfo.status;
                this.makeFriendTime = friendInfo.makeFriendTime;
                this.showAvatarId = friendInfo.showAvatarId;
                this.power = friendInfo.power;
            }
            return this;
        }

        public bool IsOnLine
        {
            get
            {
                return this.isOnLine;
            }
            set
            {
                this.isOnLine = value;
            }
        }

        public long LastLoginTime
        {
            get
            {
                return this.lastLoginTime;
            }
            set
            {
                this.lastLoginTime = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public long MakeFriendTime
        {
            get
            {
                return this.makeFriendTime;
            }
            set
            {
                this.makeFriendTime = value;
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

        public int PlayerId
        {
            get
            {
                return this.playerId;
            }
            set
            {
                this.playerId = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public int ShowAvatarId
        {
            get
            {
                return this.showAvatarId;
            }
            set
            {
                this.showAvatarId = value;
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

        public int VipLevel
        {
            get
            {
                return this.vipLevel;
            }
            set
            {
                this.vipLevel = value;
            }
        }
    }
}

