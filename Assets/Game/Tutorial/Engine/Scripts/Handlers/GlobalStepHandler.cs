using UnityEngine;

namespace Game.Tutorial
{
    public abstract class GlobalStepHandler : MonoBehaviour
    {
        [SerializeField]
        private TutorialStep step;

        private TutorialManager tutorialManager;
        
        protected abstract void OnSetupStep(bool stepFinished);

        protected abstract void OnStartStep();

        protected abstract void OnFinishStep();

        protected virtual void Awake()
        {
            this.tutorialManager = TutorialManager.Instance;
        }

        protected virtual void OnEnable()
        {
            if (this.tutorialManager.IsInitialized)
            {
                this.Initialize();
            }
            else
            {
                this.tutorialManager.OnInitialized += this.Initialize;
            }

            this.tutorialManager.OnStepFinished += this.CheckForFinish;
            this.tutorialManager.OnNextStep += this.CheckForStart;
        }

        protected virtual void OnDisable()
        {
            this.tutorialManager.OnInitialized -= this.Initialize;
            this.tutorialManager.OnStepFinished -= this.CheckForFinish;
            this.tutorialManager.OnNextStep -= this.CheckForStart;
        }
        
        
        private void Initialize()
        {
            var isMyStepFinished = this.tutorialManager.IsStepPassed(this.step);
            this.OnSetupStep(isMyStepFinished);

            if (!isMyStepFinished)
            {
                this.CheckForStart(this.tutorialManager.CurrentStep);
            }
        }

        private void CheckForFinish(TutorialStep step)
        {
            if (this.step == step)
            {
                this.OnFinishStep();
            }
        }

        private void CheckForStart(TutorialStep step)
        {
            if (this.step == step)
            {
                this.OnStartStep();
            }
        }
    }
}