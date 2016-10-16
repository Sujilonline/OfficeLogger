using UnityEngine;
using System.Collections;
namespace OfficeLogger
{
    public class AppController : MonoBehaviour 
    {
        public DatabaseController databaseController;
        private void Start ()
        {
            StartApplication();
        }

        public void StartApplication ()
        {
            UIController.ShowWindow<AccountSelectionUI>();
        }
    }
}
