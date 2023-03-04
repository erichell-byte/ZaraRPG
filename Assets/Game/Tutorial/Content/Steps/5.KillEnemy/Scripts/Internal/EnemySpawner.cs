using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial.KillEnemy
{
    public sealed class EnemySpawner : MonoBehaviour, IGameAttachElement
    {
        private IGameContext gameContext;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private UnityEntity enemyPrefab;

        [SerializeField]
        private Transform spawnPoint;

        public UnityEntity SpawnEnemy()
        {
            var enemy = Instantiate(
                this.enemyPrefab,
                this.spawnPoint.position,
                this.spawnPoint.rotation,
                this.worldTransform
            );

            var gameElement = enemy.GetComponent<IGameElement>();
            this.gameContext.RegisterElement(gameElement);

            return enemy;
        }

        void IGameAttachElement.AttachGame(IGameContext context)
        {
            this.gameContext = context;
        }
    }
}