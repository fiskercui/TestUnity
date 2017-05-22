namespace WeihuaGames.ClientClass
{

    using System.Collections.Generic;

    public class Position
    {
        private List<WeihuaGames.ClientClass.Location> avatarLocations = new List<WeihuaGames.ClientClass.Location>();
        private List<WeihuaGames.ClientClass.Location> beastLocations = new List<WeihuaGames.ClientClass.Location>();
        private List<WeihuaGames.ClientClass.Location> danLocations = new List<WeihuaGames.ClientClass.Location>();
        private int employLocationId;
        private int employShowLocationId;
        private List<WeihuaGames.ClientClass.Location> equipLocations = new List<WeihuaGames.ClientClass.Location>();
        private List<Pair> pairs = new List<Pair>();
        private List<WeihuaGames.ClientClass.Partner> partners = new List<WeihuaGames.ClientClass.Partner>();
        private int positionId;
        private List<WeihuaGames.ClientClass.Location> skillLocations = new List<WeihuaGames.ClientClass.Location>();

        public void FromProtobuf(com.kodgames.corgi.protocol.Position position)
        {
            this.positionId = position.positionId;
            this.employLocationId = position.employLocationId;
            this.employShowLocationId = position.employShowLocationId;
            if (position.avatarLocations != null)
            {
                foreach (com.kodgames.corgi.protocol.Location location in position.avatarLocations)
                {
                    WeihuaGames.ClientClass.Location item = new WeihuaGames.ClientClass.Location();
                    item.FromProtobuf(location);
                    this.avatarLocations.Add(item);
                }
            }
            if (position.equipLocations != null)
            {
                foreach (com.kodgames.corgi.protocol.Location location3 in position.equipLocations)
                {
                    WeihuaGames.ClientClass.Location location4 = new WeihuaGames.ClientClass.Location();
                    location4.FromProtobuf(location3);
                    this.equipLocations.Add(location4);
                }
            }
            if (position.danLocations != null)
            {
                foreach (com.kodgames.corgi.protocol.Location location5 in position.danLocations)
                {
                    WeihuaGames.ClientClass.Location location6 = new WeihuaGames.ClientClass.Location();
                    location6.FromProtobuf(location5);
                    this.danLocations.Add(location6);
                }
            }
            if (position.beastLocations != null)
            {
                foreach (com.kodgames.corgi.protocol.Location location7 in position.beastLocations)
                {
                    WeihuaGames.ClientClass.Location location8 = new WeihuaGames.ClientClass.Location();
                    location8.FromProtobuf(location7);
                    this.beastLocations.Add(location8);
                }
            }
            if (position.skillLocations != null)
            {
                foreach (com.kodgames.corgi.protocol.Location location9 in position.skillLocations)
                {
                    WeihuaGames.ClientClass.Location location10 = new WeihuaGames.ClientClass.Location();
                    location10.FromProtobuf(location9);
                    this.skillLocations.Add(location10);
                }
            }
            if (position.partners != null)
            {
                foreach (com.kodgames.corgi.protocol.Partner partner in position.partners)
                {
                    WeihuaGames.ClientClass.Partner partner2 = new WeihuaGames.ClientClass.Partner();
                    partner2.FromProtobuf(partner);
                    this.partners.Add(partner2);
                }
            }
            if (position.pairs != null)
            {
                foreach (com.kodgames.corgi.protocol.Pair pair in position.pairs)
                {
                    Pair pair2 = new Pair();
                    pair2.FromProtobuf(pair);
                    this.pairs.Add(pair2);
                }
            }
        }

        public WeihuaGames.ClientClass.Pair GetPairByLocationId(int locationId)
        {
            foreach (WeihuaGames.ClientClass.Pair pair in this.pairs)
            {
                if (pair.LocationId == locationId)
                {
                    return pair;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.Partner GetPartnerById(int id)
        {
            for (int i = 0; i < this.partners.Count; i++)
            {
                if (this.partners[i].PartnerId == id)
                {
                    return this.partners[i];
                }
            }
            return null;
        }

        public void PostionShallCopy(WeihuaGames.ClientClass.Position position)
        {
            this.positionId = position.positionId;
            this.employLocationId = position.employLocationId;
            this.employShowLocationId = position.employShowLocationId;
            this.avatarLocations.Clear();
            for (int i = 0; i < position.AvatarLocations.Count; i++)
            {
                this.avatarLocations.Add(position.AvatarLocations[i]);
            }
            this.equipLocations.Clear();
            for (int j = 0; j < position.EquipLocations.Count; j++)
            {
                this.equipLocations.Add(position.EquipLocations[j]);
            }
            this.danLocations.Clear();
            for (int k = 0; k < position.DanLocations.Count; k++)
            {
                this.danLocations.Add(position.DanLocations[k]);
            }
            this.beastLocations.Clear();
            for (int m = 0; m < position.BeastLocations.Count; m++)
            {
                this.beastLocations.Add(position.BeastLocations[m]);
            }
            this.skillLocations.Clear();
            for (int n = 0; n < position.SkillLocations.Count; n++)
            {
                this.skillLocations.Add(position.SkillLocations[n]);
            }
            this.partners.Clear();
            for (int num6 = 0; num6 < position.partners.Count; num6++)
            {
                this.partners.Add(position.partners[num6]);
            }
            this.pairs.Clear();
            for (int num7 = 0; num7 < position.pairs.Count; num7++)
            {
                this.pairs.Add(position.pairs[num7]);
            }
        }

        public com.kodgames.corgi.protocol.Position toProtobuf()
        {
            com.kodgames.corgi.protocol.Position position = new com.kodgames.corgi.protocol.Position {
                positionId = this.positionId,
                employLocationId = this.employLocationId,
                employShowLocationId = this.employShowLocationId
            };
            if (this.avatarLocations != null)
            {
                foreach (WeihuaGames.ClientClass.Location location in this.avatarLocations)
                {
                    com.kodgames.corgi.protocol.Location item = location.ToProtobuf();
                    position.avatarLocations.Add(item);
                }
            }
            if (this.equipLocations != null)
            {
                foreach (WeihuaGames.ClientClass.Location location3 in this.equipLocations)
                {
                    com.kodgames.corgi.protocol.Location location4 = location3.ToProtobuf();
                    position.equipLocations.Add(location4);
                }
            }
            if (this.danLocations != null)
            {
                foreach (WeihuaGames.ClientClass.Location location5 in this.danLocations)
                {
                    com.kodgames.corgi.protocol.Location location6 = location5.ToProtobuf();
                    position.danLocations.Add(location6);
                }
            }
            if (this.beastLocations != null)
            {
                foreach (WeihuaGames.ClientClass.Location location7 in this.beastLocations)
                {
                    com.kodgames.corgi.protocol.Location location8 = location7.ToProtobuf();
                    position.beastLocations.Add(location8);
                }
            }
            if (this.skillLocations != null)
            {
                foreach (WeihuaGames.ClientClass.Location location9 in this.skillLocations)
                {
                    com.kodgames.corgi.protocol.Location location10 = location9.ToProtobuf();
                    position.skillLocations.Add(location10);
                }
            }
            if (position.partners != null)
            {
                foreach (com.kodgames.corgi.protocol.Partner partner in position.partners)
                {
                    WeihuaGames.ClientClass.Partner partner2 = new WeihuaGames.ClientClass.Partner();
                    partner2.FromProtobuf(partner);
                    this.partners.Add(partner2);
                }
            }
            if (this.partners != null)
            {
                foreach (WeihuaGames.ClientClass.Partner partner3 in this.partners)
                {
                    com.kodgames.corgi.protocol.Partner partner4 = partner3.ToProtobuf();
                    position.partners.Add(partner4);
                }
            }
            if (this.pairs != null)
            {
                foreach (WeihuaGames.ClientClass.Pair pair in this.pairs)
                {
                    com.kodgames.corgi.protocol.Pair pair2 = pair.ToProtobuf();
                    position.pairs.Add(pair2);
                }
            }
            return position;
        }

        public List<WeihuaGames.ClientClass.Location> AvatarLocations
        {
            get
            {
                return this.avatarLocations;
            }
            set
            {
                this.avatarLocations = value;
            }
        }

        public List<WeihuaGames.ClientClass.Location> BeastLocations
        {
            get
            {
                return this.beastLocations;
            }
            set
            {
                this.beastLocations = value;
            }
        }

        public List<WeihuaGames.ClientClass.Location> DanLocations
        {
            get
            {
                return this.danLocations;
            }
            set
            {
                this.danLocations = value;
            }
        }

        public int EmployLocationId
        {
            get
            {
                return this.employLocationId;
            }
            set
            {
                this.employLocationId = value;
            }
        }

        public int EmployShowLocationId
        {
            get
            {
                return this.employShowLocationId;
            }
            set
            {
                this.employShowLocationId = value;
            }
        }

        public List<WeihuaGames.ClientClass.Location> EquipLocations
        {
            get
            {
                return this.equipLocations;
            }
            set
            {
                this.equipLocations = value;
            }
        }

        public List<WeihuaGames.ClientClass.Pair> Pairs
        {
            get
            {
                return this.pairs;
            }
            set
            {
                this.pairs = value;
            }
        }

        public List<WeihuaGames.ClientClass.Partner> Partners
        {
            get
            {
                return this.partners;
            }
            set
            {
                this.partners = value;
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

        public List<WeihuaGames.ClientClass.Location> SkillLocations
        {
            get
            {
                return this.skillLocations;
            }
            set
            {
                this.skillLocations = value;
            }
        }
    }
}

