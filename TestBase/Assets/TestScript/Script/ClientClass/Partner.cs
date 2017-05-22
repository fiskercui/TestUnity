namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Partner
    {
        private string avatarGuid;
        private int partnerId;
        private int positionId;
        private int resourceId;

        public WeihuaGames.ClientClass.Partner FromProtobuf(com.kodgames.corgi.protocol.Partner partner)
        {
            this.positionId = partner.positionId;
            this.partnerId = partner.partnerId;
            this.resourceId = partner.resourceId;
            this.avatarGuid = partner.avatarGuid;
            return this;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.Partner partner)
        {
            this.positionId = partner.positionId;
            this.partnerId = partner.partnerId;
            this.resourceId = partner.resourceId;
            this.avatarGuid = partner.avatarGuid;
        }

        public com.kodgames.corgi.protocol.Partner ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.Partner { 
                positionId = this.positionId,
                partnerId = this.partnerId,
                resourceId = this.resourceId,
                avatarGuid = this.avatarGuid
            };
        }

        public string AvatarGuid
        {
            get
            {
                return this.avatarGuid;
            }
            set
            {
                this.avatarGuid = value;
            }
        }

        public int PartnerId
        {
            get
            {
                return this.partnerId;
            }
            set
            {
                this.partnerId = value;
            }
        }

        public int PositionId
        {
            get
            {
                return this.positionId;
            }
            set
            {
                this.positionId = value;
            }
        }

        public int ResourceId
        {
            get
            {
                return this.resourceId;
            }
            set
            {
                this.resourceId = value;
            }
        }
    }
}

