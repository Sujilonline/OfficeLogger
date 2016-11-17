using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeLogger
{
    public class Module 
    {
        public string moduleID;
        public string moduleName;
        public DateTime startDate;
        public DateTime allottedTime;

        public DateTime finishedDate { get; set;}
        public DateTime spendTime { get; set;}
        public ItemStatus status { get; set;}
        public List <Task> tasksList;

        private int lastTaskID;

        public Module (string _moduleName, DateTime _startDate, DateTime _allotedTime, int _lastTaskID)
        {
            this.moduleName = _moduleName;
            this.startDate = _startDate;
            this.allottedTime = _allotedTime;
            this.lastTaskID = _lastTaskID;
        }

        public void OnModuleFinish ()
        {
            status = ItemStatus.Finished;
        }
        public void OnModuleRemove ()
        {
            status = ItemStatus.Removed;
        }

        public void OnModulePause ()
        {
            status = ItemStatus.OnPause;
        }

        public void OnModuleResume ()
        {
            status = ItemStatus.OnGoing;
        }

        public void AddTask (Task _newTask)
        {
            EnsureTaskListNotNull();
            _newTask.taskID =  CustomUtil.GetUniqueID(moduleID, lastTaskID);
            lastTaskID++;
            tasksList.Add(_newTask);
        }
        public void AddTasks (List<Task> _newTasks)
        {
            EnsureTaskListNotNull();
            for (int i = 0; i < _newTasks.Count; i++)
            {
                _newTasks[i].taskID = CustomUtil.GetUniqueID(moduleID, lastTaskID);
                lastTaskID++;
                tasksList.Add(_newTasks[i]);
            }
        }
        public void SetTaskStatus (string _taskID, ItemStatus _taskStatus)
        {
            if (!IsTaksListEmpty (tasksList))
            {
                for (int i = 0; i < tasksList.Count; i++)
                {
                    if (tasksList[i].taskID == _taskID)
                    {
                        tasksList[i].status = _taskStatus;
                    }
                }
            }
        }
        public void RemoveTask (string _taskID)
        {
            if (!IsTaksListEmpty (tasksList))
            {
                tasksList.RemoveAll(t => t.taskID == _taskID);
            }
        }

        private void EnsureTaskListNotNull ()
        {
            if (tasksList == null)
            {
                tasksList = new List<Task>();
            }
        }
        public bool IsTaksListEmpty (List <Task> _taskList)
        {
            bool isEmpty = false;

            if (_taskList == null || _taskList.Count <= 0)
            {
                isEmpty = true;
            }
            return isEmpty;
        }
    }
}