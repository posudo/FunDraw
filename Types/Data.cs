using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDraw.Types
{
    public class Data
    {
        public UserData user;
        public string accessToken;
        public string refreshToken;
    }

    public class UserData
    {
        public string id;
        public string username;
        public string email;
        public DateTime createdAt;
        public string avatar;
    }

    public class TokenData
    {
        public string accessToken;
        public string refreshToken;
    }
    public class UserProfile
    {
        public string Username { get; set; }
        public string ID { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Email { get; set; }
    }
}
