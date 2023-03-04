using UnityEngine;

namespace Game.Tutorial.UpgradeHero
{
    public sealed class QuestViewProjector : UI.QuestViewProjector
    {
        [SerializeField]
        private Config_UpgradeHero config;
    
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