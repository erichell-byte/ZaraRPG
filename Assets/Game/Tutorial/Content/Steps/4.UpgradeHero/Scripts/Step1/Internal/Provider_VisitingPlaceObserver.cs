using Game.Gameplay.Player;
using UnityEngine;

namespace Game.Tutorial.UpgradeHero
{
    [AddComponentMenu("Tutorial/Tutorial Provider «Visit Place Observer (Show Upgrades Popup)»")]
    public sealed class Provider_VisitingPlaceObserver : MonoBehaviour
    {
        public VisitingWorldPlaceObserver_ShowPopup Observer
        {
            get { return this.observer; }
        }

        [SerializeField]
        private VisitingWorldPlaceObserver_ShowPopup observer;
    }
}