namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Pair
    {
        private int locationId;
        private int showLocationId;

        public void FromProtobuf(com.kodgames.corgi.protocol.Pair pair)
        {
            this.locationId = pair.locationId;
            this.showLocationId = pair.showLocationId;
        }

        public com.kodgames.corgi.protocol.Pair ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.Pair
            {
                locationId = this.locationId,
                showLocationId = this.showLocationId
            };
        }

        public int LocationId
        {
            get
            {
                return this.locationId;
            }
            set
            {
                this.locationId = value;
            }
        }

        public int ShowLocationId
        {
            get
            {
                return this.showLocationId;
            }
            set
            {
                this.showLocationId = value;
            }
        }
    }
    //public struct Pair<T1, T2>
    //{
    //    public T1 first;
    //    public T2 second;

    //    public Pair(T1 first, T2 second)
    //    {
    //        this.first = first;
    //        this.second = second;
    //    }
    //}

}

