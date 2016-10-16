using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
namespace OfficeLogger
{
    public class AccountSelectionUI : UIWindowBase
    {
        public GameObject accountTemplateUi;
        public Transform rectParent;
        public Button addAccountBtn;

        private List <GameObject> accountsRectTracker;

        public override void OnAfterActivate()
        {
            base.OnAfterActivate();
            CheckForLocalAccounts();
        }

        public void SelectAccount (int accountId)
        {
            Debug.Log("Selected account " + accountId);
            List<string> he = new List<string>();
            he.Add("Project1");
            he.Add("IMF");
            he.Add("Cheta");
            he.Add("Tooin");
            UIController.GetPopup<ProjectSelectionPopup>().Show(he);
        }

        public void RemoveAccount (int accountId)
        {
            TestApp.GetInstance().userAccounts = TestApp.GetInstance().userAccounts.Where(val => val.uniqueId != accountId).ToList();
            CheckForLocalAccounts();
        }

        protected override void RegisterUIEvents()
        {
            base.RegisterUIEvents();
            addAccountBtn.onClick.AddListener(() =>
                {
                    AddNewAccount();
                });
        }
        protected override void UnRegisterUIEvents()
        {
            base.UnRegisterUIEvents();
            addAccountBtn.onClick.RemoveAllListeners();
        }

        private void AddNewAccount ()
        {
            UIController.ShowPopup<NewUserPopup>();
        }

        private void CheckForLocalAccounts ()
        {
            if (!TestApp.GetInstance().isNoLocalAccounts)
            {
                ClearList(accountsRectTracker);
                accountsRectTracker = new List<GameObject>();
                UserAccount[] allAccounts = TestApp.GetInstance().userAccounts.ToArray();

                foreach (var item in allAccounts)
                {
                    GameObject account = Instantiate(accountTemplateUi) as GameObject;
                    accountsRectTracker.Add(account);
                    account.transform.SetParent(rectParent);
                    account.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
                    account.GetComponent<AccountTemplateUI>().accountUniqueId = item.uniqueId;
                    account.GetComponent<AccountTemplateUI>().username.text = item.username;
                    //TODO Add rest items
                }
            }
            else
            {
                Debug.Log("Create New account");
            }
        }

        private void ClearList(List <GameObject> passedList)
        {
            if (passedList != null)
            {
                passedList.ForEach(t => Destroy(t.gameObject));
                passedList.Clear();
                passedList = null;
            }
        }
    }
}
