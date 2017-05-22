namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CombatResultAndReward
    {
        private List<WeihuaGames.ClientClass.BattleRecord> battleRecords = new List<WeihuaGames.ClientClass.BattleRecord>();
        private int combatNumMax;
        private int combatNumReal;
        private WeihuaGames.ClientClass.Reward dungeonReward = new WeihuaGames.ClientClass.Reward();
        private WeihuaGames.ClientClass.Reward dungeonReward_ExpSilver = new WeihuaGames.ClientClass.Reward();
        private WeihuaGames.ClientClass.Reward firstpassReward = new WeihuaGames.ClientClass.Reward();
        private bool isPlotBattle;
        private List<WeihuaGames.ClientClass.Reward> rewards = new List<WeihuaGames.ClientClass.Reward>();
        private List<int> starCompleteIndexs = new List<int>();

        public List<com.kodgames.corgi.protocol.RoundRecord> DesRoundRecordListProtobufData(byte[] roundRecordListProtocolBytes)
        {
            return Serializer.Deserialize<List<com.kodgames.corgi.protocol.RoundRecord>>(new MemoryStream(roundRecordListProtocolBytes));
        }

        public WeihuaGames.ClientClass.CombatResultAndReward FromProtobuf(com.kodgames.corgi.protocol.CombatResultAndReward combatResultAndReward)
        {
            if (combatResultAndReward != null)
            {
                this.combatNumMax = combatResultAndReward.combatNumMax;
                this.combatNumReal = combatResultAndReward.combatNumReal;
                this.isPlotBattle = combatResultAndReward.isPlotBattle;
                if (combatResultAndReward.rewards != null)
                {
                    foreach (com.kodgames.corgi.protocol.Reward reward in combatResultAndReward.rewards)
                    {
                        WeihuaGames.ClientClass.Reward item = new WeihuaGames.ClientClass.Reward();
                        item.FromProtobuf(reward);
                        this.rewards.Add(item);
                    }
                }
                if (combatResultAndReward.battleRecords != null)
                {
                    foreach (com.kodgames.corgi.protocol.BattleRecord record in combatResultAndReward.battleRecords)
                    {
                        WeihuaGames.ClientClass.BattleRecord record2 = new WeihuaGames.ClientClass.BattleRecord();
                        record2.FromProtobuf(record);
                        this.battleRecords.Add(record2);
                    }
                }
                if (combatResultAndReward.dungeonReward != null)
                {
                    this.dungeonReward.FromProtobuf(combatResultAndReward.dungeonReward);
                }
                if (combatResultAndReward.starCompleteIndexs != null)
                {
                    foreach (int num in combatResultAndReward.starCompleteIndexs)
                    {
                        this.starCompleteIndexs.Add(num);
                    }
                }
                if (combatResultAndReward.dungeonReward_ExpSilver != null)
                {
                    this.dungeonReward_ExpSilver.FromProtobuf(combatResultAndReward.dungeonReward_ExpSilver);
                }
                if (combatResultAndReward.firstpassReward != null)
                {
                    this.firstpassReward.FromProtobuf(combatResultAndReward.firstpassReward);
                }
            }
            return this;
        }

        public WeihuaGames.ClientClass.CombatResultAndReward FromProtobufData(byte[] bytes)
        {
            return this.FromProtobuf(Serializer.Deserialize<com.kodgames.corgi.protocol.CombatResultAndReward>(new MemoryStream(bytes)));
        }

        public com.kodgames.corgi.protocol.CombatResultAndReward ToProtobufWithOnlyBattleData()
        {
            com.kodgames.corgi.protocol.CombatResultAndReward reward = new com.kodgames.corgi.protocol.CombatResultAndReward {
                combatNumMax = this.CombatNumMax,
                combatNumReal = this.combatNumReal,
                isPlotBattle = this.isPlotBattle
            };
            if (this.BattleRecords != null)
            {
                foreach (WeihuaGames.ClientClass.BattleRecord record in this.BattleRecords)
                {
                    reward.battleRecords.Add(record.ToProtobuf());
                }
            }
            return reward;
        }

        public List<WeihuaGames.ClientClass.BattleRecord> BattleRecords
        {
            get
            {
                return this.battleRecords;
            }
            set
            {
                this.battleRecords = value;
            }
        }

        public int CombatNumMax
        {
            get
            {
                return this.combatNumMax;
            }
            set
            {
                this.combatNumMax = value;
            }
        }

        public int CombatNumReal
        {
            get
            {
                return this.combatNumReal;
            }
            set
            {
                this.combatNumReal = value;
            }
        }

        public WeihuaGames.ClientClass.Reward DungeonReward
        {
            get
            {
                return this.dungeonReward;
            }
            set
            {
                this.dungeonReward = value;
            }
        }

        public WeihuaGames.ClientClass.Reward DungeonReward_ExpSilver
        {
            get
            {
                return this.dungeonReward_ExpSilver;
            }
            set
            {
                this.dungeonReward_ExpSilver = value;
            }
        }

        public WeihuaGames.ClientClass.Reward FirstpassReward
        {
            get
            {
                return this.firstpassReward;
            }
            set
            {
                this.firstpassReward = value;
            }
        }

        public bool IsPlotBattle
        {
            get
            {
                return this.isPlotBattle;
            }
            set
            {
                this.isPlotBattle = value;
            }
        }

        public List<WeihuaGames.ClientClass.Reward> Rewards
        {
            get
            {
                return this.rewards;
            }
            set
            {
                this.rewards = value;
            }
        }

        public List<int> StarCompleteIndexs
        {
            get
            {
                return this.starCompleteIndexs;
            }
            set
            {
                this.starCompleteIndexs = value;
            }
        }
    }
}

