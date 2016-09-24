using System;
using System.Collections.Generic;

namespace OfficeLogger
{
    public class Project 
    {
        public string projectID;
        public string projectName;
        public Reporter projectLeader;
        public Reporter reportingManager;
        public Reporter coordinator;
        public DateTime estimatedTime;
        public DateTime startDate;
        public DateTime finishedDate;
        public DateTime spendTime;

        public List <Module> modulesList;
        public int lastModuleID;
        public ItemStatus projectStatus;

        public Project (string _projectName, Reporter _projectLeader, Reporter _reportingManager, Reporter _coordinator, DateTime _startDate, DateTime _estimatedTime, int _lastModuleID)
        {
            this.projectName = _projectName;
            this.projectLeader = _projectLeader;
            this.reportingManager = _reportingManager;
            this.coordinator = _coordinator;
            this.startDate = _startDate;
            this.estimatedTime = _estimatedTime;
        }

        public void OnProjectStart ()
        {
            
        }
        public void OnProjectHold ()
        {
            
        }
        public void OnProjectResume ()
        {
            
        }
        public void OnProjectPause ()
        {
            
        }
        public void OnProjectFinish ()
        {
            
        }
        public void AddModule (Module _newModule)
        {
            EnsureModuleListNotNull();
            _newModule.moduleID = CustomUtil.GetUniqueID(projectName, lastModuleID);
            lastModuleID++;
            modulesList.Add(_newModule);
        }
        public void AddModules (List<Module> _newModules)
        {
            EnsureModuleListNotNull();
            for (int i = 0; i < _newModules.Count; i++)
            {
                _newModules[i].moduleID = CustomUtil.GetUniqueID(projectName, lastModuleID);
                lastModuleID++;
                modulesList.Add(_newModules[i]);
            }
        }
        public void SetModuleStatus (string _moduleID, ItemStatus _moduleStatus)
        {
            if (!IsModuleListEmpty(modulesList))
            {
                for (int i = 0; i < modulesList.Count; i++)
                {
                    if (modulesList[i].moduleID == _moduleID)
                    {
                        modulesList[i].status = _moduleStatus;
                    }
                }
            }
            
        }

        public void RemoveModule (string _moduleID)
        {
            if (!IsModuleListEmpty(modulesList))
            {
                modulesList.RemoveAll(t => t.moduleID == _moduleID);
            }
            
        }

        private void EnsureModuleListNotNull ()
        {
            if (modulesList == null)
            {
                modulesList = new List<Module>();
            }
        }
        private bool IsModuleListEmpty (List <Module> _moduleList)
        {
            bool isEmpty = false;

            if (_moduleList == null || _moduleList.Count <= 0)
            {
                isEmpty = true;
            }
            return isEmpty;
        }
    }

    public enum ItemStatus
    {
        None,
        Started,
        OnPause,
        OnHold,
        OnGoing,
        Finished,
        Removed
    }
    public class Reporter
    {
        public string name{ get; set;}
        public string mailId { get; set;}
    }
    //Return the project status
    //Return the project completion status
}

