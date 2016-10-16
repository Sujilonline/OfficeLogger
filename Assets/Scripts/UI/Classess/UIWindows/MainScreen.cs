using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using OfficeLogger;


namespace OfficeLogger
{
    public class MainScreen : MonoBehaviour
    {
        public ProjectDetailsScreen projectDetailsScreen;
        public TimerScreen timerScreen;
        public Dropdown projectList;

        private List<T_Projects> t_projects;
        private List<T_Projects> t_selectedProjects;

        private int t_index = 0;

        void Awake ()
        {
            AddTestProjects();
            projectList.ClearOptions();
            Debug.Log("projectList.value " +projectList.value );
        }

        public void OnProjectChange ()
        {
            T_Projects t_p = new T_Projects();
            t_p = t_selectedProjects[projectList.value];
            projectDetailsScreen.RefreshProjectDetails(t_p.projectName,
                t_p.tlName,
                t_p.numberOfmodules,
                t_p.finishedModules,
                t_p.startDate,
                t_p.spendTime);
        }
        public void OnAdditionProject ()
        {
            if (t_selectedProjects == null)
            {
                t_selectedProjects = new List<T_Projects>();
            }
            t_selectedProjects.Add(t_projects[t_index]);
            t_index++;
            projectList.ClearOptions();
            List<string> options = new List<string>();
            foreach (var ss in t_selectedProjects)
            {
                options.Add(ss.projectName);
            }
            projectList.AddOptions(options);
            OnProjectChange();
        }

        private void AddTestProjects ()
        {
            t_projects = new List<T_Projects>();

            T_Projects t1 = new T_Projects();
            t1.projectName = "Project1";
            t1.tlName = "teamLeader1";
            t1.startDate = "12-Sep-2016";
            t1.numberOfmodules = 10;
            t1.finishedModules = 2;
            t1.spendTime = "15hrs";

            T_Projects t2 = new T_Projects();
            t2.projectName = "Project2";
            t2.tlName = "teamLeader2";
            t2.startDate = "22-Sep-2016";
            t2.numberOfmodules = 10;
            t2.finishedModules = 5;
            t2.spendTime = "55hrs";

            T_Projects t3 = new T_Projects();
            t3.projectName = "Project3";
            t3.tlName = "teamLeader3";
            t3.startDate = "22-Aug-2016";
            t3.numberOfmodules = 25;
            t3.finishedModules = 5;
            t3.spendTime = "155hrs";

            T_Projects t4 = new T_Projects();
            t4.projectName = "Project4";
            t4.tlName = "teamLeader4";
            t4.startDate = "02-Aug-2016";
            t4.numberOfmodules = 5;
            t4.finishedModules = 5;
            t4.spendTime = "5hrs";

            T_Projects t5 = new T_Projects();
            t5.projectName = "Project5";
            t5.tlName = "teamLeader5";
            t5.startDate = "02-Dec-2016";
            t5.numberOfmodules = 20;
            t5.finishedModules = 18;
            t5.spendTime = "667hrs";

            t_projects.Add(t1);
            t_projects.Add(t2);
            t_projects.Add(t3);
            t_projects.Add(t4);
            t_projects.Add(t5);
        }

    }
    public class T_Projects
    {
        public string projectName;
        public string tlName;
        public string startDate;
        public int numberOfmodules;
        public int finishedModules;
        public string spendTime;
    }
}
