using System;
using Game.Meta;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial.UpgradeHero
{
    public sealed class QuestInspector : Gameplay.QuestInspector, IGameConstructElement
    {
        private UpgradesManager upgradesManager;

        [SerializeField]
        private Config_UpgradeHero config;

        private Upgrade targetUpgrade;
        
        private Action callback;
        
        public override void InspectQuest(Action callback)
        {
            this.callback = callback;
            this.targetUpgrade = this.upgradesManager.GetUpgrade(this.config.upgradeConfig.id);
            this.targetUpgrade.OnLevelUp += this.OnLevelUp;
        }

        private void OnLevelUp(int nextLevel)
        {
            if (nextLevel < this.config.targetLevel)
            {
                return;
            }
            
            this.targetUpgrade.OnLevelUp -= this.OnLevelUp;
            this.targetUpgrade = null;
            this.callback?.Invoke();
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.upgradesManager = context.GetService<UpgradesManager>();
        }
    }
}