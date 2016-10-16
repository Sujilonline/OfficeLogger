﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace OfficeLogger
{
    public class AccountCreationUI : UIWindowBase
    {
        public InputField fullNameIF;
        public InputField empIdIF;
        public InputField emailDIdIF;
        public InputField passwordIF;
        public InputField confirmPasswordIF;

        public Button createAccountBtn;
        public Button backBtn;

        protected override void RegisterUIEvents()
        {
            base.RegisterUIEvents();
            createAccountBtn.onClick.AddListener(() =>
                {
                    CreateAccount();
                });
            backBtn.onClick.AddListener(() =>
                {
                    MoveBackToPreUI();
                });
        }
        protected override void UnRegisterUIEvents()
        {
            base.UnRegisterUIEvents();
            createAccountBtn.onClick.RemoveAllListeners();
            backBtn.onClick.RemoveAllListeners();
        }
        private void CreateAccount ()
        {
            
        }

        private void MoveBackToPreUI ()
        {
            UIController.HideWindow<AccountCreationUI>();
            UIController.ShowWindow<AccountSelectionUI>();
            ResetUI();
        }
        private void ResetUI ()
        {
            Debug.Log("Add code for resetting the UI");
            fullNameIF.text = string.Empty;
            empIdIF.text = string.Empty;
            emailDIdIF.text = string.Empty;
            passwordIF.text = string.Empty;
            confirmPasswordIF.text = string.Empty;
        }
    }
}
