namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BattleRecord
    {
        private WeihuaGames.ClientClass.CombatRecord combatRecord = new WeihuaGames.ClientClass.CombatRecord();
        private WeihuaGames.ClientClass.RoundRecord matchinRoundRecord = new WeihuaGames.ClientClass.RoundRecord();
        private int maxRecordCount;
        private int sceneId;
        private List<WeihuaGames.ClientClass.TeamRecord> teamRecords = new List<WeihuaGames.ClientClass.TeamRecord>();

        public static WeihuaGames.ClientClass.BattleRecord CopyTo(WeihuaGames.ClientClass.BattleRecord theOne)
        {
            WeihuaGames.ClientClass.BattleRecord record = new WeihuaGames.ClientClass.BattleRecord {
                sceneId = theOne.sceneId,
                maxRecordCount = theOne.maxRecordCount
            };
            foreach (WeihuaGames.ClientClass.TeamRecord record2 in theOne.teamRecords)
            {
                record.teamRecords.Add(WeihuaGames.ClientClass.TeamRecord.CopyTo(record2));
            }
            if (theOne.matchinRoundRecord != null)
            {
                record.matchinRoundRecord = WeihuaGames.ClientClass.RoundRecord.CopyTo(theOne.matchinRoundRecord);
            }
            record.combatRecord = WeihuaGames.ClientClass.CombatRecord.CopyTo(theOne.combatRecord);
            return record;
        }

        public WeihuaGames.ClientClass.BattleRecord FromProtobuf(com.kodgames.corgi.protocol.BattleRecord combatResult)
        {
            this.sceneId = combatResult.sceneId;
            this.maxRecordCount = combatResult.maxRecordCount;
            this.matchinRoundRecord = (combatResult.matchinRoundRecord != null) ? new WeihuaGames.ClientClass.RoundRecord().FromProtobuf(combatResult.matchinRoundRecord) : null;
            this.combatRecord = (combatResult.combatRecord != null) ? new WeihuaGames.ClientClass.CombatRecord().FromProtobuf(combatResult.combatRecord) : null;
            foreach (com.kodgames.corgi.protocol.TeamRecord record in combatResult.teamRecord)
            {
                this.teamRecords.Add(new WeihuaGames.ClientClass.TeamRecord().FromProtobuf(record));
            }
            return this;
        }

        public WeihuaGames.ClientClass.BattleRecord FromProtoBuffData(byte[] data)
        {
            MemoryStream source = new MemoryStream(data);
            return this.FromProtobuf(Serializer.Deserialize<com.kodgames.corgi.protocol.BattleRecord>(source));
        }

        public WeihuaGames.ClientClass.AvatarResult GetAvatarResult(int avatarIndex)
        {
            foreach (WeihuaGames.ClientClass.TeamRecord record in this.teamRecords)
            {
                foreach (WeihuaGames.ClientClass.AvatarResult result in record.AvatarResults)
                {
                    if (result.AvatarIndex == avatarIndex)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.TeamRecord GetTeamRecord(int index)
        {
            if (index >= this.GetTeamRecordCount())
            {
                return null;
            }
            return this.teamRecords[index];
        }

        public int GetTeamRecordCount()
        {
            return this.teamRecords.Count;
        }

        public com.kodgames.corgi.protocol.BattleRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.BattleRecord record = new com.kodgames.corgi.protocol.BattleRecord {
                sceneId = this.sceneId,
                maxRecordCount = this.maxRecordCount
            };
            foreach (WeihuaGames.ClientClass.TeamRecord record2 in this.teamRecords)
            {
                record.teamRecord.Add(record2.ToProtobuf());
            }
            record.combatRecord = (this.combatRecord != null) ? this.combatRecord.ToProtobuf() : null;
            return record;
        }

        public WeihuaGames.ClientClass.CombatRecord CombatRecord
        {
            get
            {
                return this.combatRecord;
            }
            set
            {
                this.combatRecord = value;
            }
        }

        public WeihuaGames.ClientClass.RoundRecord MatchinRoundRecord
        {
            get
            {
                return this.matchinRoundRecord;
            }
            set
            {
                this.matchinRoundRecord = value;
            }
        }

        public int MaxRecordCount
        {
            get
            {
                return this.maxRecordCount;
            }
            set
            {
                this.maxRecordCount = value;
            }
        }

        public int SceneId
        {
            get
            {
                return this.sceneId;
            }
            set
            {
                this.sceneId = value;
            }
        }

        public List<WeihuaGames.ClientClass.TeamRecord> TeamRecords
        {
            get
            {
                return this.teamRecords;
            }
        }
    }
}

