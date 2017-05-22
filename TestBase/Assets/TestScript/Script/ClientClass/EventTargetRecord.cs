namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class EventTargetRecord
    {
        private int eventType;
        private List<WeihuaGames.ClientClass.ActionRecord> passiveActionRecords = new List<WeihuaGames.ClientClass.ActionRecord>();
        private int targetIndex;
        private int testType;
        private int value;
        private int value1;

        public static WeihuaGames.ClientClass.EventTargetRecord CopyTo(WeihuaGames.ClientClass.EventTargetRecord theOne)
        {
            WeihuaGames.ClientClass.EventTargetRecord record = new WeihuaGames.ClientClass.EventTargetRecord {
                targetIndex = theOne.targetIndex,
                eventType = theOne.eventType,
                testType = theOne.testType,
                value = theOne.value,
                value1 = theOne.value1
            };
            foreach (WeihuaGames.ClientClass.ActionRecord record2 in theOne.passiveActionRecords)
            {
                record.passiveActionRecords.Add(WeihuaGames.ClientClass.ActionRecord.CopyTo(record2));
            }
            return record;
        }

        public WeihuaGames.ClientClass.EventTargetRecord FromProtobuf(com.kodgames.corgi.protocol.EventTargetRecord eventTargetRecord)
        {
            this.targetIndex = eventTargetRecord.targetIndex;
            this.eventType = eventTargetRecord.eventType;
            this.testType = eventTargetRecord.testType;
            this.value = eventTargetRecord.value;
            this.value1 = eventTargetRecord.value1;
            foreach (com.kodgames.corgi.protocol.ActionRecord record in eventTargetRecord.passiveActionRecords)
            {
                this.passiveActionRecords.Add(new WeihuaGames.ClientClass.ActionRecord().FromProtobuf(record));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.EventTargetRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.EventTargetRecord record = new com.kodgames.corgi.protocol.EventTargetRecord {
                targetIndex = this.targetIndex,
                eventType = this.eventType,
                testType = this.testType,
                value = this.value,
                value1 = this.value1
            };
            foreach (WeihuaGames.ClientClass.ActionRecord record2 in this.passiveActionRecords)
            {
                record.passiveActionRecords.Add(record2.ToProtobuf());
            }
            return record;
        }

        public int EventType
        {
            get
            {
                return this.eventType;
            }
            set
            {
                this.eventType = value;
            }
        }

        public List<WeihuaGames.ClientClass.ActionRecord> PassiveActionRecords
        {
            get
            {
                return this.passiveActionRecords;
            }
            set
            {
                this.passiveActionRecords = value;
            }
        }

        public int TargetIndex
        {
            get
            {
                return this.targetIndex;
            }
            set
            {
                this.targetIndex = value;
            }
        }

        public int TestType
        {
            get
            {
                return this.testType;
            }
            set
            {
                this.testType = value;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int Value1
        {
            get
            {
                return this.value1;
            }
            set
            {
                this.value1 = value;
            }
        }
    }
}

