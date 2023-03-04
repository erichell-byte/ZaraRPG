using System;
using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial.HarvestResource
{
    public sealed class QuestInspector : Gameplay.QuestInspector, IGameConstructElement
    {
        [SerializeField]
        private Config_HarvestResource config;

        private IEntity hero;

        private Action callback;

        public override void InspectQuest(Action callback)
        {
            this.callback = callback;
            this.hero.Get<IComponent_HarvestResource>().OnHarvestStopped += this.OnHarvestFinished;
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (!operation.isCompleted)
            {
                return;
            }
            
            if (operation.resourceType == this.config.targetResourceType)
            {
                this.CompleteQuest();
            }
        }

        private void CompleteQuest()
        {
            this.hero.Get<IComponent_HarvestResource>().OnHarvestStopped -= this.OnHarvestFinished;
            this.callback?.Invoke();
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.hero = context.GetService<HeroService>().GetHero();
        }
    }
}