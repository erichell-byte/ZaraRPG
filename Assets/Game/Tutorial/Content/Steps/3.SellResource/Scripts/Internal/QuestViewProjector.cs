using UnityEngine;

namespace Game.Tutorial.SellResource
{
    public sealed class QuestViewProjector : UI.QuestViewProjector
    {
        [SerializeField]
        private Config_SellResource config;
    
        protected override string ProvideTitle()
        {
            return this.config.title;
        }

        protected override Sprite ProvideIcon()
        {
            return this.config.icon;
        }
    }
}