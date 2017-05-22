namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;
    using com.kodgames.corgi.protocol;
    public class NoticeData
    {
        private bool autoShowNotice;
        private List<Notice> notices;

        public bool AutoShowNotice
        {
            get
            {
                return this.autoShowNotice;
            }
            set
            {
                this.autoShowNotice = value;
            }
        }

        public List<Notice> Notices
        {
            get
            {
                return this.notices;
            }
            set
            {
                this.notices = value;
            }
        }
    }
}

