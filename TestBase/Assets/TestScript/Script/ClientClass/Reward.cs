namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class Reward
    {
        private List<WeihuaGames.ClientClass.Avatar> avatar = new List<WeihuaGames.ClientClass.Avatar>();
        private List<WeihuaGames.ClientClass.Beast> beast = new List<WeihuaGames.ClientClass.Beast>();
        private List<WeihuaGames.ClientClass.Consumable> consumable = new List<WeihuaGames.ClientClass.Consumable>();
        private List<WeihuaGames.ClientClass.Dan> dan = new List<WeihuaGames.ClientClass.Dan>();
        private List<WeihuaGames.ClientClass.Equipment> equip = new List<WeihuaGames.ClientClass.Equipment>();
        private List<WeihuaGames.ClientClass.Consumable> hideConsumables = new List<WeihuaGames.ClientClass.Consumable>();
        private bool isBeastDecomposed;
        private List<WeihuaGames.ClientClass.Skill> skill = new List<WeihuaGames.ClientClass.Skill>();

        public WeihuaGames.ClientClass.Reward FromProtobuf(com.kodgames.corgi.protocol.Reward reward)
        {
            if (reward != null)
            {
                this.isBeastDecomposed = reward.isBeastDecomposed;
                foreach (com.kodgames.corgi.protocol.Equipment equipment in reward.equips)
                {
                    WeihuaGames.ClientClass.Equipment item = new WeihuaGames.ClientClass.Equipment();
                    item.FromProtobuf(equipment);
                    this.equip.Add(item);
                }
                foreach (com.kodgames.corgi.protocol.Avatar avatar in reward.avatars)
                {
                    WeihuaGames.ClientClass.Avatar avatar2 = new WeihuaGames.ClientClass.Avatar();
                    avatar2.FromProtobuf(avatar);
                    this.avatar.Add(avatar2);
                }
                foreach (com.kodgames.corgi.protocol.Skill skill in reward.skills)
                {
                    WeihuaGames.ClientClass.Skill skill2 = new WeihuaGames.ClientClass.Skill();
                    skill2.FromProtobuf(skill);
                    this.skill.Add(skill2);
                }
                foreach (com.kodgames.corgi.protocol.Consumable consumable in reward.consumables)
                {
                    WeihuaGames.ClientClass.Consumable consumable2 = new WeihuaGames.ClientClass.Consumable();
                    consumable2.FromProtobuf(consumable);
                    this.consumable.Add(consumable2);
                }
                foreach (com.kodgames.corgi.protocol.Consumable consumable3 in reward.hideConsumables)
                {
                    WeihuaGames.ClientClass.Consumable consumable4 = new WeihuaGames.ClientClass.Consumable();
                    consumable4.FromProtobuf(consumable3);
                    this.hideConsumables.Add(consumable4);
                }
                foreach (com.kodgames.corgi.protocol.Dan dan in reward.dans)
                {
                    WeihuaGames.ClientClass.Dan dan2 = new WeihuaGames.ClientClass.Dan();
                    dan2.FromProtobuf(dan);
                    this.dan.Add(dan2);
                }
                foreach (com.kodgames.corgi.protocol.Beast beast in reward.beasts)
                {
                    WeihuaGames.ClientClass.Beast beast2 = new WeihuaGames.ClientClass.Beast();
                    beast2.FromProtobuf(beast);
                    this.beast.Add(beast2);
                }
            }
            return this;
        }

        public List<WeihuaGames.ClientClass.Avatar> Avatar
        {
            get
            {
                return this.avatar;
            }
            set
            {
                this.avatar = value;
            }
        }

        public List<WeihuaGames.ClientClass.Beast> Beast
        {
            get
            {
                return this.beast;
            }
            set
            {
                this.beast = value;
            }
        }

        public List<WeihuaGames.ClientClass.Consumable> Consumable
        {
            get
            {
                return this.consumable;
            }
            set
            {
                this.consumable = value;
            }
        }

        public List<WeihuaGames.ClientClass.Dan> Dan
        {
            get
            {
                return this.dan;
            }
            set
            {
                this.dan = value;
            }
        }

        public List<WeihuaGames.ClientClass.Equipment> Equip
        {
            get
            {
                return this.equip;
            }
            set
            {
                this.equip = value;
            }
        }

        public List<WeihuaGames.ClientClass.Consumable> HideConsumables
        {
            get
            {
                return this.hideConsumables;
            }
            set
            {
                this.hideConsumables = value;
            }
        }

        public bool IsBeastDecomposed
        {
            get
            {
                return this.isBeastDecomposed;
            }
            set
            {
                this.isBeastDecomposed = value;
            }
        }

        public List<WeihuaGames.ClientClass.Skill> Skill
        {
            get
            {
                return this.skill;
            }
            set
            {
                this.skill = value;
            }
        }
    }
}

