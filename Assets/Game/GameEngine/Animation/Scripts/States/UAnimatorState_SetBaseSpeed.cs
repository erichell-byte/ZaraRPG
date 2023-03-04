using Elementary;
using Game.GameEngine.Animation;
using UnityEngine;

namespace Game.GameEngine
{
    [AddComponentMenu("GameEngine/Animation/Animator State «Set Base Speed»")]
    public sealed class UAnimatorState_SetBaseSpeed : MonoState
    {
        [SerializeField]
        private UAnimatorSystem animationSystem;

        [Space]
        [SerializeField]
        private IntAdapter speed;

        public override void Enter()
        {
            this.animationSystem.SetBaseSpeed(this.speed.Value);
        }
    }
}