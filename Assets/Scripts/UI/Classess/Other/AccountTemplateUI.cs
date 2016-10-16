using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace OfficeLogger
{
    public class AccountTemplateUI : MonoBehaviour
    {
        public Text username;
        public Image userDisplayPicture;
        public Button selectButton;
        public int accountUniqueId;
        public void OnSelect ()
        {
            Debug.Log(accountUniqueId);
            UIController.GetWindow<AccountSelectionUI>().SelectAccount(accountUniqueId);

        }
        public void OnRemoveButtonClick ()
        {
            Debug.Log("Remove this account");
            UIController.GetPopup<ConfirmationPopup>().Show(RemoveAccount, DenyRemoving,
                new ConfirmationPopupData(ConfirmationType.Warning, "Warning!!", "You sure you want to remove \n <color=green>"+ username.text.ToString()+ "</color> \n permanently??"));
                
        }
        public void RemoveAccount ()
        {
            UIController.GetWindow<AccountSelectionUI>().RemoveAccount(accountUniqueId);
        }
        public void DenyRemoving ()
        {
            Debug.Log("Deny Removing");
        }
                
    }
}

