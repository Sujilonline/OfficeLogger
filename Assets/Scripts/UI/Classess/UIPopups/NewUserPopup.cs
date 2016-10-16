using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace OfficeLogger
{
    public class NewUserPopup : UIPopupBase
    {
        public Button createNewBtn;
        public Button loadAccountBtn;
        public Button closeBtn;

        public override void RegisterUIEvents()
        {
            createNewBtn.onClick.AddListener(() =>
                {
                    CreateNewAccount();
                });
            loadAccountBtn.onClick.AddListener(() =>
                {
                    LoadAccount();
                });
            closeBtn.onClick.AddListener(() =>
                {
                    ClosePopup();
                });
        }

        public override void UnRegisterUIEvents()
        {
            createNewBtn.onClick.RemoveAllListeners();
            loadAccountBtn.onClick.RemoveAllListeners();
            closeBtn.onClick.RemoveAllListeners();
        }
    
        private void ClosePopup ()
        {
            UIController.HidePopup<NewUserPopup>();
        }
        private void LoadAccount ()
        {
            Debug.Log("Load account");
        }

        private void CreateNewAccount ()
        {
            Debug.Log("Create new account");
            UIController.HidePopup<NewUserPopup>();
            UIController.HideWindow<AccountSelectionUI>();
            UIController.ShowWindow<AccountCreationUI>();
        }
    }
}