using Elementary;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction State «Surface Position»")]
    public sealed class UMoveInDirectionState_SurfacePosition : MonoState
    {
        [SerializeField]
        private UMoveInDirectionEngine moveEngine;

        [SerializeField]
        private UTransformEngine transformEngine;

        [SerializeField]
        private WalkableSurfaceHolder surfaceHolder;

        [SerializeField]
        private FloatAdapter speed;

        private bool isEntered;

        public override void Enter()
        {
            this.isEntered = true;
        }

        public override void Exit()
        {
            this.isEntered = false;
        }

        private void FixedUpdate()
        {
            if (this.isEntered)
            {
                this.MoveInDirection();
            }
        }

        private void MoveInDirection()
        {
            var velocity = this.moveEngine.Direction * (this.speed.Value * Time.fixedDeltaTime);
            if (this.surfaceHolder.IsSurfaceExists)
            {
                this.MoveBySurface(velocity);
            }
            else
            {
                this.transformEngine.MovePosition(velocity);
            }
        }

        private void MoveBySurface(Vector3 velocity)
        {
            var nextPosition = this.transformEngine.WorldPosition + velocity;
            var surface = this.surfaceHolder.Surface;
            if (surface.IsAvailablePosition(nextPosition))
            {
                this.transformEngine.SetPosiiton(nextPosition);
            }
            else if (surface.FindAvailablePosition(nextPosition, out var clampedPosition))
            {
                this.transformEngine.SetPosiiton(clampedPosition);
            }
        }
    }
}