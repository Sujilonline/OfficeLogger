using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


namespace OfficeLogger
{
    public class ProjectSelectionPopup : UIPopupBase
    {  
        public Dropdown projectDropDown;
        public Button selectBtn;
        public Button closeBtn;
        public Button addProjectBtn;

        public override void RegisterUIEvents()
        {
            base.RegisterUIEvents();
            selectBtn.onClick.AddListener(() =>
                {
                    SelectProject();
                });
            closeBtn.onClick.AddListener(() =>
                {
                    CloseWindow();
                });
        }
        public override void UnRegisterUIEvents()
        {
            base.UnRegisterUIEvents();
            selectBtn.onClick.RemoveAllListeners();
            closeBtn.onClick.RemoveAllListeners();
        }
        public void Show (List<string> projectList)
        {
            projectDropDown.AddOptions(projectList);
            UIController.ShowPopup<ProjectSelectionPopup>();
        }
        private void SelectProject ()
        {
            ResetUI();
            UIController.HidePopup<ProjectSelectionPopup>();
            UIController.HideWindow<AccountSelectionUI>();
            UIController.ShowWindow<MainUI>();
        }
        private void CloseWindow ()
        {
            ResetUI();
            UIController.HidePopup<ProjectSelectionPopup>();
        }
        private void ResetUI ()
        {
            projectDropDown.ClearOptions();
        }
    }
}
