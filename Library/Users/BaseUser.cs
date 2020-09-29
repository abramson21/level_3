using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace eMailSender.Library.Users
{
    class BaseUser
    {
        private string eMail;
        private string nameUser;
        public BaseUser(string eMail, string nameUser)
        {
            this.eMail = eMail;
            this.nameUser = nameUser;
        }

        public MailAddress GetInfoUser()
        {
            return new MailAddress(eMail, nameUser);
        }


    }
}
