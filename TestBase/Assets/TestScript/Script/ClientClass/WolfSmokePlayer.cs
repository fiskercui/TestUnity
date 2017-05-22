namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class WolfSmokePlayer
    {
        private List<WeihuaGames.ClientClass.Avatar> avatars = new List<WeihuaGames.ClientClass.Avatar>();
        private List<WeihuaGames.ClientClass.Equipment> equipments = new List<WeihuaGames.ClientClass.Equipment>();
        private string name;
        private int playerId;
        private WeihuaGames.ClientClass.Position position = new WeihuaGames.ClientClass.Position();
        private List<WeihuaGames.ClientClass.Skill> skills = new List<WeihuaGames.ClientClass.Skill>();

        public WeihuaGames.ClientClass.WolfSmokePlayer FromProtobuf(com.kodgames.corgi.protocol.WolfSmokePlayer wolfSmokePlayer)
        {
            if (wolfSmokePlayer != null)
            {
                this.playerId = wolfSmokePlayer.playerId;
                this.name = wolfSmokePlayer.name;
                WeihuaGames.ClientClass.Position position = new WeihuaGames.ClientClass.Position();
                position.FromProtobuf(wolfSmokePlayer.position);
                this.position = position;
                foreach (com.kodgames.corgi.protocol.Avatar avatar in wolfSmokePlayer.avatars)
                {
                    WeihuaGames.ClientClass.Avatar item = new WeihuaGames.ClientClass.Avatar();
                    item.FromProtobuf(avatar);
                    this.avatars.Add(item);
                }
                foreach (com.kodgames.corgi.protocol.Equipment equipment in wolfSmokePlayer.equipments)
                {
                    WeihuaGames.ClientClass.Equipment equipment2 = new WeihuaGames.ClientClass.Equipment();
                    this.equipments.Add(equipment2.FromProtobuf(equipment));
                }
                foreach (com.kodgames.corgi.protocol.Skill skill in wolfSmokePlayer.skills)
                {
                    WeihuaGames.ClientClass.Skill skill2 = new WeihuaGames.ClientClass.Skill();
                    skill2.FromProtobuf(skill);
                    this.skills.Add(skill2);
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.Avatar> Avatars
        {
            get
            {
                return this.avatars;
            }
            set
            {
                this.avatars = value;
            }
        }

        public List<WeihuaGames.ClientClass.Equipment> Equipments
        {
            get
            {
                return this.equipments;
            }
            set
            {
                this.equipments = value;
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

        public WeihuaGames.ClientClass.Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public List<WeihuaGames.ClientClass.Skill> Skills
        {
            get
            {
                return this.skills;
            }
            set
            {
                this.skills = value;
            }
        }
    }
}

