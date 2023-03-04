using GameSystem;
using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public abstract class CompleteHandler : MonoBehaviour,
        IGameConstructElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private TutorialManager tutorialManager;
        
        public void ConstructGame(IGameContext context)
        {
            this.tutorialManager = TutorialManager.Instance;
            this.InitGame(context, this.tutorialManager.IsCompleted);
        }

        protected virtual void InitGame(IGameContext context, bool isCompleted)
        {
        }

        public void ReadyGame()
        {
            this.tutorialManager.OnCompleted += this.OnComplete;
        }

        public void FinishGame()
        {
            this.tutorialManager.OnCompleted -= this.OnComplete;
        }
        
        protected virtual void OnComplete()
        {
        }
    }
}