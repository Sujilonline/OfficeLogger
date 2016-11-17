using System.Collections.Generic;

namespace OfficeLogger
{
    [System.Serializable]
    public class UserAccount 
    {
        public string username;
        public string password;
        public string empId;
        public string emailId;
        public string gmailId;
        public string gmailPassword;
        public string displayPictureString;
        public int uniqueId;

        public UserAccount(string fullname, string empId, string emailId, string password)
        {
            this.username = fullname;
            this.empId = empId;
            this.empId = emailId;
        }

        public string DisplayPictureString
        {
            get{ return displayPictureString;}
            set{ displayPictureString = value;}
        }
        public void GmailAccount (string gmailId, string gmailPassword)
        {
            this.gmailId = gmailId;
            this.gmailPassword = gmailPassword;
        }
    }

    [System.Serializable]
    public class UserAccountWrapper
    {
        public List <UserAccount> userAccounts;
    }
}
