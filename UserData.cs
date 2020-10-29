using System;

namespace BookStoreLIB
{
    public class UserData
    {
        public int UserID { set; get; }

        public string LoginName { set; get; }

        public string Password { set; get; }

        public Boolean LogIn(string loginName, string passWord)
        {

            var dbUser = new DALUserInfo();
            UserID = dbUser.Login(loginName, passWord);
            if (UserID > 0)
            {
                LoginName = loginName;
                Password = passWord;
                return true;
            }
            else
                return false;
        }
    }
}