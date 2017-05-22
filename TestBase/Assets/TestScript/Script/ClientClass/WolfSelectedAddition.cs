namespace KodGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class WolfSelectedAddition
    {
        private int additionId;
        private int stageId;

        public KodGames.ClientClass.WolfSelectedAddition FromProtobuf(com.kodgames.corgi.protocol.WolfSelectedAddition wolfSelectedAddition)
        {
            if (wolfSelectedAddition != null)
            {
                this.stageId = wolfSelectedAddition.stageId;
                this.additionId = wolfSelectedAddition.additionId;
            }
            return this;
        }

        public int AdditionId
        {
            get
            {
                return this.additionId;
            }
            set
            {
                this.additionId = value;
            }
        }

        public int StageId
        {
            get
            {
                return this.stageId;
            }
            set
            {
                this.stageId = value;
            }
        }
    }
}

