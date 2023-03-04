using AI.Blackboards;
using AI.BTree;
using Elementary;
using Entities;
using Polygons;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Follow Entity By Polygon» (Entity)")]
    public class UBTNode_Entity_FollowEntityByPolygon : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private FloatAdapter stoppingDistance;

        [SerializeField]
        private FloatAdapter minPointDistance;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [BlackboardKey]
        [SerializeField]
        private string surfaceKey;

        private Agent_Entity_FollowEntityByPolygon followAgent;

        private void Awake()
        {
            this.followAgent = new Agent_Entity_FollowEntityByPolygon(coroutineDispatcher: this);
            this.followAgent.SetStoppingDistance(this.stoppingDistance.Value);
            this.followAgent.SetMinPointDistance(this.minPointDistance.Value);
            this.followAgent.SetCalculatePathPeriod(new WaitForFixedUpdate());
            this.followAgent.SetCheckTargetReachedPeriod(null);
        }

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.surfaceKey, out MonoPolygon polygon))
            {
                this.Return(false);
                return;
            }

            this.followAgent.OnTargetReached += this.OnTargetReached;
            this.followAgent.SetSurface(polygon);
            this.followAgent.SetTargetEntity(target);
            this.followAgent.SetFollowingEntity(unit);
            this.followAgent.Play();
        }

        private void OnTargetReached(bool isReached)
        {
            if (isReached)
            {
                this.Return(true);
            }
        }

        protected override void OnEnd()
        {
            this.followAgent.Stop();
            this.followAgent.OnTargetReached -= this.OnTargetReached;
        }
    }
}