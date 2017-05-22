namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class ActionRecord
    {
        private int actionId;
        private List<WeihuaGames.ClientClass.EventRecord> eventRecords = new List<WeihuaGames.ClientClass.EventRecord>();
        private int srcAvatarIndex = -1;
        private List<int> targetAvatarIndices = new List<int>();

        public static WeihuaGames.ClientClass.ActionRecord CopyTo(WeihuaGames.ClientClass.ActionRecord theOne)
        {
            WeihuaGames.ClientClass.ActionRecord record = new WeihuaGames.ClientClass.ActionRecord {
                actionId = theOne.actionId,
                srcAvatarIndex = theOne.srcAvatarIndex
            };
            record.targetAvatarIndices.AddRange(theOne.targetAvatarIndices);
            foreach (WeihuaGames.ClientClass.EventRecord record2 in theOne.eventRecords)
            {
                record.eventRecords.Add(WeihuaGames.ClientClass.EventRecord.CopyTo(record2));
            }
            return record;
        }

        public WeihuaGames.ClientClass.ActionRecord FromProtobuf(com.kodgames.corgi.protocol.ActionRecord actionRecord)
        {
            this.actionId = (int) actionRecord.actionId;
            this.srcAvatarIndex = actionRecord.srcAvatarIndex;
            this.targetAvatarIndices.AddRange(actionRecord.targetAvatarIndeices);
            foreach (com.kodgames.corgi.protocol.EventRecord record in actionRecord.eventRecords)
            {
                this.eventRecords.Add(new WeihuaGames.ClientClass.EventRecord().FromProtobuf(record));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.ActionRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.ActionRecord record = new com.kodgames.corgi.protocol.ActionRecord {
                actionId = (uint) this.actionId,
                srcAvatarIndex = this.srcAvatarIndex
            };
            record.targetAvatarIndeices.AddRange(this.targetAvatarIndices);
            foreach (WeihuaGames.ClientClass.EventRecord record2 in this.eventRecords)
            {
                record.eventRecords.Add(record2.ToProtobuf());
            }
            return record;
        }

        public int ActionId
        {
            get
            {
                return this.actionId;
            }
            set
            {
                this.actionId = value;
            }
        }

        public List<WeihuaGames.ClientClass.EventRecord> EventRecords
        {
            get
            {
                return this.eventRecords;
            }
        }

        public int SrcAvatarIndex
        {
            get
            {
                return this.srcAvatarIndex;
            }
            set
            {
                this.srcAvatarIndex = value;
            }
        }

        public List<int> TargetAvatarIndices
        {
            get
            {
                return this.targetAvatarIndices;
            }
            set
            {
                this.targetAvatarIndices = value;
            }
        }
    }
}

