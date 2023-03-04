using System;
using Game.Gameplay.Player;
using Game.Gameplay.Hero;

namespace Game.Tutorial.UpgradeHero
{
    public class VisitingPlaceObserver_ShowFakePopup : VisitingWorldPlaceObserver
    {
        public event Action OnVisitStarted;

        protected sealed override void OnStartVisit()
        {
            this.OnVisitStarted?.Invoke();
        }
    }
}