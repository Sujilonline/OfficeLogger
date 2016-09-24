using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace OfficeLogger 
{
    public class DatabaseController : MonoBehaviour
    {
        //Save and Load data

        public Project LoadProject (string _projectID)
        {
            Project sample = null;
            return sample;
        }
        public void SaveProject (Project project)
        {
            //Save project
        }
        public List<Project> LoadAllProjects ()
        {
            List<Project> allProjects = new List<Project>();
            return allProjects;
        }
        public void SaveProjects (List<Project> _projects)
        {
            //SaveProjects
        }
    }
}
