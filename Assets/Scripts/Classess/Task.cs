using System;
using OfficeLogger;
namespace OfficeLogger
{
    public class Task
    {
        public string taskID;
        public string taskName
        { 
            get;
            set;
        }
        public ItemStatus status 
        {
            get;
            set;
        }
    }
}
