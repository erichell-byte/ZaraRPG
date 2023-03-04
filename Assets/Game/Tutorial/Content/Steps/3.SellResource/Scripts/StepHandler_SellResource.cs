using System.Collections;
using Game.App;
using Game.Tutorial.Gameplay;
using GameSystem;
using Game.Tutorial.SellResource;
using UnityEngine;

namespace Game.Tutorial.SellResource
{
    public sealed class StepHandler_SellResource : StepHandler
    {
        private PointerManager pointerManager;

        private NavigationManager navigationManager;
    
        [Space]
        [SerializeField]
        private QuestInspector questInspector;

        [SerializeField]
        private QuestViewProjector viewProjector;

        [Space]
        [SerializeField]
        private float showUIDelay = 1.0f;

        [SerializeField]
        private Transform pointerTransform;

        protected override void InitGame(IGameContext context, bool stepFinished)
        {
            this.pointerManager = context.GetService<PointerManager>();
            this.navigationManager = context.GetService<NavigationManager>();
        }

        protected override void OnStartStep()
        {
            AnalyticsManager.LogEvent("tutorial_step_3__cell_resource_started");
            this.questInspector.InspectQuest(this.FinishStepAndMoveNext);
            
            var targetPosition = this.pointerTransform.position;
            this.pointerManager.ShowPointer(targetPosition, this.pointerTransform.rotation);
            this.navigationManager.StartLookAt(targetPosition);
            this.StartCoroutine(this.ShowQuestRoutine());
        }

        protected override void OnFinishStep()
        {
            AnalyticsManager.LogEvent("tutorial_step_3__cell_resource_completed");
            this.navigationManager.Stop();
            this.pointerManager.HidePointer();
            this.viewProjector.HideQuest();
        }

        private IEnumerator ShowQuestRoutine()
        {
            yield return new WaitForSeconds(this.showUIDelay);
            this.viewProjector.ShowQuest();
        }
    }
}