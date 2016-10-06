using UnityEngine;
using System.Collections;
namespace OfficeLogger.UIFrameWork
{
    public abstract class UIPopupBase : MonoBehaviour, IWindow
    {
       
        #region IWindow implementation
        public virtual void Activate()
        {
            gameObject.SetActive(true);
            OnAfterActivate();
        }
        public virtual void OnAfterActivate()
        {
        }
        public virtual void Deactivate()
        {
            OnBeforeDeactivate();
            gameObject.SetActive(false);
        }
        public virtual void OnBeforeDeactivate()
        {
            
        }
        #endregion
    }
}


