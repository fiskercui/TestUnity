namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Function
    {
        private bool faceBookOpen;
        private bool showExchange;
        private bool showGiveMeFive;
        private bool showInviteCode;
        private bool showSevenElevenGift;
        private bool showStartGameVideo;

        public void FromProtobuf(com.kodgames.corgi.protocol.Function function)
        {
            this.showExchange = function.showExchange;
            this.showGiveMeFive = function.showGiveMeFive;
            this.showStartGameVideo = function.showStartGameVideo;
            this.showInviteCode = function.showInviteCode;
            this.showSevenElevenGift = function.showSevenElevenGift;
            this.faceBookOpen = function.faceBookOpen;
        }

        public bool FaceBookOpen
        {
            get
            {
                return this.faceBookOpen;
            }
            set
            {
                this.faceBookOpen = value;
            }
        }

        public bool ShowExchange
        {
            get
            {
                return this.showExchange;
            }
            set
            {
                this.showExchange = value;
            }
        }

        public bool ShowGiveMeFive
        {
            get
            {
                return this.showGiveMeFive;
            }
            set
            {
                this.showGiveMeFive = value;
            }
        }

        public bool ShowInviteCode
        {
            get
            {
                return this.showInviteCode;
            }
            set
            {
                this.showInviteCode = value;
            }
        }

        public bool ShowSevenElevenGift
        {
            get
            {
                return this.showSevenElevenGift;
            }
            set
            {
                this.showSevenElevenGift = value;
            }
        }

        public bool ShowStartGameVideo
        {
            get
            {
                return this.showStartGameVideo;
            }
            set
            {
                this.showStartGameVideo = value;
            }
        }
    }
}

