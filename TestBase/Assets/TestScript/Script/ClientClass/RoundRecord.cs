namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;

    using System;
    using System.Collections.Generic;

    public class RoundRecord
    {
        public Dictionary<string, string> configParameterDic = new Dictionary<string, string>();
        private int roundIndex;
        private int roundType;
        private int rowIndex;
        private int teamIndex;
        private List<WeihuaGames.ClientClass.TurnRecord> turnRecords = new List<WeihuaGames.ClientClass.TurnRecord>();

        public static WeihuaGames.ClientClass.RoundRecord CopyTo(WeihuaGames.ClientClass.RoundRecord theOne)
        {
            WeihuaGames.ClientClass.RoundRecord record = new WeihuaGames.ClientClass.RoundRecord {
                roundType = theOne.roundType,
                teamIndex = theOne.teamIndex,
                rowIndex = theOne.rowIndex,
                roundIndex = theOne.roundIndex
            };
            if (theOne.configParameterDic != null)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in theOne.configParameterDic)
                {
                    dictionary.Add(pair.Key, pair.Value);
                }
                record.configParameterDic = dictionary;
            }
            foreach (WeihuaGames.ClientClass.TurnRecord record2 in theOne.turnRecords)
            {
                record.turnRecords.Add(WeihuaGames.ClientClass.TurnRecord.CopyTo(record2));
            }
            return record;
        }

        public WeihuaGames.ClientClass.RoundRecord FromProtobuf(com.kodgames.corgi.protocol.RoundRecord roundRecord)
        {
            //this.roundType = roundRecord.roundType;
            //this.teamIndex = roundRecord.teamIndex;
            //this.rowIndex = roundRecord.rowIndex;
            //this.roundIndex = roundRecord.roundIndex;
            //foreach (com.kodgames.corgi.protocol.TurnRecord record in roundRecord.turnRecords)
            //{
            //    this.turnRecords.Add(new WeihuaGames.ClientClass.TurnRecord().FromProtobuf(record));
            //}
            //this.configParameterDic = new Dictionary<string, string>();
            //foreach (com.kodgames.corgi.protocol.ConfigParameter parameter in roundRecord.customRoundParameters)
            //{
            //    if (!this.configParameterDic.ContainsKey(parameter.name))
            //    {
            //        this.configParameterDic.Add(parameter.name, parameter.value);
            //    }
            //    else
            //    {
            //        Logger.Error("[RoundRecord] ConfigParameter repeated. parameter name=" + parameter.name, new object[0]);
            //    }
            //}
            return this;
        }

        public string Parameter(string name)
        {
            if (((this.configParameterDic != null) && (this.configParameterDic.Count != 0)) && this.configParameterDic.ContainsKey(name))
            {
                return this.configParameterDic[name];
            }
            return "";
        }

        public com.kodgames.corgi.protocol.RoundRecord ToProtobuf()
        {
            com.kodgames.corgi.protocol.RoundRecord record = new com.kodgames.corgi.protocol.RoundRecord {
                roundType = this.roundType,
                teamIndex = this.teamIndex,
                rowIndex = this.rowIndex,
                roundIndex = this.roundIndex
            };
            foreach (WeihuaGames.ClientClass.TurnRecord record2 in this.turnRecords)
            {
                record.turnRecords.Add(record2.ToProtobuf());
            }
            if (this.configParameterDic != null)
            {
                record.customRoundParameters.Clear();
                foreach (KeyValuePair<string, string> pair in this.configParameterDic)
                {
                    com.kodgames.corgi.protocol.ConfigParameter item = new com.kodgames.corgi.protocol.ConfigParameter {
                        name = pair.Key,
                        value = pair.Value
                    };
                    record.customRoundParameters.Add(item);
                }
            }
            return record;
        }

        public int RoundIndex
        {
            get
            {
                return this.roundIndex;
            }
            set
            {
                this.roundIndex = value;
            }
        }

        public int RoundType
        {
            get
            {
                return this.roundType;
            }
            set
            {
                this.roundType = value;
            }
        }

        public int RowIndex
        {
            get
            {
                return this.rowIndex;
            }
            set
            {
                this.rowIndex = value;
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

        public List<WeihuaGames.ClientClass.TurnRecord> TurnRecords
        {
            get
            {
                return this.turnRecords;
            }
        }
    }
}

