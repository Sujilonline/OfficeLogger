using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace OfficeLogger
{
    public class MonoServiceApplication : MonoBehaviour
    {
        private static Dictionary<string, MonoService> monoSingleClasses = new Dictionary<string, MonoService>();
       
        public static void AddService<T>(string pInstanceName, T pPassedClass) where T: MonoService
        {
            if (monoSingleClasses.ContainsKey(pInstanceName))
            {
                Debug.LogError("Contains instance with same name");
            }
            else
            {
                monoSingleClasses[pInstanceName] = pPassedClass;
            }
        }
        public static MonoService GetService(string pInstanceName)
        {
            if (monoSingleClasses.ContainsKey(pInstanceName))
                return monoSingleClasses[pInstanceName] as MonoService;
            else
            {
                Debug.LogError(pInstanceName +" not yet added");
                return null;
            }
        }
    }
}

