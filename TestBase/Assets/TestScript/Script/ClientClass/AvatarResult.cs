namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class AvatarResult
    {
        private int avatarIndex = -1;
        private WeihuaGames.ClientClass.CombatAvatarData combatAvatarData = new WeihuaGames.ClientClass.CombatAvatarData();
        private WeihuaGames.ClientClass.ActionRecord endAction;
        private int leftHP;
        private int maxHP;
        private int teamIndex = -1;

        public static WeihuaGames.ClientClass.AvatarResult CopyTo(WeihuaGames.ClientClass.AvatarResult theOne)
        {
            WeihuaGames.ClientClass.AvatarResult result = new WeihuaGames.ClientClass.AvatarResult {
                avatarIndex = theOne.avatarIndex,
                teamIndex = theOne.teamIndex,
                maxHP = theOne.maxHP,
                leftHP = theOne.leftHP
            };
            if (theOne.EndAction != null)
            {
                result.endAction = WeihuaGames.ClientClass.ActionRecord.CopyTo(theOne.EndAction);
            }
            result.combatAvatarData.Copy(theOne.CombatAvatarData);
            return result;
        }

        public WeihuaGames.ClientClass.AvatarResult FromProtobuf(com.kodgames.corgi.protocol.AvatarResult protocol)
        {
            this.avatarIndex = protocol.avatarIndex;
            this.teamIndex = protocol.teamIndex;
            this.leftHP = protocol.leftHP;
            this.maxHP = protocol.maxHP;
            if (protocol.endAction != null)
            {
                this.endAction = new WeihuaGames.ClientClass.ActionRecord().FromProtobuf(protocol.endAction);
            }
            if (protocol.combatAvatarData != null)
            {
                this.combatAvatarData = new WeihuaGames.ClientClass.CombatAvatarData().FromProtobuf(protocol.combatAvatarData);
            }
            return this;
        }

        public com.kodgames.corgi.protocol.AvatarResult ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.AvatarResult { 
                avatarIndex = this.avatarIndex,
                teamIndex = this.teamIndex,
                maxHP = this.maxHP,
                leftHP = this.leftHP,
                endAction = (this.endAction != null) ? this.endAction.ToProtobuf() : null,
                combatAvatarData = (this.combatAvatarData != null) ? this.combatAvatarData.ToProtobuf() : null
            };
        }

        public int AvatarIndex
        {
            get
            {
                return this.avatarIndex;
            }
            set
            {
                this.avatarIndex = value;
            }
        }

        public WeihuaGames.ClientClass.CombatAvatarData CombatAvatarData
        {
            get
            {
                return this.combatAvatarData;
            }
            set
            {
                this.combatAvatarData = value;
            }
        }

        public WeihuaGames.ClientClass.ActionRecord EndAction
        {
            get
            {
                return this.endAction;
            }
            set
            {
                this.endAction = value;
            }
        }

        public int LeftHP
        {
            get
            {
                return this.leftHP;
            }
            set
            {
                this.leftHP = value;
            }
        }

        public int MaxHP
        {
            get
            {
                return this.maxHP;
            }
            set
            {
                this.maxHP = value;
            }
        }

        public int TeamIndex
        {
            get
            {
                return this.teamIndex;
            }
            set
            {
                this.teamIndex = value;
            }
        }
    }
}

