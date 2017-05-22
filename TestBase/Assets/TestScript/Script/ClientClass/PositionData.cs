namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class PositionData
    {
        private int activePositionId;
        private List<WeihuaGames.ClientClass.Position> positions = new List<WeihuaGames.ClientClass.Position>();

        public void FromProtobuf(com.kodgames.corgi.protocol.PositionData positionData)
        {
            this.activePositionId = positionData.masterPositionId;
            if (positionData.positions != null)
            {
                foreach (com.kodgames.corgi.protocol.Position position in positionData.positions)
                {
                    WeihuaGames.ClientClass.Position item = new WeihuaGames.ClientClass.Position();
                    item.FromProtobuf(position);
                    this.positions.Add(item);
                }
            }
        }

        public WeihuaGames.ClientClass.Position GetPositionById(int id)
        {
            if (this.positions != null)
            {
                for (int i = 0; i < this.positions.Count; i++)
                {
                    if (this.positions[i].PositionId == id)
                    {
                        return this.positions[i];
                    }
                }
            }
            return null;
        }

        public void PutPosition(WeihuaGames.ClientClass.Position position)
        {
            if (this.GetPositionById(position.PositionId) == null)
            {
                this.positions.Add(position);
            }
            else
            {
                this.GetPositionById(position.PositionId).PostionShallCopy(position);
            }
        }

        public int ActivePositionId
        {
            get
            {
                return this.activePositionId;
            }
            set
            {
                this.activePositionId = value;
            }
        }

        public List<WeihuaGames.ClientClass.Position> Positions
        {
            get
            {
                return this.positions;
            }
            set
            {
                this.positions = value;
            }
        }
    }
}

