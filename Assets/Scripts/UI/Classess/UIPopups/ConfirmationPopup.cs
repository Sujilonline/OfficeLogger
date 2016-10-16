using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace OfficeLogger
{
    public class ConfirmationPopup : UIPopupBase
    {
        public Button OkBtn;
        public Button CancelBtn;
        public Text titleTxt;
        public Text messageTxt;
        public Color warningColor;
        public Color errorColor;
        public Color infoColor;

        public delegate void OkButtonCallback ();
        public delegate void CancelButtonCallback();

        public override void RegisterUIEvents()
        {
            base.RegisterUIEvents();
            OkBtn.onClick.AddListener(CloseUI);
            CancelBtn.onClick.AddListener(CloseUI);
        }
        public override void UnRegisterUIEvents()
        {
            base.UnRegisterUIEvents();
            OkBtn.onClick.RemoveAllListeners();
            CancelBtn.onClick.RemoveAllListeners();
        }

        public void Show (OkButtonCallback OnConfirm,
            CancelButtonCallback OnCancel,
            ConfirmationPopupData confirmationPopupData)
        {
            OkBtn.onClick.AddListener(()=>{OnConfirm();});
            CancelBtn.onClick.AddListener(()=>{OnCancel();});
            SetInfo(confirmationPopupData);
            UIController.ShowPopup<ConfirmationPopup>();
        }
        private void SetInfo (ConfirmationPopupData confirmationPopupData)
        {
            switch (confirmationPopupData.confirmationType)
            {
                case ConfirmationType.Error:
                    titleTxt.color = errorColor;
                    break;
                case ConfirmationType.Warning:
                    titleTxt.color = warningColor;
                    break;
                case ConfirmationType.Info:
                    titleTxt.color = infoColor;
                    break;
            }
            titleTxt.text = confirmationPopupData.title;
            messageTxt.text = confirmationPopupData.message;
        }

        private void RestUI ()
        {
            titleTxt.text = string.Empty;
            messageTxt.text = string.Empty;
        }

        private void CloseUI ()
        {
            UIController.HidePopup<ConfirmationPopup>();
        }
    }

}

