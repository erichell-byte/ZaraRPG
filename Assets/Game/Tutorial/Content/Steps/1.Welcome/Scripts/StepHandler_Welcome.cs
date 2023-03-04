using System.Collections;
using Game.App;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UIFrames.Unity;
using UnityEngine;

namespace Game.Tutorial.Welcome
{
    public sealed class StepHandler_Welcome : StepHandler
    {
        [SerializeField]
        private UnityFrame popupPrefab;
        
        [SerializeField]
        private Config_Welcome config;

        [SerializeField]
        private float showPopupDelay = 0.5f;

        private PopupManager popupManager;

        protected override void InitGame(IGameContext context, bool stepFinished)
        {
            this.popupManager = context.GetService<PopupManager>();
        }

        protected override void OnStartStep()
        {
            AnalyticsManager.LogEvent("tutorial_step_1__welcome_started");
            this.StartCoroutine(this.ShowPopupRoutine());
        }

        private IEnumerator ShowPopupRoutine()
        {
            yield return new WaitForSeconds(this.showPopupDelay);
            var args = new PopupArgs(this.config.title, this.config.description);
            this.popupManager.Show(this.popupPrefab, args, callback: this.OnPopupClicked);
        }

        private void OnPopupClicked()
        {
            AnalyticsManager.LogEvent("tutorial_step_1__welcome_completed");
            this.FinishStepAndMoveNext();
        }
    }
}