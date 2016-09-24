using UnityEngine;
using System.Collections;

namespace OfficeLogger 
{
    public class UIWindowBase : MonoBehaviour 
    {
        protected virtual void OnWindowOpen ()
        {
            
        }
        protected virtual void OnWindowClose ()
        {
            
        }
    }

    public enum UIStates
    {
        LoadingScreen,
        MessagePopup,
        MainScreen,
        ResultScreen,
        InitScreen,
        NewProjectScreen
    }
}

