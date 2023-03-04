using Game.App;
using UnityEngine;

namespace Game.Tutorial.HarvestResource
{
    public sealed class AnalyticsHelper : MonoBehaviour
    {
        //TODO: добавить трекер времени
        //TODO: добавить номер сессии

        public void LogStepStarted()
        {
            const string eventName = "tutorial_step_2__harvest_resource_started";
            if (PlayerPreferences.KeyExists(eventName))
            {
                return;
            }

            AnalyticsManager.LogEvent(eventName);
            PlayerPreferences.Save(eventName, 1);
        }

        public void LogStepFinished()
        {
            const string eventName = "tutorial_step_2__harvest_resource_completed";
            if (PlayerPreferences.KeyExists(eventName))
            {
                return;
            }
            
            AnalyticsManager.LogEvent(eventName);
            PlayerPreferences.Save(eventName, 1);
        }
    }
}