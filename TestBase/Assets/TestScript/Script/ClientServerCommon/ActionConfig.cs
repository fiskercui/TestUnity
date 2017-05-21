namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Security;

    [ProtoContract(Name="ActionConfig")]
    public class ActionConfig : Configuration, IExtensible
    {
        private readonly List<AvatarAction> _avatarActions = new List<AvatarAction>();
        private readonly List<ClientServerCommon.Buff> _buffs = new List<ClientServerCommon.Buff>();
        private readonly List<CombatTurn> _combatTurns = new List<CombatTurn>();
        private readonly List<Function> _functions = new List<Function>();
        private readonly List<GlobalBuffSuperpositionType> _globalBuffSuperpositionTypes = new List<GlobalBuffSuperpositionType>();
        private Dictionary<int, AvatarAction> _id_actionMap = new Dictionary<int, AvatarAction>();
        private IExtension extensionObject;
        private Dictionary<int, CombatTurn> id_turnMap = new Dictionary<int, CombatTurn>();
        private Dictionary<int, List<CombatTurn>> type_turnsMap = new Dictionary<int, List<CombatTurn>>();
        private Dictionary<int, Dictionary<int, Dictionary<int, List<AvatarAction>>>> weapon_state_type_actionMap = new Dictionary<int, Dictionary<int, Dictionary<int, List<AvatarAction>>>>();

        public void AddAction(AvatarAction avatarAction)
        {
            if (avatarAction != null)
            {
                this.avatarActions.Add(avatarAction);
            }
        }

        private void AddCombatTurn(CombatTurn combatTurn)
        {
            if (combatTurn != null)
            {
                this.combatTurns.Add(combatTurn);
            }
        }

        public void AddFunction(Function function)
        {
            if (function != null)
            {
                this.functions.Add(function);
            }
        }

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (AvatarAction action in this._avatarActions)
            {
                if (action != null)
                {
                    if (this._id_actionMap.ContainsKey(action.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + action.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this._id_actionMap.Add(action.id, action);
                        Dictionary<int, Dictionary<int, List<AvatarAction>>> dictionary = null;
                        if (!this.weapon_state_type_actionMap.TryGetValue(action.weaponType, out dictionary))
                        {
                            dictionary = new Dictionary<int, Dictionary<int, List<AvatarAction>>>();
                            this.weapon_state_type_actionMap.Add(action.weaponType, dictionary);
                        }
                        Dictionary<int, List<AvatarAction>> dictionary2 = null;
                        if (!dictionary.TryGetValue(action.combatStateType, out dictionary2))
                        {
                            dictionary2 = new Dictionary<int, List<AvatarAction>>();
                            dictionary.Add(action.combatStateType, dictionary2);
                        }
                        List<AvatarAction> list = null;
                        if (!dictionary2.TryGetValue(action.actionType, out list))
                        {
                            list = new List<AvatarAction>();
                            dictionary2.Add(action.actionType, list);
                        }
                        list.Add(action);
                    }
                }
            }
            foreach (CombatTurn turn in this._combatTurns)
            {
                if (turn != null)
                {
                    if (this.id_turnMap.ContainsKey(turn.id))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + turn.id.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this.id_turnMap.Add(turn.id, turn);
                        if (!this.type_turnsMap.ContainsKey(turn.type))
                        {
                            this.type_turnsMap.Add(turn.type, new List<CombatTurn>());
                        }
                        this.type_turnsMap[turn.type].Add(turn);
                    }
                }
            }
        }

        public AvatarAction GetActionById(int id)
        {
            AvatarAction action;
            if (AvatarAction.IsBuffActionID(id))
            {
                ClientServerCommon.Buff buffById = this.GetBuffById(ClientServerCommon.Buff.GetBuffIDFromBuffActionID(id));
                if (buffById == null)
                {
                    return null;
                }
                return buffById.GetActionById(ClientServerCommon.Buff.GetActionIDFromBuffActionID(id));
            }
            if (!this._id_actionMap.TryGetValue(id, out action))
            {
                return null;
            }
            return action;
        }

        public int GetActionCountInType(int weaponType, int stateType, int actionType)
        {
            Dictionary<int, Dictionary<int, List<AvatarAction>>> dictionary = null;
            if (!this.weapon_state_type_actionMap.TryGetValue(weaponType, out dictionary))
            {
                return 0;
            }
            Dictionary<int, List<AvatarAction>> dictionary2 = null;
            if (!dictionary.TryGetValue(stateType, out dictionary2))
            {
                return 0;
            }
            List<AvatarAction> list = null;
            if (!dictionary2.TryGetValue(actionType, out list))
            {
                return 0;
            }
            return list.Count;
        }

        public AvatarAction GetActionInTypeByIndex(int weaponType, int stateType, int actionType, int actionIdx)
        {
            Dictionary<int, Dictionary<int, List<AvatarAction>>> dictionary = null;
            if (this.weapon_state_type_actionMap.TryGetValue(weaponType, out dictionary))
            {
                Dictionary<int, List<AvatarAction>> dictionary2 = null;
                if (!dictionary.TryGetValue(stateType, out dictionary2))
                {
                    return null;
                }
                List<AvatarAction> list = null;
                if (!dictionary2.TryGetValue(actionType, out list))
                {
                    return null;
                }
                if ((actionIdx >= 0) && (actionIdx <= list.Count))
                {
                    return dictionary2[actionType][actionIdx];
                }
            }
            return null;
        }

        public ClientServerCommon.Buff GetBuffById(int id)
        {
            foreach (ClientServerCommon.Buff buff in this.buffs)
            {
                if (buff.id == id)
                {
                    return buff;
                }
            }
            return null;
        }

        public GlobalBuffSuperpositionType GetBuffSuperpositionTypeByBuffType(int buffType)
        {
            foreach (GlobalBuffSuperpositionType type in this._globalBuffSuperpositionTypes)
            {
                if (type.buffType == buffType)
                {
                    return new GlobalBuffSuperpositionType { 
                        buffType = buffType,
                        superpositionType = type.superpositionType,
                        conflictStrategy = type.conflictStrategy
                    };
                }
            }
            return null;
        }

        public CombatTurn GetCombatTurnByID(int ID)
        {
            CombatTurn turn = null;
            if (!this.id_turnMap.TryGetValue(ID, out turn))
            {
                return null;
            }
            return turn;
        }

        public CombatTurn GetCombatTurnByType(int turnType, int randomer)
        {
            List<CombatTurn> list = null;
            if (!this.type_turnsMap.TryGetValue(turnType, out list))
            {
                return null;
            }
            if (list.Count == 0)
            {
                return null;
            }
            return list[randomer % list.Count];
        }

        public PropertyModifierSet GetModifierSetByIdAndLevel(int skillId, int skillLevel)
        {
            CombatTurn combatTurnByID = this.GetCombatTurnByID(skillId);
            if ((combatTurnByID == null) || (combatTurnByID.type != 5))
            {
                return null;
            }
            int id = combatTurnByID.GetStage(3).value;
            AvatarAction actionById = this.GetActionById(id);
            if (actionById == null)
            {
                return null;
            }
            AvatarAction.Event event2 = (actionById.events.Count != 0) ? actionById.events[0] : null;
            if ((event2 == null) || (event2.eventType != 4))
            {
                return null;
            }
            ClientServerCommon.Buff buffById = this.GetBuffById(event2.buffId);
            if (buffById == null)
            {
                return null;
            }
            return buffById.GetModifierSetByLevelFilter(skillLevel);
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _AnimationType.Initialize();
            _CombatStateType.Initialize();
            AvatarAction._Type.Initialize();
            AvatarAction.Event._Type.Initialize();
            AvatarAction.Effect._Type.Initialize();
            AvatarAction.Effect._PlayTargetType.Initialize();
            AvatarAction.Effect._DestroyType.Initialize();
            CombatTurn._Type.Initialize();
            CombatTurn._TestType.Initialize();
            ClientServerCommon.Buff._BuffType.Initialize();
            ClientServerCommon.Buff._SuperpositionType.Initialize();
            ClientServerCommon.Buff._ConflictStrategy.Initialize();
            TargetCondition._Type.Initialize();
            TargetCondition._SubType.Initialize();
            TargetCondition._SortType.Initialize();
            CombatTurn.Stage._StageType.Initialize();
            CombatTurn.Stage._ValueType.Initialize();
            ClientServerCommon.Buff._DurationCheckType.Initialize();
        }

        private AvatarAction LoadActionFromXml(SecurityElement element, int sourceTurnId)
        {
            AvatarAction action = new AvatarAction {
                sourceTurnId = sourceTurnId,
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                actionType = TypeNameContainer<AvatarAction._Type>.Parse(element.Attribute("ActionType"), 0),
                weaponType = TypeNameContainer<EquipmentConfig._WeaponType>.Parse(element.Attribute("WeaponType"), 0),
                combatStateType = TypeNameContainer<_CombatStateType>.Parse(element.Attribute("CombatStateType"), 0),
                loop = StrParser.ParseBool(element.Attribute("Loop"), false),
                //sourceTurnId = sourceTurnId
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Event")
                        {
                            action.events.Add(this.LoadEventFromXml(element2, action.events.Count, sourceTurnId));
                        }
                        else if (tag == "Animation")
                        {
                            goto Label_00F2;
                        }
                    }
                    continue;
                Label_00F2:
                    action.animations.Add(this.LoadAnimationFromXml(element2));
                }
                action.animations.Sort((Comparison<AvatarAction.Animation>) ((a1, a2) => (a2.type - a1.type)));
            }
            return action;
        }

        private void LoadActionSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Action")
                    {
                        this.AddAction(this.LoadActionFromXml(element2, 0));
                    }
                }
            }
        }

        public AvatarAction.Animation LoadAnimationFromXml(SecurityElement element)
        {
            if (element.Tag != "Animation")
            {
                return null;
            }
            AvatarAction.Animation animation = new AvatarAction.Animation {
                type = TypeNameContainer<_AnimationType>.Parse(element.Attribute("Type"), 1)
            };
            animation.value = StrParser.ParseHexInt(element.Attribute("Value"), animation.value);
            animation.animation = StrParser.ParseStr(element.Attribute("Animation"), animation.animation);
            return animation;
        }

        private ClientServerCommon.Buff LoadBuffFromXml(SecurityElement element, int sourceTurnId)
        {
            ClientServerCommon.Buff buff = new ClientServerCommon.Buff {
                id = StrParser.ParseHexInt(element.Attribute("Id"), 0),
                buffType = TypeNameContainer<ClientServerCommon.Buff._BuffType>.Parse(element.Attribute("BuffType"), 1),
                superpositionType = TypeNameContainer<ClientServerCommon.Buff._SuperpositionType>.Parse(element.Attribute("SuperpositionType"), 1),
                conflictStrategy = TypeNameContainer<ClientServerCommon.Buff._ConflictStrategy>.Parse(element.Attribute("ConflictStrategy"), 1),
                uiName = StrParser.ParseStr(element.Attribute("UIName"), "")
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    AvatarAction.Effect effect;
                    AvatarAction action;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "ModifierSet")
                        {
                            if (tag == "Effect")
                            {
                                goto Label_00F1;
                            }
                            if (tag == "Action")
                            {
                                goto Label_010A;
                            }
                        }
                        else
                        {
                            buff.modifierSets.Add(PropertyModifierSet.LoadFromXml(element2));
                        }
                    }
                    continue;
                Label_00F1:
                    effect = this.LoadEffectFromXml(element2);
                    if (effect != null)
                    {
                        buff.effects.Add(effect);
                    }
                    continue;
                Label_010A:
                    action = this.LoadActionFromXml(element2, sourceTurnId);
                    if (action != null)
                    {
                        buff.actions.Add(action);
                    }
                }
            }
            return buff;
        }

        private void LoadBuffSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Buff")
                    {
                        this.buffs.Add(this.LoadBuffFromXml(element2, 0));
                    }
                }
            }
        }

        public CombatTurn LoadCombatTurnFromXml(SecurityElement element)
        {
            if (element.Tag != "CombatTurn")
            {
                return null;
            }
            CombatTurn turn = new CombatTurn();
            turn.id = StrParser.ParseHexInt(element.Attribute("Id"), turn.id);
            turn.type = TypeNameContainer<CombatTurn._Type>.Parse(element.Attribute("Type"), turn.type);
            turn.costSkillPower = StrParser.ParseDecInt(element.Attribute("CostSkillPower"), turn.costSkillPower);
            turn.castRate = StrParser.ParseFloat(element.Attribute("CastRate"), turn.castRate);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    CombatTurn.Stage stage;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "TestType")
                        {
                            int num = TypeNameContainer<CombatTurn._TestType>.Parse(element2.Text, 0);
                            if (num != 0)
                            {
                                turn.testType |= num;
                            }
                        }
                        else if (tag == "Stage")
                        {
                            goto Label_00FA;
                        }
                    }
                    continue;
                Label_00FA:
                    stage = this.LoadStageFromXml(element2, turn.id);
                    if (stage != null)
                    {
                        turn.stages.Add(stage);
                    }
                }
            }
            return turn;
        }

        private void LoadCombatTurnSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "CombatTurn")
                    {
                        this.AddCombatTurn(this.LoadCombatTurnFromXml(element2));
                    }
                }
            }
        }

        public AvatarAction.Effect LoadEffectFromXml(SecurityElement element)
        {
            AvatarAction.Effect effect = new AvatarAction.Effect();
            effect.type = TypeNameContainer<AvatarAction.Effect._Type>.Parse(element.Attribute("Type"), effect.type);
            effect.isGetHitFX = StrParser.ParseBool(element.Attribute("IsGetHitFX"), effect.isGetHitFX);
            effect.pfx_PlayOnTarget = StrParser.ParseBool(element.Attribute("PlayOnTarget"), effect.pfx_PlayOnTarget);
            effect.pfx_PlayTargetType = TypeNameContainer<AvatarAction.Effect._PlayTargetType>.Parse(element.Attribute("PlayTargetType"), effect.pfx_PlayTargetType);
            effect.pfx_Model = StrParser.ParseStr(element.Attribute("Model"), effect.pfx_Model);
            effect.pfx_ModelBone = StrParser.ParseStr(element.Attribute("ModelBone"), effect.pfx_ModelBone);
            effect.pfx_Bone = StrParser.ParseStr(element.Attribute("Bone"), effect.pfx_Bone);
            effect.pfx_Offset = vector3.LoadFromXml(element.Attribute("Offset"));
            effect.pfx_Rotate = vector3.LoadFromXml(element.Attribute("Rotate"));
            effect.pfx_BoneFollow = StrParser.ParseBool(element.Attribute("BoneFollow"), effect.pfx_BoneFollow);
            effect.pfx_Curve = StrParser.ParseStr(element.Attribute("Curve"), effect.pfx_Curve);
            effect.pfx_Curve_Miss = StrParser.ParseStr(element.Attribute("Curve_Miss"), effect.pfx_Curve_Miss);
            effect.pfx_CurveToTarget = StrParser.ParseBool(element.Attribute("CurveToTarget"), effect.pfx_CurveToTarget);
            effect.pfx_CurveTargetBone = StrParser.ParseStr(element.Attribute("CurveTargetBone"), effect.pfx_CurveTargetBone);
            effect.pfx_CurveTargetOffset = vector3.LoadFromXml(element.Attribute("CurveTargetOffset"));
            effect.pfx_CurveSpeed = StrParser.ParseFloat(element.Attribute("CurveSpeed"), 1f);
            effect.pfx_CurveTranslateSpeed = StrParser.ParseFloat(element.Attribute("CurveTranslateSpeed"), 1f);
            effect.pfx_DestroyType = TypeNameContainer<AvatarAction.Effect._DestroyType>.Parse(element.Attribute("DestroyType"), effect.pfx_DestroyType);
            effect.sfx_Sound = StrParser.ParseStr(element.Attribute("Sound"), effect.sfx_Sound);
            effect.sfx_Loop = StrParser.ParseBool(element.Attribute("Loop"), effect.sfx_Loop);
            effect.sfx_Volume = StrParser.ParseFloat(element.Attribute("Volume"), 0f);
            effect.cfx_Intensity = StrParser.ParseFloat(element.Attribute("Intensity"), 0f);
            effect.cfx_Duration = StrParser.ParseFloat(element.Attribute("Duration"), 0f);
            effect.cfx_Interval = StrParser.ParseFloat(element.Attribute("Interval"), 0f);
            effect.tfx_Scale = StrParser.ParseFloat(element.Attribute("Scale"), 0f);
            effect.tfx_Duration = StrParser.ParseFloat(element.Attribute("Duration"), 0f);
            return effect;
        }

        public AvatarAction.Event LoadEventFromXml(SecurityElement element, int eventIdx, int sourceTurnID)
        {
            AvatarAction.Event event2 = new AvatarAction.Event {
                sourceTurnId = sourceTurnID,
                index = eventIdx
            };
            event2.keyFrameId = StrParser.ParseDecInt(element.Attribute("KeyFrameId"), event2.keyFrameId);
            event2.eventType = TypeNameContainer<AvatarAction.Event._Type>.Parse(element.Attribute("Type"), 0);
            event2.delay = StrParser.ParseFloat(element.Attribute("Delay"), 0f);
            event2.loop = StrParser.ParseBool(element.Attribute("Loop"), event2.loop);
            event2.playOnAllTarget = StrParser.ParseBool(element.Attribute("PlayOnAllTarget"), event2.playOnAllTarget);
            event2.weaponId = StrParser.ParseHexInt(element.Attribute("WeaponId"), 0);
            event2.boneName = StrParser.ParseStr(element.Attribute("BoneName"), "");
            event2.buffType = TypeNameContainer<ClientServerCommon.Buff._BuffType>.ParseBitList(element.Attribute("BuffType"), 0);
            event2.modifyType = TypeNameContainer<PropertyModifier._ValueModifyType>.Parse(element.Attribute("ModifyType"), 2);
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    int num;
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "Effect")
                        {
                            if (tag == "Buff")
                            {
                                goto Label_017E;
                            }
                            if (tag == "ModifierSet")
                            {
                                goto Label_0193;
                            }
                            if (tag == "TestType")
                            {
                                goto Label_01A6;
                            }
                        }
                        else
                        {
                            event2.effects.Add(this.LoadEffectFromXml(element2));
                        }
                    }
                    continue;
                Label_017E:
                    this.buffs.Add(this.LoadBuffFromXml(element2, sourceTurnID));
                    continue;
                Label_0193:
                    event2.modifierSets.Add(PropertyModifierSet.LoadFromXml(element2));
                    continue;
                Label_01A6:
                    num = TypeNameContainer<CombatTurn._TestType>.Parse(element2.Text, 0);
                    if (num != 0)
                    {
                        event2.testType |= num;
                    }
                }
            }
            event2.buffId = StrParser.ParseHexInt(element.Attribute("BuffId"), 0);
            return event2;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "ActionConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "FunctionSet")
                    {
                        this.LoadFunctionSetFromXml(element2);
                        break;
                    }
                }
                foreach (SecurityElement element3 in element.Children)
                {
                    string tag = element3.Tag;
                    if (tag != null)
                    {
                        if (tag != "ActionSet")
                        {
                            if (tag == "CombatTurnSet")
                            {
                                goto Label_00D8;
                            }
                            if (tag == "BuffSet")
                            {
                                goto Label_00E1;
                            }
                            if (tag == "GlobalBuffSuperpositionTypeSet")
                            {
                                goto Label_00EA;
                            }
                        }
                        else
                        {
                            this.LoadActionSetFromXml(element3);
                        }
                    }
                    continue;
                Label_00D8:
                    this.LoadCombatTurnSetFromXml(element3);
                    continue;
                Label_00E1:
                    this.LoadBuffSetFromXml(element3);
                    continue;
                Label_00EA:
                    this.LoadGlobalBuffSuperpositionTypeSetFromXml(element3);
                }
            }
        }

        public Function LoadFunctionFromXml(SecurityElement element)
        {
            if (element.Tag != "Function")
            {
                return null;
            }
            Function function = new Function();
            function.name = StrParser.ParseStr(element.Attribute("Name"), function.name);
            function.value = StrParser.ParseStr(element.Attribute("Value"), function.value);
            return function;
        }

        private void LoadFunctionSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Function")
                    {
                        this.AddFunction(this.LoadFunctionFromXml(element2));
                    }
                }
            }
        }

        private GlobalBuffSuperpositionType LoadGlobalBuffSuperpositionTypeFromXml(SecurityElement element)
        {
            return new GlobalBuffSuperpositionType { 
                buffType = TypeNameContainer<ClientServerCommon.Buff._BuffType>.Parse(element.Attribute("BuffType"), 0),
                superpositionType = TypeNameContainer<ClientServerCommon.Buff._SuperpositionType>.Parse(element.Attribute("SuperpositionType"), 1),
                conflictStrategy = TypeNameContainer<ClientServerCommon.Buff._ConflictStrategy>.Parse(element.Attribute("ConflictStrategy"), 1)
            };
        }

        private void LoadGlobalBuffSuperpositionTypeSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "GlobalBuffSuperpositionType")
                    {
                        this._globalBuffSuperpositionTypes.Add(this.LoadGlobalBuffSuperpositionTypeFromXml(element2));
                    }
                }
            }
        }

        public CombatTurn.Stage LoadStageFromXml(SecurityElement element, int sourceTurnID)
        {
            if (element.Tag != "Stage")
            {
                return null;
            }
            int num = TypeNameContainer<CombatTurn.Stage._StageType>.Parse(element.Attribute("Type"), 7);
            if (num == 7)
            {
                return null;
            }
            int num2 = TypeNameContainer<CombatTurn.Stage._ValueType>.Parse(element.Attribute("ValueType"), 0);
            if (num2 == 0)
            {
                return null;
            }
            CombatTurn.Stage stage = new CombatTurn.Stage {
                type = num,
                valueType = num2
            };
            switch (num2)
            {
                case 1:
                    stage.value = StrParser.ParseHexInt(element.Attribute("Value"), 0);
                    break;

                case 2:
                    stage.value = TypeNameContainer<AvatarAction._Type>.Parse(element.Attribute("Value"), 0);
                    break;
            }
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Action")
                    {
                        this.AddAction(this.LoadActionFromXml(element2, sourceTurnID));
                    }
                }
            }
            return stage;
        }

        [ProtoMember(1, Name="avatarActions", DataFormat=DataFormat.Default)]
        public List<AvatarAction> avatarActions
        {
            get
            {
                return this._avatarActions;
            }
        }

        [ProtoMember(3, Name="buffs", DataFormat=DataFormat.Default)]
        public List<ClientServerCommon.Buff> buffs
        {
            get
            {
                return this._buffs;
            }
        }

        [ProtoMember(2, Name="combatTurns", DataFormat=DataFormat.Default)]
        public List<CombatTurn> combatTurns
        {
            get
            {
                return this._combatTurns;
            }
        }

        [ProtoMember(4, Name="functions", DataFormat=DataFormat.Default)]
        public List<Function> functions
        {
            get
            {
                return this._functions;
            }
        }

        [ProtoMember(5, Name="globalBuffSuperpositionTypes", DataFormat=DataFormat.Default)]
        public List<GlobalBuffSuperpositionType> globalBuffSuperpositionTypes
        {
            get
            {
                return this._globalBuffSuperpositionTypes;
            }
        }
    }
}

