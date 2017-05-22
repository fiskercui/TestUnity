namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class EmailData
    {
        private Dictionary<int, EmailTypeData> displayType_EmailDict = new Dictionary<int, EmailTypeData>();
        private string lastQueryTime;

        public void AddEmail(int displayType, EmailPlayer email)
        {
            if (email != null)
            {
                this.TryToAddEmailType(displayType);
                if (this.displayType_EmailDict[displayType].emails == null)
                {
                    this.displayType_EmailDict[displayType].emails = new List<EmailPlayer>();
                }
                this.displayType_EmailDict[displayType].emails.Add(email);
                this.displayType_EmailDict[displayType].emails.Sort(new Comparison<EmailPlayer>(this.SortEmailByReceiveTime));
            }
        }

        public EmailPlayer GetEmailById(long emailId)
        {
            foreach (KeyValuePair<int, EmailTypeData> pair in this.displayType_EmailDict)
            {
                foreach (EmailPlayer player in pair.Value.emails)
                {
                    if (player.EmailId == emailId)
                    {
                        return player;
                    }
                }
            }
            return null;
        }

        public List<EmailPlayer> GetEmails(int displayType)
        {
            if (!this.displayType_EmailDict.ContainsKey(displayType))
            {
                return null;
            }
            return this.displayType_EmailDict[displayType].emails;
        }

        public int GetNewEmailCount(int type)
        {
            if (!this.displayType_EmailDict.ContainsKey(type))
            {
                return 0;
            }
            return this.displayType_EmailDict[type].newCount;
        }

        public void RemoveEmail(int emailId)
        {
            EmailPlayer emailById = this.GetEmailById((long) emailId);
            if (emailById != null)
            {
                foreach (KeyValuePair<int, EmailTypeData> pair in this.displayType_EmailDict)
                {
                    if ((pair.Value.emails != null) && pair.Value.emails.Remove(emailById))
                    {
                        break;
                    }
                }
            }
        }

        public void SetEmails(int displayType, List<EmailPlayer> emails)
        {
            this.TryToAddEmailType(displayType);
            this.displayType_EmailDict[displayType].emails = emails;
            this.displayType_EmailDict[displayType].emails.Sort(new Comparison<EmailPlayer>(this.SortEmailByReceiveTime));
        }

        public void SetNewEmailCount(int displayType, int count)
        {
            this.TryToAddEmailType(displayType);
            this.displayType_EmailDict[displayType].newCount = count;
        }

        private int SortEmailByReceiveTime(EmailPlayer emailOne, EmailPlayer emailTwo)
        {
            long sendTime = emailOne.SendTime;
            long num2 = emailTwo.SendTime;
            if (sendTime > num2)
            {
                return -1;
            }
            if (sendTime < num2)
            {
                return 1;
            }
            return (int) (emailOne.EmailId - emailTwo.EmailId);
        }

        private void TryToAddEmailType(int displayType)
        {
            if (!this.displayType_EmailDict.ContainsKey(displayType))
            {
                EmailTypeData data = new EmailTypeData {
                    displayType = displayType,
                    newCount = 0,
                    emails = null
                };
                this.displayType_EmailDict.Add(displayType, data);
            }
        }

        public string LastQueryTime
        {
            get
            {
                return this.lastQueryTime;
            }
            set
            {
                this.lastQueryTime = value;
            }
        }

        private class EmailTypeData
        {
            public int displayType;
            public List<EmailPlayer> emails;
            public int newCount;
        }
    }
}

