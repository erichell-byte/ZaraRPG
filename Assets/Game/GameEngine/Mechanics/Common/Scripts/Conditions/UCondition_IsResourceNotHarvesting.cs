using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Resource Not Harvesting»")]
    public sealed class UCondition_IsResourceNotHarvesting : MonoCondition
    {
        [SerializeField]
        public UHarvestResourceEngine engine;
        
        public override bool IsTrue()
        {
            return !this.engine.IsHarvesting;
        }
    }
}