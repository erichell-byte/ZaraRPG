using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public sealed class NavigationManager : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private NavigationArrow arrow;

        private IComponent_GetPosition heroComponent;

        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        private Vector3 targetPosition;
        
        [ReadOnly]
        [ShowInInspector]
        private bool isActive;

        private void Awake()
        {
            this.arrow.Hide();
        }

        private void Update()
        {
            if (this.isActive)
            {
                this.arrow.SetPosition(this.heroComponent.Position);
                this.arrow.LookAt(this.targetPosition);   
            }
        }

        public void StartLookAt(Vector3 targetPosition)
        {
            this.arrow.Show();
            this.isActive = true;
            this.targetPosition = targetPosition;
        }

        public void Stop()
        {
            this.arrow.Hide();
            this.isActive = false;
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.heroComponent = context
                .GetService<HeroService>()
                .GetHero()
                .Get<IComponent_GetPosition>();
        }
    }
}