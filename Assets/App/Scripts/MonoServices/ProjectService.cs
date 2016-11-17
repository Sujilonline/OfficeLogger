using UnityEngine;
using System.Collections;

namespace OfficeLogger
{
    public class ProjectService : MonoService 
    {
        private string currentProjectID;
        private Project currentProject;

        protected override void Awake()
        {
            MonoServiceApplication.AddService(MonoInstanceConstants.PROJECTSERVICE, this);
        }
    }
}

