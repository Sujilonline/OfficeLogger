using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace OfficeLogger
{
    public class DatabaseService : MonoService
    {
        private LocalStorageService localStorageService;
        protected override void Awake()
        {
            MonoServiceApplication.AddService(MonoInstanceConstants.DATABASESERVICE, this);
        }
        protected override void Start()
        {
            base.Start();
            localStorageService = MonoServiceApplication.GetService(MonoInstanceConstants.LOCALSTORAGESERVICE) as LocalStorageService;
        }
        private const string ACCOUNTS_LIST = "accountsList.txt";
        private const string PROJECT_LIST = "projectList.txt";


        public void CreateAccount (UserAccount newAccount)
        {
            
        }
        public List<UserAccount> GetUserAccounts ()
        {
            //TODO return the proper user account list
            return new List<UserAccount>();
        }

        public UserAccount GetAccount (string pUniqueId)
        {
            if (IsLocalAccountExists())
            {
                
            }
            else
            {
                Debug.LogError("No Local Accounts found!!");
            }
            return new UserAccount(string.Empty,string.Empty,string.Empty,string.Empty);
        }

        public bool IsLocalAccountExists ()
        {
            if (localStorageService.GlobalDataExists(ACCOUNTS_LIST))
                return true;
            return false;
        }
    }
}

