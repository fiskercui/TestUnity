namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class SevenElevenGift
    {
        private int convertType;
        private WeihuaGames.ClientClass.CostAndRewardAndSync costAndRewardAndSync;
        private string exchangeCode;
        private WeihuaGames.ClientClass.Reward reward;

        public WeihuaGames.ClientClass.SevenElevenGift FromProtobuf(com.kodgames.corgi.protocol.SevenElevenGift sevenElevenGift)
        {
            if (sevenElevenGift != null)
            {
                WeihuaGames.ClientClass.Reward reward = new WeihuaGames.ClientClass.Reward();
                reward.FromProtobuf(sevenElevenGift.reward);
                this.reward = reward;
                this.exchangeCode = sevenElevenGift.exchangeCode;
                this.convertType = sevenElevenGift.convertType;
                WeihuaGames.ClientClass.CostAndRewardAndSync sync = new WeihuaGames.ClientClass.CostAndRewardAndSync();
                sync.FromProtoBuf(sevenElevenGift.costAndRewardAndSync);
                this.costAndRewardAndSync = sync;
            }
            return this;
        }

        public int ConvertType
        {
            get
            {
                return this.convertType;
            }
            set
            {
                this.convertType = value;
            }
        }

        public WeihuaGames.ClientClass.CostAndRewardAndSync CostAndRewardAndSync
        {
            get
            {
                return this.costAndRewardAndSync;
            }
            set
            {
                this.costAndRewardAndSync = value;
            }
        }

        public string ExchangeCode
        {
            get
            {
                return this.exchangeCode;
            }
            set
            {
                this.exchangeCode = value;
            }
        }

        public WeihuaGames.ClientClass.Reward Reward
        {
            get
            {
                return this.reward;
            }
            set
            {
                this.reward = value;
            }
        }
    }
}

