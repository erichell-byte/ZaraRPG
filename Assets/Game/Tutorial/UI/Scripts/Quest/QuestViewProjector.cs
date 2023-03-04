using GameSystem;
using UnityEngine;

namespace Game.Tutorial.UI
{
    public abstract class QuestViewProjector : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private QuestView viewPrefab;

        private RootTransformService transformService;

        private QuestView currentView;

        public void ShowQuest()
        {
            this.currentView = Instantiate(this.viewPrefab, this.transformService.RootTransform);
            this.currentView.SetTitle(this.ProvideTitle());
            this.currentView.SetIcon(this.ProvideIcon());
        }

        public void HideQuest()
        {
            Destroy(this.currentView.gameObject);
        }

        protected abstract string ProvideTitle();

        protected abstract Sprite ProvideIcon();

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.transformService = context.GetService<RootTransformService>();
        }
    }
}