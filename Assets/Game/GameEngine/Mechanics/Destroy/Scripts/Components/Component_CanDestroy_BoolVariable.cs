using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class Component_CanDestroy_BoolVariable : IComponent_CanDestroy
    {
        private readonly IValue<bool> isActive;

        public Component_CanDestroy_BoolVariable(IValue<bool> isActive)
        {
            this.isActive = isActive;
        }

        public bool CanDestroy()
        {
            return this.isActive.Current;
        }
    }
}