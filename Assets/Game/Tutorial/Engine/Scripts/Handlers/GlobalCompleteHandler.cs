using UnityEngine;

namespace Game.Tutorial
{
    public abstract class GlobalCompleteHandler : MonoBehaviour
    {
        private TutorialManager tutorialManager;

        protected abstract void OnSetup(bool isCompleted);

        protected abstract void OnComplete();

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

            this.tutorialManager.OnCompleted += this.OnComplete;
        }

        protected virtual void OnDisable()
        {
            this.tutorialManager.OnInitialized -= this.Initialize;
            this.tutorialManager.OnCompleted -= this.OnComplete;
        }

        private void Initialize()
        {
            this.OnSetup(this.tutorialManager.IsCompleted);
        }
    }
}