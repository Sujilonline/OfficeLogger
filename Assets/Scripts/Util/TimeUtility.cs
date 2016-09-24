using UnityEngine;
using System.Collections;
namespace OfficeLogger
{
    public class TimeUtility : MonoBehaviour 
    {
        private static TimeUtility instance;
        void  Awake ()
        {
            instance = this;
        }

        public static TimeUtility GetInstance ()
        {
            return instance;
        }
        void Update () {

        }
    }   
}

