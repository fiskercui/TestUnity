namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class TeamRecord
    {
        private List<WeihuaGames.ClientClass.AvatarResult> avatarResults = new List<WeihuaGames.ClientClass.AvatarResult>();
        private string displayName = "";
        private int evaluation;
        private bool isWinner;
        private int teamIndex = -1;

        public static WeihuaGames.ClientClass.TeamRecord CopyTo(WeihuaGames.ClientClass.TeamRecord theOne)
        {
            WeihuaGames.ClientClass.TeamRecord record = new WeihuaGames.ClientClass.TeamRecord {
                teamIndex = theOne.teamIndex,
                evaluation = theOne.evaluation,
                displayName = theOne.displayName,
                isWinner = theOne.isWinner
            };
            foreach (WeihuaGames.ClientClass.AvatarResult result in theOne.avatarResults)
            {
                record.avatarResults.Add(WeihuaGames.ClientClass.AvatarResult.CopyTo(result));
            }
            return record;
        }

        public WeihuaGames.ClientClass.TeamRecord FromProtobuf(com.kodgames.corgi.protocol.TeamRecord protocol)
        {
            this.teamIndex = protocol.teamIndex;
            this.isWinner = protocol.isWinner;
            this.displayName = protocol.displayName;
            this.evaluation = protocol.evaluation;
            foreach (com.kodgames.corgi.protocol.AvatarResult result in protocol.avatarResults)
            {
                this.avatarResults.Add(new WeihuaGames.ClientClass.AvatarResult().FromProtobuf(result));
            }
            return this;
        }

        public com.kodgames.corgi.protocol.TeamRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.TeamRecord record = new com.kodgames.corgi.protocol.TeamRecord {
                teamIndex = this.teamIndex,
                isWinner = this.isWinner,
                displayName = this.displayName,
                evaluation = this.evaluation
            };
            foreach (WeihuaGames.ClientClass.AvatarResult result in this.avatarResults)
            {
                record.avatarResults.Add(result.ToProtobuf());
            }
            return record;
        }

        public List<WeihuaGames.ClientClass.AvatarResult> AvatarResults
        {
            get
            {
                return this.avatarResults;
            }
            set
            {
                this.avatarResults = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                this.displayName = value;
            }
        }

        public int Evaluation
        {
            get
            {
                return this.evaluation;
            }
            set
            {
                this.evaluation = value;
            }
        }

        public bool IsWinner
        {
            get
            {
                return this.isWinner;
            }
            set
            {
                this.isWinner = value;
            }
        }

        public int TeamIndex
        {
            get
            {
                return this.teamIndex;
            }
            set
            {
                this.teamIndex = value;
            }
        }
    }
}

