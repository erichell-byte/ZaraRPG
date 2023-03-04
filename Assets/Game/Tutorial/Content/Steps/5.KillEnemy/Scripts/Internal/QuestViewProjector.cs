using UnityEngine;

namespace Game.Tutorial.KillEnemy
{
    public sealed class QuestViewProjector : UI.QuestViewProjector
    {
        [SerializeField]
        private Config_KillEneny config;
    
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