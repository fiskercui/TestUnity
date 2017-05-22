namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class CombatRecord
    {
        private List<WeihuaGames.ClientClass.RoundRecord> roundRecords = new List<WeihuaGames.ClientClass.RoundRecord>();

        public static WeihuaGames.ClientClass.CombatRecord CopyTo(WeihuaGames.ClientClass.CombatRecord theOne)
        {
            WeihuaGames.ClientClass.CombatRecord record = new WeihuaGames.ClientClass.CombatRecord();
            foreach (WeihuaGames.ClientClass.RoundRecord record2 in theOne.roundRecords)
            {
                record.roundRecords.Add(WeihuaGames.ClientClass.RoundRecord.CopyTo(record2));
            }
            return record;
        }

        public WeihuaGames.ClientClass.CombatRecord FromProtobuf(com.kodgames.corgi.protocol.CombatRecord combatRecord)
        {
            foreach (com.kodgames.corgi.protocol.RoundRecord record in combatRecord.roundRecords)
            {
                this.roundRecords.Add(new WeihuaGames.ClientClass.RoundRecord().FromProtobuf(record));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.CombatRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.CombatRecord record = new com.kodgames.corgi.protocol.CombatRecord();
            foreach (WeihuaGames.ClientClass.RoundRecord record2 in this.roundRecords)
            {
                record.roundRecords.Add(record2.ToProtobuf());
            }
            return record;
        }

        public List<WeihuaGames.ClientClass.RoundRecord> RoundRecords
        {
            get
            {
                return this.roundRecords;
            }
        }
    }
}

