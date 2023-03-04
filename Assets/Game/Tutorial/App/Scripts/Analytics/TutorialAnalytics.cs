using Game.App;

namespace Game.Tutorial.App
{
    public static class TutorialAnalytics
    {
        public static void LogTutorialStarted()
        {
            const string eventName = "tutorial_started";
            const string key = "analytics/" + eventName;

            if (PlayerPreferences.KeyExists(key))
            {
                return;
            }

            AnalyticsManager.LogEvent(eventName);
            PlayerPreferences.Save(key, 1);
        }

        public static void LogTutorialCompleted()
        {
            const string eventName = "tutorial_completed";
            const string key = "analytics/" + eventName;

            if (PlayerPreferences.KeyExists(key))
            {
                return;
            }

            AnalyticsManager.LogEvent(eventName);
            PlayerPreferences.Save(key, 1);
        }
    }
}