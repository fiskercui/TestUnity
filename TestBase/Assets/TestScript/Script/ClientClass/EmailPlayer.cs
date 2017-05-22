namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class EmailPlayer
    {
        private WeihuaGames.ClientClass.Reward attachmentRewards;
        private string emailBody;
        private long emailId;
        private long emailParentGroupId;
        private string emailTitle;
        private int emailType;
        private int playerId;
        private string senderName;
        private int senderPlayerId;
        private long sendTime;
        private int statusDidPick;

        public WeihuaGames.ClientClass.EmailPlayer FromProtoBuf(com.kodgames.corgi.protocol.EmailPlayer emailProtoBuf)
        {
            this.emailId = emailProtoBuf.emailId;
            this.emailType = emailProtoBuf.emailType;
            this.emailTitle = emailProtoBuf.emailTitle;
            this.emailBody = emailProtoBuf.emailBody;
            this.sendTime = emailProtoBuf.sendTime;
            this.senderPlayerId = emailProtoBuf.senderId;
            this.playerId = emailProtoBuf.receiverId;
            this.senderName = emailProtoBuf.senderName;
            this.emailParentGroupId = emailProtoBuf.emailGroupId;
            this.statusDidPick = emailProtoBuf.statusDidPick;
            if (emailProtoBuf.attachmentRewards != null)
            {
                this.attachmentRewards = new WeihuaGames.ClientClass.Reward();
                this.attachmentRewards.FromProtobuf(emailProtoBuf.attachmentRewards);
            }
            return this;
        }

        public int GetAttachmentRewardsCount()
        {
            if (this.attachmentRewards == null)
            {
                return 0;
            }
            return (((this.attachmentRewards.Avatar.Count + this.attachmentRewards.Equip.Count) + this.attachmentRewards.Skill.Count) + this.attachmentRewards.Consumable.Count);
        }

        public com.kodgames.corgi.protocol.EmailPlayer ToProtoBuf()
        {
            return null;
        }

        public WeihuaGames.ClientClass.Reward AttachmentRewards
        {
            get
            {
                return this.attachmentRewards;
            }
            set
            {
                this.attachmentRewards = value;
            }
        }

        public string EmailBody
        {
            get
            {
                return this.emailBody;
            }
            set
            {
                this.emailBody = value;
            }
        }

        public long EmailId
        {
            get
            {
                return this.emailId;
            }
            set
            {
                this.emailId = value;
            }
        }

        public long EmailParentGroupId
        {
            get
            {
                return this.emailParentGroupId;
            }
            set
            {
                this.emailParentGroupId = value;
            }
        }

        public string EmailTitle
        {
            get
            {
                return this.emailTitle;
            }
            set
            {
                this.emailTitle = value;
            }
        }

        public int EmailType
        {
            get
            {
                return this.emailType;
            }
            set
            {
                this.emailType = value;
            }
        }

        public int PlayerId
        {
            get
            {
                return this.playerId;
            }
            set
            {
                this.playerId = value;
            }
        }

        public string SenderName
        {
            get
            {
                return this.senderName;
            }
            set
            {
                this.senderName = value;
            }
        }

        public int SenderPlayerId
        {
            get
            {
                return this.senderPlayerId;
            }
            set
            {
                this.senderPlayerId = value;
            }
        }

        public long SendTime
        {
            get
            {
                return this.sendTime;
            }
            set
            {
                this.sendTime = value;
            }
        }

        public int StatusDidPick
        {
            get
            {
                return this.statusDidPick;
            }
            set
            {
                this.statusDidPick = value;
            }
        }
    }
}

