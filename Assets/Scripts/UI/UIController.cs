using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OfficeLogger
{
    public class UIController : MonoBehaviour
    {
        public UIWindowBase[] uiWindowsArray;
        public UIPopupBase[] uiPopupsArray;

        private void Awake ()
        {
            UIController.AddWindowRange(uiWindowsArray);
            UIController.AddPopupRange(uiPopupsArray);
            uiWindowsArray.ForEach(t=>t.gameObject.SetActive(false));
            uiPopupsArray.ForEach(t => t.gameObject.SetActive(false));
        }
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
        public static void RemoveWindow <T> () where T : UIWindowBase
        {
            uiWindows.Remove(typeof(T).Name);
        }
        public static void AddWindowRange <T> (IEnumerable <T> newWindows) where T : UIWindowBase
        {
            foreach (var window in newWindows)
            {
                uiWindows[window.GetType().Name] = window;
            }
        }
        public static void ShowWindow<T>() where T : UIWindowBase
        {
            T getWindow = GetWindow<T>();
            getWindow.Activate();
        }
        public static void HideWindow<T>() where T : UIWindowBase
        {
            T getWindow = GetWindow<T>();
            getWindow.Deactivate();
        }
        #endregion

        #region UIPopups
        public static T GetPopup <T>() where T : UIPopupBase
        {
            return uiPopups[typeof(T).Name] as T;
        }
        public static void AddPopup <T>(T popup) where T: UIPopupBase
        {
            //            uiWindows.Add(window.GetType().Name, window);
            uiPopups[typeof(T).Name] = popup;
        }
        public static void RemovePopup <T> () where T : UIPopupBase
        {
            uiPopups.Remove(typeof(T).Name);
        }
        public static void AddPopupRange <T> (IEnumerable <T> newPopups) where T : UIPopupBase
        {
            foreach (var popup in newPopups)
            {
                uiPopups[popup.GetType().Name] = popup;
            }
        }
        public static void ShowPopup<T>() where T : UIPopupBase
        {
            T getPopup = GetPopup<T>();
            getPopup.Activate();
        }
        public static void HidePopup<T>() where T : UIPopupBase
        {
            T getPopup = GetPopup<T>();
            getPopup.Deactivate();
        }
        #endregion
    }
}

