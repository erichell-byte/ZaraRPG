using System.Collections;
using Game.Tutorial.Gameplay;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial.HarvestResource
{
    public sealed class StepHandler_HarvestResource : StepHandler
    {
        private PointerManager pointerManager; 
        
        [Space]
        [SerializeField]
        private QuestInspector questInspector;

        [SerializeField]
        private QuestViewProjector questProjector;

        [SerializeField]
        private AnalyticsHelper analytics;
        
        [Space]
        [SerializeField]
        private float showUIDelay = 1.0f;

        [SerializeField]
        private Transform pointerTransform;

        protected override void InitGame(IGameContext context, bool stepFinished)
        {
            this.pointerManager = context.GetService<PointerManager>();
        }

        protected override void OnStartStep()
        {
            this.analytics.LogStepStarted();
            this.questInspector.InspectQuest(this.FinishStepAndMoveNext);
            this.pointerManager.ShowPointer(this.pointerTransform.position, this.pointerTransform.rotation);
            this.StartCoroutine(this.ShowQuestRoutine());
        }

        protected override void OnFinishStep()
        {
            this.analytics.LogStepFinished();
            this.questProjector.HideQuest();
            this.pointerManager.HidePointer();
        }

        private IEnumerator ShowQuestRoutine()
        {
            yield return new WaitForSeconds(this.showUIDelay);
            this.questProjector.ShowQuest();
        }
    }
}