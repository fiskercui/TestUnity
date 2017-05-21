namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="PartnerConfig")]
    public class PartnerConfig : Configuration, IExtensible
    {
        private readonly List<Partner> _partners = new List<Partner>();
        private IExtension extensionObject;

        public Partner GetPartnerById(int partnerId)
        {
            foreach (Partner partner in this._partners)
            {
                if (partner.PartnerId == partnerId)
                {
                    return partner;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "PartnerConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "PartnerSet"))
                    {
                        this.LoadPartnersFromXml(element2);
                    }
                }
            }
        }

        private Partner LoadPartnerFromXml(SecurityElement element)
        {
            Partner partner = new Partner {
                PartnerId = StrParser.ParseHexInt(element.Attribute("PartnerId"), 0),
                RequirePlayerLevel = StrParser.ParseDecInt(element.Attribute("RequirePlayerLevel"), 0),
                RequireVipLevel = StrParser.ParseDecInt(element.Attribute("RequireVipLevel"), 0),
                IsOpen = StrParser.ParseBool(element.Attribute("IsOpen"), false),
                AffectType = TypeNameContainer<PositionConfig._EmBattleType>.Parse(element.Attribute("AffectType"), 0),
                PartnerPowerPercent = StrParser.ParseFloat(element.Attribute("PartnerPowerPercent"), 0f)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Cost")
                    {
                        Cost item = Cost.LoadFromXml(element2);
                        partner.Costs.Add(item);
                    }
                    if (element2.Tag == "Modifier")
                    {
                        PropertyModifier modifier = PropertyModifier.LoadFromXml(element2);
                        partner.Modifiers.Add(modifier);
                    }
                }
            }
            return partner;
        }

        private void LoadPartnersFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Partner"))
                    {
                        this.Partners.Add(this.LoadPartnerFromXml(element2));
                    }
                }
            }
        }

        [ProtoMember(1, Name="partners", DataFormat=DataFormat.Default)]
        public List<Partner> Partners
        {
            get
            {
                return this._partners;
            }
        }

        [ProtoContract(Name="Partner")]
        public class Partner : IExtensible
        {
            private int _affectType;
            private readonly List<Cost> _costs = new List<Cost>();
            private bool _isOpen;
            private readonly List<PropertyModifier> _modifiers = new List<PropertyModifier>();
            private int _partnerId;
            private float _partnerPowerPercent;
            private int _requirePlayerLevel;
            private int _requireVipLevel;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="affectType", DataFormat=DataFormat.TwosComplement)]
            public int AffectType
            {
                get
                {
                    return this._affectType;
                }
                set
                {
                    this._affectType = value;
                }
            }

            [ProtoMember(6, Name="costs", DataFormat=DataFormat.Default)]
            public List<Cost> Costs
            {
                get
                {
                    return this._costs;
                }
            }

            [DefaultValue(false), ProtoMember(4, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default)]
            public bool IsOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }

            [ProtoMember(7, Name="modifiers", DataFormat=DataFormat.Default)]
            public List<PropertyModifier> Modifiers
            {
                get
                {
                    return this._modifiers;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="partnerId", DataFormat=DataFormat.TwosComplement)]
            public int PartnerId
            {
                get
                {
                    return this._partnerId;
                }
                set
                {
                    this._partnerId = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="partnerPowerPercent", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float PartnerPowerPercent
            {
                get
                {
                    return this._partnerPowerPercent;
                }
                set
                {
                    this._partnerPowerPercent = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="requirePlayerLevel", DataFormat=DataFormat.TwosComplement)]
            public int RequirePlayerLevel
            {
                get
                {
                    return this._requirePlayerLevel;
                }
                set
                {
                    this._requirePlayerLevel = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="requireVipLevel", DataFormat=DataFormat.TwosComplement)]
            public int RequireVipLevel
            {
                get
                {
                    return this._requireVipLevel;
                }
                set
                {
                    this._requireVipLevel = value;
                }
            }
        }
    }
}

