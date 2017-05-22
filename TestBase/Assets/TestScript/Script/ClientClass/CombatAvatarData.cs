namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class CombatAvatarData
    {
        private List<WeihuaGames.ClientClass.Attribute> attributes = new List<WeihuaGames.ClientClass.Attribute>();
        private int avatarType;
        private int battlePosition;
        private int breakThrough;
        private List<WeihuaGames.ClientClass.BuffData> buffs = new List<WeihuaGames.ClientClass.BuffData>();
        private string displayName = "";
        private List<WeihuaGames.ClientClass.EquipmentData> equipments = new List<WeihuaGames.ClientClass.EquipmentData>();
        private int evaluation;
        private int illusionID;
        private WeihuaGames.ClientClass.LevelAttrib levelAttrib = new WeihuaGames.ClientClass.LevelAttrib();
        private int npcId;
        private int npcType;
        private int resourceId;
        private float scale;
        private List<WeihuaGames.ClientClass.SkillData> skills = new List<WeihuaGames.ClientClass.SkillData>();

        public void Copy(WeihuaGames.ClientClass.CombatAvatarData data)
        {
            this.avatarType = data.avatarType;
            this.resourceId = data.resourceId;
            this.breakThrough = data.breakThrough;
            this.displayName = data.displayName;
            this.battlePosition = data.battlePosition;
            this.evaluation = data.evaluation;
            this.scale = data.scale;
            this.npcType = data.npcType;
            this.levelAttrib.Copy(data.LevelAttrib);
            this.equipments = new List<WeihuaGames.ClientClass.EquipmentData>();
            this.illusionID = data.illusionID;
            foreach (WeihuaGames.ClientClass.EquipmentData data2 in data.equipments)
            {
                WeihuaGames.ClientClass.EquipmentData item = new WeihuaGames.ClientClass.EquipmentData();
                item.Copy(data2);
                this.equipments.Add(item);
            }
            this.skills = new List<WeihuaGames.ClientClass.SkillData>();
            foreach (WeihuaGames.ClientClass.SkillData data4 in data.Skills)
            {
                WeihuaGames.ClientClass.SkillData data5 = new WeihuaGames.ClientClass.SkillData();
                data5.Copy(data4);
                this.skills.Add(data5);
            }
            this.buffs = new List<WeihuaGames.ClientClass.BuffData>();
            foreach (WeihuaGames.ClientClass.BuffData data6 in data.buffs)
            {
                WeihuaGames.ClientClass.BuffData data7 = new WeihuaGames.ClientClass.BuffData();
                data7.Copy(data6);
                this.buffs.Add(data7);
            }
            this.attributes = new List<WeihuaGames.ClientClass.Attribute>();
            foreach (WeihuaGames.ClientClass.Attribute attribute in data.Attributes)
            {
                WeihuaGames.ClientClass.Attribute attribute2 = new WeihuaGames.ClientClass.Attribute();
                attribute2.Copy(attribute);
                this.attributes.Add(attribute2);
            }
        }

        public WeihuaGames.ClientClass.CombatAvatarData FromProtobuf(com.kodgames.corgi.protocol.CombatAvatarData protocol)
        {
            this.avatarType = protocol.avatarType;
            this.resourceId = protocol.resourceId;
            this.breakThrough = protocol.breakThrough;
            this.displayName = protocol.displayName;
            this.levelAttrib = new WeihuaGames.ClientClass.LevelAttrib().FromProtobuf(protocol.levelAttrib);
            this.battlePosition = protocol.battlePosition;
            this.evaluation = protocol.evaluation;
            this.scale = protocol.scale;
            this.npcType = protocol.npcType;
            this.npcId = protocol.npcId;
            this.illusionID = protocol.illusionId;
            this.equipments.Clear();
            foreach (com.kodgames.corgi.protocol.EquipmentData data in protocol.equips)
            {
                this.equipments.Add(new WeihuaGames.ClientClass.EquipmentData().FromProtobuf(data));
            }
            this.skills.Clear();
            foreach (com.kodgames.corgi.protocol.SkillData data2 in protocol.skills)
            {
                this.skills.Add(new WeihuaGames.ClientClass.SkillData().FromProtobuf(data2));
            }
            this.buffs.Clear();
            foreach (com.kodgames.corgi.protocol.BuffData data3 in protocol.buffs)
            {
                this.buffs.Add(new WeihuaGames.ClientClass.BuffData().FromProtobuf(data3));
            }
            this.attributes.Clear();
            foreach (com.kodgames.corgi.protocol.Attribute attribute in protocol.attributes)
            {
                this.attributes.Add(new WeihuaGames.ClientClass.Attribute().FromProtobuf(attribute));
            }
            return this;
        }

        public WeihuaGames.ClientClass.Attribute GetAttributeByType(int attributeType)
        {
            foreach (WeihuaGames.ClientClass.Attribute attribute in this.attributes)
            {
                if (attribute.Type == attributeType)
                {
                    return attribute;
                }
            }
            return null;
        }

        public com.kodgames.corgi.protocol.CombatAvatarData ToProtobuf()
        {
            com.kodgames.corgi.protocol.CombatAvatarData data = new com.kodgames.corgi.protocol.CombatAvatarData {
                avatarType = this.avatarType,
                resourceId = this.resourceId,
                breakThrough = this.breakThrough,
                levelAttrib = this.levelAttrib.ToProtobuf(),
                battlePosition = this.battlePosition,
                displayName = this.displayName,
                evaluation = this.evaluation,
                scale = this.scale,
                npcType = this.npcType,
                npcId = this.npcId,
                illusionId = this.illusionID
            };
            foreach (WeihuaGames.ClientClass.EquipmentData data2 in this.equipments)
            {
                data.equips.Add(data2.ToProtobuf());
            }
            foreach (WeihuaGames.ClientClass.SkillData data3 in this.skills)
            {
                data.skills.Add(data3.ToProtobuf());
            }
            foreach (WeihuaGames.ClientClass.BuffData data4 in this.buffs)
            {
                data.buffs.Add(data4.ToProtobuf());
            }
            foreach (WeihuaGames.ClientClass.Attribute attribute in this.attributes)
            {
                data.attributes.Add(attribute.ToProtobuf());
            }
            return data;
        }

        public List<WeihuaGames.ClientClass.Attribute> Attributes
        {
            get
            {
                return this.attributes;
            }
            set
            {
                this.attributes = value;
            }
        }

        public int AvatarType
        {
            get
            {
                return this.avatarType;
            }
            set
            {
                this.avatarType = value;
            }
        }

        public int BattlePosition
        {
            get
            {
                return this.battlePosition;
            }
            set
            {
                this.battlePosition = value;
            }
        }

        public int BreakThrough
        {
            get
            {
                return this.breakThrough;
            }
            set
            {
                this.breakThrough = value;
            }
        }

        public List<WeihuaGames.ClientClass.BuffData> Buffs
        {
            get
            {
                return this.buffs;
            }
            set
            {
                this.buffs = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                this.displayName = value;
            }
        }

        public List<WeihuaGames.ClientClass.EquipmentData> Equipments
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

        public int Evaluation
        {
            get
            {
                return this.evaluation;
            }
            set
            {
                this.evaluation = value;
            }
        }

        public int IllusionID
        {
            get
            {
                return this.illusionID;
            }
            set
            {
                this.illusionID = value;
            }
        }

        public WeihuaGames.ClientClass.LevelAttrib LevelAttrib
        {
            get
            {
                return this.levelAttrib;
            }
            set
            {
                this.levelAttrib = value;
            }
        }

        public int NpcId
        {
            get
            {
                return this.npcId;
            }
            set
            {
                this.npcId = value;
            }
        }

        public int NpcType
        {
            get
            {
                return this.npcType;
            }
            set
            {
                this.npcType = value;
            }
        }

        public int ResourceId
        {
            get
            {
                return this.resourceId;
            }
            set
            {
                this.resourceId = value;
            }
        }

        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
            }
        }

        public List<WeihuaGames.ClientClass.SkillData> Skills
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

