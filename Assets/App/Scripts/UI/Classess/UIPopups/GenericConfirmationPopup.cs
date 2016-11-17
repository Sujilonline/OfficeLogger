using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


namespace OfficeLogger
{
    public class GenericConfirmationPopup : UIPopupBase
    {
        public Action OnCloseButtonPress;
        public Action OnCancelButtonPress;
        public Action OnConfirmButtonPress;

        public Button CloseButton;
        public Button CancelButton;
        public Button ConfirmButton;

       
        public override void RegisterUIEvents()
        {
            base.RegisterUIEvents();
            ConfirmButton.onClick.AddListener(ConfirmButtonPressed);
            CloseButton.onClick.AddListener(CloseButtonPressed);
            CancelButton.onClick.AddListener(CancelButtonPressed);
        }
        public override void UnRegisterUIEvents()
        {
            base.UnRegisterUIEvents();
            ConfirmButton.onClick.RemoveAllListeners();
            CloseButton.onClick.RemoveAllListeners();
            CancelButton.onClick.RemoveAllListeners();
        }
        private void CloseButtonPressed ()
        {
            if (OnCloseButtonPress != null)
            {
                OnCloseButtonPress.Invoke();
            }
            ClosePopup();

        }
        private void ConfirmButtonPressed ()
        {
            if (OnConfirmButtonPress != null)
            {
                OnConfirmButtonPress.Invoke();
            }
            ClosePopup();

        }
        private void CancelButtonPressed ()
        {
            if (OnCancelButtonPress != null)
            {
                OnCancelButtonPress.Invoke();
            }
            ClosePopup();
        }
        private void ClosePopup ()
        {
            UIController.HidePopup<GenericConfirmationPopup>();
        }
    }
}
