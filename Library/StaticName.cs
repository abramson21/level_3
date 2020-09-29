using System;
using System.Collections.Generic;
using System.Text;

namespace eMailSender.Library
{
    public static class StaticName
    {
        private static int smtp;

        public static int Smtp
        {
            get
            {
                return smtp;
            }
            set
            {
                smtp = (int)value;
            }
        }

        public static string GetFromEmail { get; set; }

        public static string GeToEmail { get; set; }
    }
}
