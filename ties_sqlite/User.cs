using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ties_sqlite
{
    public class User
    {
        private string nickname;
        private string status;
        
        public User()
        {
            nickname = "unknown";
            status = "unknown";
        }

        public User(List<string> data)
        {
            nickname = data[0];
            status = data[1];
        }

        public List<string> GetUser()
        {
            List<string> data = new List<string>
            {
                [0] = nickname,
                [1] = status
            };

            return data;
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
