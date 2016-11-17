using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace OfficeLogger
{
    public abstract class UIPopupBase : MonoBehaviour, IWindow
    {
       
        #region IWindow implementation
        public virtual void Activate()
        {
            gameObject.SetActive(true);
            OnAfterActivate();
            RegisterUIEvents();
        }
        public virtual void OnAfterActivate()
        {
        }
        public virtual void Deactivate()
        {
            UnRegisterUIEvents();
            OnBeforeDeactivate();
            gameObject.SetActive(false);
        }
        public virtual void OnBeforeDeactivate()
        {
            
        }
        public virtual void RegisterUIEvents ()
        {
            
        }
        public virtual void UnRegisterUIEvents ()
        {

        }
        #endregion
    }
}


