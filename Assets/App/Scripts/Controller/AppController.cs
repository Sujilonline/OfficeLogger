using UnityEngine;
using System.Collections;
namespace OfficeLogger
{
    public class AppController : MonoBehaviour 
    {
        private void Start ()
        {
            StartApplication();
        }

        public void StartApplication ()
        {
            UIController.ShowWindow<AccountSelectionUI>();
//            UIController.ShowPopup<GenericConfirmationPopup>();
        }
    }
}
