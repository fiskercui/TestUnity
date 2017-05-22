namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class TargetCondition
    {
        private bool boolValue;
        private double doubleValue;
        private int intValue;
        private string stringValue;
        private int type;

        public WeihuaGames.ClientClass.TargetCondition FromProtobuf(com.kodgames.corgi.protocol.TargetCondition targetCondition)
        {
            if (targetCondition != null)
            {
                this.type = targetCondition.type;
                this.intValue = targetCondition.intValue;
                this.stringValue = targetCondition.stringValue;
                this.boolValue = targetCondition.boolValue;
                this.doubleValue = targetCondition.doubleValue;
            }
            return this;
        }

        public bool BoolValue
        {
            get
            {
                return this.boolValue;
            }
            set
            {
                this.boolValue = value;
            }
        }

        public double DoubleValue
        {
            get
            {
                return this.doubleValue;
            }
            set
            {
                this.doubleValue = value;
            }
        }

        public int IntValue
        {
            get
            {
                return this.intValue;
            }
            set
            {
                this.intValue = value;
            }
        }

        public string StringValue
        {
            get
            {
                return this.stringValue;
            }
            set
            {
                this.stringValue = value;
            }
        }

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

