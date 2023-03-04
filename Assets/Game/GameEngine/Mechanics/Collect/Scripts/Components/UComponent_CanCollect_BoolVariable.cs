using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Collect/Component «Can Collect» (Bool Variable)")]
    public sealed class UComponent_CanCollect_BoolVariable : MonoBehaviour, IComponent_CanCollect
    {
        public bool CanCollect
        {
            get { return this.boolVariable.Value; }
        }

        [SerializeField]
        private MonoBoolVariable boolVariable;
    }
}