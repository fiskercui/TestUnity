namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="QinInfoConfig")]
    public class QinInfoConfig : Configuration, IExtensible
    {
        private readonly List<Cost> _answerCost = new List<Cost>();
        private ContinueReward _continueRewards;
        private int _maxContinueAnswerCount;
        private int _maxQinAnswerCount;
        private readonly List<Package> _packages = new List<Package>();
        private int _recoverTime;
        private IExtension extensionObject;

        public Package GetPackageByContinueAnswerCount(int count)
        {
            foreach (Package package in this._packages)
            {
                if (package.ContinueAnswerCount == count)
                {
                    return package;
                }
            }
            return null;
        }

        public Package GetPackageById(int packageId)
        {
            foreach (Package package in this._packages)
            {
                if (package.PackgaeId == packageId)
                {
                    return package;
                }
            }
            return null;
        }

        public Question GetQuestionById(int questionId)
        {
            foreach (Package package in this._packages)
            {
                foreach (Question question in package.Questions)
                {
                    if (question.QuestionId == questionId)
                    {
                        return question;
                    }
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _AnswerNum.Initialize();
        }

        private Answer LoadAnswerFromXml(SecurityElement element)
        {
            return new Answer { 
                AnswerNum = TypeNameContainer<_AnswerNum>.Parse(element.Attribute("AnswerNum"), 0),
                Content = StrParser.ParseStr(element.Attribute("Content"), string.Empty)
            };
        }

        private void LoadContinueRewardFromXml(SecurityElement element)
        {
            ContinueReward reward = new ContinueReward {
                ShowIcon = StrParser.ParseHexInt(element.Attribute("ShowIcon"), 0),
                FixRewardSetId = StrParser.ParseHexInt(element.Attribute("FixRewardSetId"), 0),
                RandomRewardSetId = StrParser.ParseHexInt(element.Attribute("RandomRewardSetId"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "FixDisplayReward")
                        {
                            reward.FixDisplayRewards.Add(Reward.LoadFromXml(element2));
                        }
                        else if (tag == "RandomDisplayReward")
                        {
                            goto Label_00A9;
                        }
                    }
                    continue;
                Label_00A9:
                    reward.RandomDisplayRewards.Add(Reward.LoadFromXml(element2));
                }
            }
            this._continueRewards = reward;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "QinInfoConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "PackageSet")
                        {
                            if (tag == "ContinueReward")
                            {
                                goto Label_00A1;
                            }
                            if (tag == "MaxQinAnswerCount")
                            {
                                goto Label_00AA;
                            }
                            if (tag == "RecoverTime")
                            {
                                goto Label_00BE;
                            }
                            if (tag == "MaxContinueAnswerCount")
                            {
                                goto Label_00D2;
                            }
                            if (tag == "AnswerCost")
                            {
                                goto Label_00E6;
                            }
                        }
                        else
                        {
                            this.LoadPackageSetFromXml(element2);
                        }
                    }
                    continue;
                Label_00A1:
                    this.LoadContinueRewardFromXml(element2);
                    continue;
                Label_00AA:
                    this._maxQinAnswerCount = StrParser.ParseDecInt(element2.Text, 0);
                    continue;
                Label_00BE:
                    this._recoverTime = StrParser.ParseDecInt(element2.Text, 0);
                    continue;
                Label_00D2:
                    this._maxContinueAnswerCount = StrParser.ParseDecInt(element2.Text, 0);
                    continue;
                Label_00E6:
                    this._answerCost.Add(Cost.LoadFromXml(element2));
                }
            }
        }

        private Package LoadPackageFromXml(SecurityElement element)
        {
            Package package = new Package {
                PackgaeId = StrParser.ParseHexInt(element.Attribute("PackgaeId"), 0),
                ContinueAnswerCount = StrParser.ParseDecInt(element.Attribute("ContinueAnswerCount"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Question"))
                    {
                        package.Questions.Add(this.LoadQuestionFromXml(element2));
                    }
                }
            }
            return package;
        }

        private void LoadPackageSetFromXml(SecurityElement element)
        {
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Package"))
                    {
                        this.Packages.Add(this.LoadPackageFromXml(element2));
                    }
                }
            }
        }

        private Question LoadQuestionFromXml(SecurityElement element)
        {
            Question question = new Question {
                QuestionId = StrParser.ParseHexInt(element.Attribute("QuestionId"), 0),
                Weight = StrParser.ParseDecInt(element.Attribute("Weight"), 0),
                Content = StrParser.ParseStr(element.Attribute("Content"), string.Empty),
                RightAnswer = TypeNameContainer<_AnswerNum>.Parse(element.Attribute("RightAnswer"), 0)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag == "Answer")
                        {
                            question.Answers.Add(this.LoadAnswerFromXml(element2));
                        }
                        else if (tag == "Reward")
                        {
                            goto Label_00C5;
                        }
                    }
                    continue;
                Label_00C5:
                    question.Rewards.Add(Reward.LoadFromXml(element2));
                }
            }
            return question;
        }

        [ProtoMember(6, Name="answerCost", DataFormat=DataFormat.Default)]
        public List<Cost> AnswerCost
        {
            get
            {
                return this._answerCost;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="continueRewards", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public ContinueReward ContinueRewards
        {
            get
            {
                return this._continueRewards;
            }
            set
            {
                this._continueRewards = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="maxContinueAnswerCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int MaxContinueAnswerCount
        {
            get
            {
                return this._maxContinueAnswerCount;
            }
            set
            {
                this._maxContinueAnswerCount = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="maxQinAnswerCount", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int MaxQinAnswerCount
        {
            get
            {
                return this._maxQinAnswerCount;
            }
            set
            {
                this._maxQinAnswerCount = value;
            }
        }

        [ProtoMember(1, Name="packages", DataFormat=DataFormat.Default)]
        public List<Package> Packages
        {
            get
            {
                return this._packages;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="recoverTime", DataFormat=DataFormat.TwosComplement)]
        public int RecoverTime
        {
            get
            {
                return this._recoverTime;
            }
            set
            {
                this._recoverTime = value;
            }
        }

        public class _AnswerNum : TypeNameContainer<QinInfoConfig._AnswerNum>
        {
            public const int A = 1;
            public const int B = 2;
            public const int C = 3;
            public const int UnKnow = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<QinInfoConfig._AnswerNum>.RegisterType("A", 1, "A");
                flag &= TypeNameContainer<QinInfoConfig._AnswerNum>.RegisterType("B", 2, "B");
                return (flag & TypeNameContainer<QinInfoConfig._AnswerNum>.RegisterType("C", 3, "C"));
            }
        }

        [ProtoContract(Name="Answer")]
        public class Answer : IExtensible
        {
            private int _answerNum;
            private string _content = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="answerNum", DataFormat=DataFormat.TwosComplement)]
            public int AnswerNum
            {
                get
                {
                    return this._answerNum;
                }
                set
                {
                    this._answerNum = value;
                }
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="content", DataFormat=DataFormat.Default)]
            public string Content
            {
                get
                {
                    return this._content;
                }
                set
                {
                    this._content = value;
                }
            }
        }

        [ProtoContract(Name="ContinueReward")]
        public class ContinueReward : IExtensible
        {
            private readonly List<Reward> _fixDisplayRewards = new List<Reward>();
            private int _fixRewardSetId;
            private readonly List<Reward> _randomDisplayRewards = new List<Reward>();
            private int _randomRewardSetId;
            private int _showIcon;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, Name="fixDisplayRewards", DataFormat=DataFormat.Default)]
            public List<Reward> FixDisplayRewards
            {
                get
                {
                    return this._fixDisplayRewards;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="fixRewardSetId", DataFormat=DataFormat.TwosComplement)]
            public int FixRewardSetId
            {
                get
                {
                    return this._fixRewardSetId;
                }
                set
                {
                    this._fixRewardSetId = value;
                }
            }

            [ProtoMember(2, Name="randomDisplayRewards", DataFormat=DataFormat.Default)]
            public List<Reward> RandomDisplayRewards
            {
                get
                {
                    return this._randomDisplayRewards;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="randomRewardSetId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int RandomRewardSetId
            {
                get
                {
                    return this._randomRewardSetId;
                }
                set
                {
                    this._randomRewardSetId = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="showIcon", DataFormat=DataFormat.TwosComplement)]
            public int ShowIcon
            {
                get
                {
                    return this._showIcon;
                }
                set
                {
                    this._showIcon = value;
                }
            }
        }

        [ProtoContract(Name="Package")]
        public class Package : IExtensible
        {
            private int _continueAnswerCount;
            private int _packgaeId;
            private readonly List<QinInfoConfig.Question> _questions = new List<QinInfoConfig.Question>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="continueAnswerCount", DataFormat=DataFormat.TwosComplement)]
            public int ContinueAnswerCount
            {
                get
                {
                    return this._continueAnswerCount;
                }
                set
                {
                    this._continueAnswerCount = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="packgaeId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int PackgaeId
            {
                get
                {
                    return this._packgaeId;
                }
                set
                {
                    this._packgaeId = value;
                }
            }

            [ProtoMember(3, Name="questions", DataFormat=DataFormat.Default)]
            public List<QinInfoConfig.Question> Questions
            {
                get
                {
                    return this._questions;
                }
            }
        }

        [ProtoContract(Name="Question")]
        public class Question : IExtensible
        {
            private readonly List<QinInfoConfig.Answer> _answers = new List<QinInfoConfig.Answer>();
            private string _content = "";
            private int _questionId;
            private readonly List<Reward> _rewards = new List<Reward>();
            private int _rightAnswer;
            private int _weight;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(5, Name="answers", DataFormat=DataFormat.Default)]
            public List<QinInfoConfig.Answer> Answers
            {
                get
                {
                    return this._answers;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="content", DataFormat=DataFormat.Default), DefaultValue("")]
            public string Content
            {
                get
                {
                    return this._content;
                }
                set
                {
                    this._content = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="questionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int QuestionId
            {
                get
                {
                    return this._questionId;
                }
                set
                {
                    this._questionId = value;
                }
            }

            [ProtoMember(6, Name="rewards", DataFormat=DataFormat.Default)]
            public List<Reward> Rewards
            {
                get
                {
                    return this._rewards;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="rightAnswer", DataFormat=DataFormat.TwosComplement)]
            public int RightAnswer
            {
                get
                {
                    return this._rightAnswer;
                }
                set
                {
                    this._rightAnswer = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="weight", DataFormat=DataFormat.TwosComplement)]
            public int Weight
            {
                get
                {
                    return this._weight;
                }
                set
                {
                    this._weight = value;
                }
            }
        }
    }
}

