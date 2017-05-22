namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class DanAttribute
    {
        private List<int> funcParams = new List<int>();
        private int funcType;
        private int id;
        private List<WeihuaGames.ClientClass.PropertyModifierSet> propertyModifierSets = new List<WeihuaGames.ClientClass.PropertyModifierSet>();
        private List<WeihuaGames.ClientClass.TargetCondition> targetConditions = new List<WeihuaGames.ClientClass.TargetCondition>();

        public WeihuaGames.ClientClass.DanAttribute FromProtobuf(com.kodgames.corgi.protocol.DanAttribute danAttribute)
        {
            if (danAttribute != null)
            {
                this.id = danAttribute.id;
                this.FuncType = danAttribute.funcType;
                this.propertyModifierSets.Clear();
                if (danAttribute.propertyModifierSets != null)
                {
                    foreach (com.kodgames.corgi.protocol.PropertyModifierSet set in danAttribute.propertyModifierSets)
                    {
                        WeihuaGames.ClientClass.PropertyModifierSet item = new WeihuaGames.ClientClass.PropertyModifierSet();
                        item.FromProtobuf(set);
                        this.PropertyModifierSets.Add(item);
                    }
                }
                this.targetConditions.Clear();
                if (danAttribute.targetConditions != null)
                {
                    foreach (com.kodgames.corgi.protocol.TargetCondition condition in danAttribute.targetConditions)
                    {
                        WeihuaGames.ClientClass.TargetCondition condition2 = new WeihuaGames.ClientClass.TargetCondition();
                        condition2.FromProtobuf(condition);
                        this.TargetConditions.Add(condition2);
                    }
                }
                this.funcParams.Clear();
                if (danAttribute.funcParams != null)
                {
                    foreach (int num in danAttribute.funcParams)
                    {
                        this.funcParams.Add(num);
                    }
                }
            }
            return this;
        }

        public List<int> FuncParams
        {
            get
            {
                return this.funcParams;
            }
            set
            {
                this.funcParams = value;
            }
        }

        public int FuncType
        {
            get
            {
                return this.funcType;
            }
            set
            {
                this.funcType = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public List<WeihuaGames.ClientClass.PropertyModifierSet> PropertyModifierSets
        {
            get
            {
                return this.propertyModifierSets;
            }
            set
            {
                this.propertyModifierSets = value;
            }
        }

        public List<WeihuaGames.ClientClass.TargetCondition> TargetConditions
        {
            get
            {
                return this.targetConditions;
            }
            set
            {
                this.targetConditions = value;
            }
        }
    }
}

