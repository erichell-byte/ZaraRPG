using System;
using Entities;
using Game.GameEngine.GameResources;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial.SellResource
{
    public sealed class QuestInspector : Gameplay.QuestInspector, IGameConstructElement
    {
        [SerializeField]
        private Config_SellResource config;

        private VendorSaleInteractor vendorInteractor;

        private Action callback;

        public override void InspectQuest(Action callback)
        {
            this.callback = callback;
            this.vendorInteractor.OnResourcesSold += this.OnResourcesSold;
        }

        private void CompleteQuest()
        {
            this.vendorInteractor.OnResourcesSold -= this.OnResourcesSold;
            this.callback?.Invoke();
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.vendorInteractor = context.GetService<VendorSaleInteractor>();
        }

        private void OnResourcesSold(VendorSaleResult result)
        {
            if (result.resourceType == this.config.targetResourceType)
            {
                this.CompleteQuest();
            }
        }
    }
}