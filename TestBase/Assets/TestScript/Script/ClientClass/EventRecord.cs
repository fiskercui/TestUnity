namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class EventRecord
    {
        private int eventIndex;
        private List<WeihuaGames.ClientClass.EventTargetRecord> eventTargetRecords = new List<WeihuaGames.ClientClass.EventTargetRecord>();

        public static WeihuaGames.ClientClass.EventRecord CopyTo(WeihuaGames.ClientClass.EventRecord theOne)
        {
            WeihuaGames.ClientClass.EventRecord record = new WeihuaGames.ClientClass.EventRecord {
                eventIndex = theOne.eventIndex
            };
            foreach (WeihuaGames.ClientClass.EventTargetRecord record2 in theOne.EventTargetRecords)
            {
                record.EventTargetRecords.Add(WeihuaGames.ClientClass.EventTargetRecord.CopyTo(record2));
            }
            return record;
        }

        public WeihuaGames.ClientClass.EventRecord FromProtobuf(com.kodgames.corgi.protocol.EventRecord eventRecord)
        {
            this.eventIndex = eventRecord.eventIdx;
            foreach (com.kodgames.corgi.protocol.EventTargetRecord record in eventRecord.eventTargetRecords)
            {
                this.eventTargetRecords.Add(new WeihuaGames.ClientClass.EventTargetRecord().FromProtobuf(record));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.EventRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.EventRecord record = new com.kodgames.corgi.protocol.EventRecord {
                eventIdx = this.eventIndex
            };
            foreach (WeihuaGames.ClientClass.EventTargetRecord record2 in this.eventTargetRecords)
            {
                record.eventTargetRecords.Add(record2.ToProtobuf());
            }
            return record;
        }

        public int EventIndex
        {
            get
            {
                return this.eventIndex;
            }
            set
            {
                this.eventIndex = value;
            }
        }

        public List<WeihuaGames.ClientClass.EventTargetRecord> EventTargetRecords
        {
            get
            {
                return this.eventTargetRecords;
            }
        }
    }
}

