using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OfficeLogger.UIFrameWork 
{
    public class UIWindowBase : MonoBehaviour, IWindow
    {
        protected Dictionary<string, object> passedParameters;

        public void AddParameters(params KeyValuePair<string, object>[] passedParam)
        {
            passedParameters = new Dictionary<string, object>();
            foreach (var param in passedParam)
            {
                passedParameters.Add(param.Key, param.Value);
            }
        }

        protected void RegisterUIEvents ()
        {
            
        }
        protected void UnRegisterUIEvents ()
        {
            
        }
        #region IWindow implementation
        public void Activate()
        {
            this.gameObject.SetActive(true);
            RegisterUIEvents();
            OnAfterActivate();
        }
        public void OnAfterActivate()
        {
        }
        
        public void Deactivate()
        {
            this.gameObject.SetActive(false);
            UnRegisterUIEvents();
            OnBeforeDeactivate();
        }
        
        public void OnBeforeDeactivate()
        {
            
        }
        #endregion
    }
}

