namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class CombatPlayer
    {
        private List<WeihuaGames.ClientClass.CombatAvatarData> combatAvatarDatas = new List<WeihuaGames.ClientClass.CombatAvatarData>();
        private int playerId;

        public WeihuaGames.ClientClass.CombatPlayer FromProtobuf(com.kodgames.corgi.protocol.CombatPlayer protocol)
        {
            this.playerId = protocol.playerId;
            foreach (com.kodgames.corgi.protocol.CombatAvatarData data in protocol.combatAvatarDatas)
            {
                this.combatAvatarDatas.Add(new WeihuaGames.ClientClass.CombatAvatarData().FromProtobuf(data));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.CombatPlayer ToProtobuf()
        {
            com.kodgames.corgi.protocol.CombatPlayer player = new com.kodgames.corgi.protocol.CombatPlayer {
                playerId = this.playerId
            };
            foreach (WeihuaGames.ClientClass.CombatAvatarData data in this.combatAvatarDatas)
            {
                player.combatAvatarDatas.Add(data.ToProtobuf());
            }
            return player;
        }

        public List<WeihuaGames.ClientClass.CombatAvatarData> CombatAvatarDatas
        {
            get
            {
                return this.combatAvatarDatas;
            }
            set
            {
                this.combatAvatarDatas = value;
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
    }
}

