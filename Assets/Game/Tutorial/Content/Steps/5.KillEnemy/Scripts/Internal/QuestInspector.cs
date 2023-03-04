using System;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using Game.GameEngine;
using Game.Gameplay.Hero;
using UnityEngine;

namespace Game.Tutorial.KillEnemy
{
    public sealed class QuestInspector : MonoBehaviour
    {
        private UnityEntity targetEnemy;
    
        private Action<UnityEntity> callback;

        public void InspectQuest(UnityEntity enemy, Action<UnityEntity> callback)
        {
            this.callback = callback;
            this.targetEnemy = enemy;
            this.targetEnemy.Get<IComponent_OnDestroyed<DestroyArgs>>().OnDestroyed += this.OnEnemyDestroyed;
        }

        private void OnEnemyDestroyed(DestroyArgs destroyArgs)
        {
            this.targetEnemy.Get<IComponent_OnDestroyed<DestroyArgs>>().OnDestroyed -= this.OnEnemyDestroyed;
            var enemy = this.targetEnemy;
            this.targetEnemy = null;
            this.callback?.Invoke(enemy);
        }
    }
}