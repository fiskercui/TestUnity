namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class PlayerRecord
    {
        private List<int> avatarBattlePositions = new List<int>();
        private List<int> avatarResourceIds = new List<int>();
        private List<int> datas = new List<int>();
        private List<string> dataStrings = new List<string>();
        private int playerId;
        private int playerLevel;
        private string playerName;
        private int power;
        private int vipLevel;

        public WeihuaGames.ClientClass.PlayerRecord FromProtobuf(com.kodgames.corgi.protocol.PlayerRecord player)
        {
            this.playerId = player.playerId;
            this.playerLevel = player.playerLevel;
            this.playerName = player.playerName;
            this.power = player.power;
            return this;
        }

        public List<int> AvatarBattlePositions
        {
            get
            {
                return this.avatarBattlePositions;
            }
            set
            {
                this.avatarBattlePositions = value;
            }
        }

        public List<int> AvatarResourceIds
        {
            get
            {
                return this.avatarResourceIds;
            }
            set
            {
                this.avatarResourceIds = value;
            }
        }

        public List<int> Datas
        {
            get
            {
                return this.datas;
            }
            set
            {
                this.datas = value;
            }
        }

        public List<string> DataStrings
        {
            get
            {
                return this.dataStrings;
            }
            set
            {
                this.dataStrings = value;
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

        public int PlayerLevel
        {
            get
            {
                return this.playerLevel;
            }
            set
            {
                this.playerLevel = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
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

