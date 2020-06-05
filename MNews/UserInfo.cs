using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNews
{
    public class UserInfo
    {
        private string account;
        private string pwd;
        private string email;
        private string identity;
        private string status;

        public string UserAccount
        {
            get { return this.account; }
            set { this.account = value; }
        }
        public string UserPwd
        {
            get { return this.pwd; }
            set { this.pwd = value; }
        }
        public string UserMail
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string UserIdentity
        {
            get { return this.identity; }
            set { this.identity = value; }
        }
        public string UserStatus
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
