using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_Enable
    {
        event Action<bool> OnEnabled;
        
        bool IsEnable { get; }

        void SetEnable(bool isEnable);
    }
}