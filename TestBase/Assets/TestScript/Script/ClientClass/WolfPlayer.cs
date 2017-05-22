namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class WolfPlayer
    {
        private List<WeihuaGames.ClientClass.Avatar> avatars = new List<WeihuaGames.ClientClass.Avatar>();
        private List<WeihuaGames.ClientClass.Equipment> equipments = new List<WeihuaGames.ClientClass.Equipment>();
        private WeihuaGames.ClientClass.HireDinerData hireDinerData = new WeihuaGames.ClientClass.HireDinerData();
        private string name;
        private int playerId;
        private WeihuaGames.ClientClass.Position position = new WeihuaGames.ClientClass.Position();
        private List<WeihuaGames.ClientClass.Skill> skills = new List<WeihuaGames.ClientClass.Skill>();

        public WeihuaGames.ClientClass.WolfPlayer FromProtobuf(com.kodgames.corgi.protocol.WolfPlayer wolfPlayer)
        {
            if (wolfPlayer != null)
            {
                this.playerId = wolfPlayer.playerId;
                this.name = wolfPlayer.name;
                foreach (com.kodgames.corgi.protocol.Avatar avatar in wolfPlayer.avatars)
                {
                    WeihuaGames.ClientClass.Avatar item = new WeihuaGames.ClientClass.Avatar();
                    item.FromProtobuf(avatar);
                    this.avatars.Add(item);
                }
                foreach (com.kodgames.corgi.protocol.Equipment equipment in wolfPlayer.equipments)
                {
                    WeihuaGames.ClientClass.Equipment equipment2 = new WeihuaGames.ClientClass.Equipment();
                    this.equipments.Add(equipment2.FromProtobuf(equipment));
                }
                foreach (com.kodgames.corgi.protocol.Skill skill in wolfPlayer.skills)
                {
                    WeihuaGames.ClientClass.Skill skill2 = new WeihuaGames.ClientClass.Skill();
                    skill2.FromProtobuf(skill);
                    this.skills.Add(skill2);
                }
                WeihuaGames.ClientClass.HireDinerData data = new WeihuaGames.ClientClass.HireDinerData();
                data.FromProtoBuf(wolfPlayer.hireDinerData);
                this.hireDinerData = data;
                WeihuaGames.ClientClass.Position position = new WeihuaGames.ClientClass.Position();
                position.FromProtobuf(wolfPlayer.position);
                this.position = position;
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

        public WeihuaGames.ClientClass.HireDinerData HireDinerData
        {
            get
            {
                return this.hireDinerData;
            }
            set
            {
                this.hireDinerData = value;
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

