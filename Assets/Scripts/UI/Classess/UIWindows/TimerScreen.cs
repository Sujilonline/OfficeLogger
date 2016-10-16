using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
namespace OfficeLogger
 {
    public class TimerScreen : MonoBehaviour
    {
        public Text loggedInTimeTxt;
        public Text currentTimeTxt;
        public Text currentDateTxt;
        public Text spendTimeTxt;

        private DateTime loggedInTime;
        private bool startClock = false;

        public DateTime LoggedInTime
        {
            get { return loggedInTime;}
        }

        public void StartTimer (bool isStart)
        {
            startClock = isStart;
        }

        // Use this for initialization
        void Start () 
        {
            StartTimer(true);
            loggedInTime = DateTime.Now;
            loggedInTimeTxt.text = GetTimeInSpecified(18,loggedInTime);
        }
        
        // Update is called once per frame
        TimeSpan currentSpentTime;
        void Update () 
        {
            if (!startClock)
                return;
            UpdateCurrentTime();
            UpdateCurrentDate();
            currentSpentTime = GetTimeDifference(loggedInTime, DateTime.Now);
            spendTimeTxt.text = GetTimeInCommonFormat(currentSpentTime);
        }

        private string GetTimeInCommonFormat (DateTime passedTime)
        {
            int hour = passedTime.Hour;
            int minute = passedTime.Minute;
            int seconds = passedTime.Second;
            string hourstring = hour > 9 ? hour.ToString() : "0" + hour.ToString(); 
            string minuteString = minute > 9 ? minute.ToString() : "0" + minute.ToString();
            string secondsString = seconds > 9 ? seconds.ToString() : "0" + seconds.ToString();
            string time = hourstring +":" +minuteString+ ":" +secondsString;
            return time;
        }
        private string GetTimeInCommonFormat (TimeSpan passedTime)
        {
            int hour = passedTime.Hours;
            int minute = passedTime.Minutes;
            int seconds = passedTime.Seconds;
            string hourstring = hour > 9 ? hour.ToString() : "0" + hour.ToString(); 
            string minuteString = minute > 9 ? minute.ToString() : "0" + minute.ToString();
            string secondsString = seconds > 9 ? seconds.ToString() : "0" + seconds.ToString();
            string time = hourstring +":" +minuteString+ ":" +secondsString;
            return time;
        }
        private string GetTimeInSpecified (int formatIndex, DateTime dateTime)
        {
//            for (int i = 0; i < dateTime.GetDateTimeFormats().Length; i++)
//            {
//                Debug.Log("---" + i + " -- " +dateTime.GetDateTimeFormats()[i]);
//            }
            return dateTime.GetDateTimeFormats()[formatIndex];
        }

        private void UpdateCurrentTime ()
        {
            currentTimeTxt.text = GetTimeInSpecified (18, DateTime.Now); 
        }
        private void UpdateCurrentDate ()
        {
            currentDateTxt.text = GetTimeInSpecified (1, DateTime.Now); 
        }

        private TimeSpan GetTimeDifference (DateTime since,DateTime then)
        {
            return then.Subtract(since);
        }
    }
    
}