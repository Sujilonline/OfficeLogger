using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace OfficeLogger.UIFrameWork
{
    public class UIFlowController 
    {
        //Dictionaries for storing UI windows and Popups
        public static Dictionary <string, UIWindowBase> uiWindows = new Dictionary<string, UIWindowBase>();
        public static Dictionary <string, UIPopupBase> uiPopups = new Dictionary<string, UIPopupBase>();

        #region UIWindows
        public static T GetWindow <T>() where T : UIWindowBase
        {
            return uiWindows[typeof(T).Name] as T;
        }
        public static void AddWindow <T>(T window) where T: UIWindowBase
        {
//            uiWindows.Add(window.GetType().Name, window);
            uiWindows[typeof(T).Name] = window;
        }
        public static void RemoveWindow <T> (T window) where T : UIWindowBase
        {
            uiWindows.Remove(typeof(T).Name);
        }
        public void AddWindowRange <T> (IEnumerable <T> newWindows) where T : UIWindowBase
        {
            foreach (var window in newWindows)
            {
                uiWindows[window.GetType().Name] = window;
            }
        }
        public void ShowWindow<T>() where T : UIWindowBase
        {
            T getWindow = GetWindow<T>();
            getWindow.Activate();
        }
        public void HideWindow<T>() where T : UIWindowBase
        {
            T getWindow = GetWindow<T>();
            getWindow.Deactivate();
        }
        #endregion
    }
}

