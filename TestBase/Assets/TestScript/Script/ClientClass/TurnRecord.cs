namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class TurnRecord
    {
        private List<WeihuaGames.ClientClass.ActionRecord> actionRecords = new List<WeihuaGames.ClientClass.ActionRecord>();
        private int avatarIndex = -1;
        private int currentActionIndex = -1;

        public static WeihuaGames.ClientClass.TurnRecord CopyTo(WeihuaGames.ClientClass.TurnRecord theOne)
        {
            WeihuaGames.ClientClass.TurnRecord record = new WeihuaGames.ClientClass.TurnRecord {
                avatarIndex = theOne.avatarIndex,
                currentActionIndex = theOne.currentActionIndex
            };
            foreach (WeihuaGames.ClientClass.ActionRecord record2 in theOne.actionRecords)
            {
                record.actionRecords.Add(WeihuaGames.ClientClass.ActionRecord.CopyTo(record2));
            }
            return record;
        }

        public WeihuaGames.ClientClass.TurnRecord FromProtobuf(com.kodgames.corgi.protocol.TurnRecord turnRecord)
        {
            this.avatarIndex = turnRecord.avatarIndex;
            foreach (com.kodgames.corgi.protocol.ActionRecord record in turnRecord.actionRecords)
            {
                this.actionRecords.Add(new WeihuaGames.ClientClass.ActionRecord().FromProtobuf(record));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.TurnRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.TurnRecord record = new com.kodgames.corgi.protocol.TurnRecord {
                avatarIndex = this.avatarIndex
            };
            foreach (WeihuaGames.ClientClass.ActionRecord record2 in this.actionRecords)
            {
                record.actionRecords.Add(record2.ToProtobuf());
            }
            return record;
        }

        public List<WeihuaGames.ClientClass.ActionRecord> ActionRecords
        {
            get
            {
                return this.actionRecords;
            }
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

        public int CurrentActionIndex
        {
            get
            {
                return this.currentActionIndex;
            }
            set
            {
                this.currentActionIndex = value;
            }
        }
    }
}

