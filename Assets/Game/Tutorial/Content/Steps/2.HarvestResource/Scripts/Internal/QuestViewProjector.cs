using UnityEngine;

namespace Game.Tutorial.HarvestResource
{
    public sealed class QuestViewProjector : UI.QuestViewProjector
    {
        [SerializeField]
        private Config_HarvestResource config;

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