namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class QinInfo
    {
        private int continueAnswerCount;
        private int questionId;

        public WeihuaGames.ClientClass.QinInfo FromProtobuf(com.kodgames.corgi.protocol.QinInfo qinInfo)
        {
            if (qinInfo != null)
            {
                this.continueAnswerCount = qinInfo.continueAnswerCount;
                this.questionId = qinInfo.questionId;
            }
            return this;
        }

        public int ContinueAnswerCount
        {
            get
            {
                return this.continueAnswerCount;
            }
            set
            {
                this.continueAnswerCount = value;
            }
        }

        public int QuestionId
        {
            get
            {
                return this.questionId;
            }
            set
            {
                this.questionId = value;
            }
        }
    }
}

