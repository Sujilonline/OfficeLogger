using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace OfficeLogger
{
    public class ProjectDetailsScreen :  MonoBehaviour
    {
        public Text projectName;
        public Text projectLeaderName;
        public Text totalModules;
        public Text completedModules;
        public Text startDate;
        public Text spendTime;
        public Slider finishedPercentage;
        public Text completedPercentage;
        public Color red;
        public Color orange;
        public Color yellow;
        public Color green;
        public Image sliderBG;

        public void RefreshProjectDetails 
        (
            string _projectName,
            string _projectLeaderName,
            int _totalModules,
            int _completedModules,
            string _startDate,
            string _spendTime
        )
        {
            projectName.text = _projectName;
            projectLeaderName.text = _projectLeaderName;
            totalModules.text = _totalModules.ToString();
            completedModules.text = _completedModules.ToString();
            startDate.text = _startDate;
            spendTime.text = _spendTime;
            finishedPercentage.value = FinishedPercentage (_totalModules, _completedModules);
            completedPercentage.text = (FinishedPercentage (_totalModules, _completedModules) * 100).ToString() + " %";
            ChangeSliderColor((FinishedPercentage(_totalModules, _completedModules) * 100));
        }
        private void ChangeSliderColor (float _finishedPercentage)
        {
            Color sliderColor = red;
            if (_finishedPercentage < 20.0f)
            {
                sliderColor = red;
            }
            else if (_finishedPercentage < 40.0f)
            {
                sliderColor = orange;

            }
            else if (_finishedPercentage < 60.0f)
            {
                sliderColor = yellow;

            }
            else if (_finishedPercentage > 80.0f)
            {
                sliderColor = green;

            }
            sliderBG.color = sliderColor;
        }
        private float FinishedPercentage (int totalModules, int finishedModules)
        {
            float result = (float)finishedModules / (float)totalModules;
            return result;
        }
    }
}