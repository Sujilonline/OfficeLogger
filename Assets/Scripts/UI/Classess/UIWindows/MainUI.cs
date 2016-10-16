using UnityEngine;
using System.Collections;
namespace OfficeLogger
{
    public class MainUI : UIWindowBase
    {
        public void Show (int uniqueId)
        {
            Debug.Log("Started with " + uniqueId);
            UIController.ShowWindow<MainUI>();
        }
    }
}
