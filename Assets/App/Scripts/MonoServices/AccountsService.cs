using UnityEngine;
using System.Collections;
namespace OfficeLogger
{
    /// <summary>
    /// Accounts service.
    /// This class must perform the operations on the account
    /// </summary>
    public class AccountsService : MonoService
    {
        private DatabaseService databaseService;
        protected override void Awake()
        {
            MonoServiceApplication.AddService(MonoInstanceConstants.ACCOUNTSSERVICE, this);
        }
        protected override void Start ()
        {
            databaseService = MonoServiceApplication.GetService(MonoInstanceConstants.DATABASESERVICE) as DatabaseService;
        }
    }
}

