namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="IncreaseCost")]
    public class IncreaseCost : IExtensible
    {
        private readonly List<Cost> _costs = new List<Cost>();
        private int _fromStep;
        private IExtension extensionObject;

        public static List<Cost> GetCosts(List<IncreaseCost> increaseCosts, int step)
        {
            IncreaseCost cost = null;
            foreach (IncreaseCost cost2 in increaseCosts)
            {
                if (((cost == null) || (cost._fromStep <= cost2._fromStep)) && (step >= cost2._fromStep))
                {
                    cost = cost2;
                }
            }
            List<Cost> list = new List<Cost>();
            if (cost != null)
            {
                foreach (Cost cost3 in cost.costs)
                {
                    Cost item = new Cost {
                        id = cost3.id,
                        count = cost3.count + ((step - cost.fromStep) * cost3.increase)
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static IncreaseCost LoadFromXml(SecurityElement element)
        {
            IncreaseCost cost = new IncreaseCost {
                _fromStep = StrParser.ParseDecInt(element.Attribute("FromStep"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Cost"))
                    {
                        cost._costs.Add(Cost.LoadFromXml(element2));
                    }
                }
            }
            return cost;
        }

        [ProtoMember(2, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="fromStep", DataFormat=DataFormat.TwosComplement)]
        public int fromStep
        {
            get
            {
                return this._fromStep;
            }
            set
            {
                this._fromStep = value;
            }
        }
    }
}

