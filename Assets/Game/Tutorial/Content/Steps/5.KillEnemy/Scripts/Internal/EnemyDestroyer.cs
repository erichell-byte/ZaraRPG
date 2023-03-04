using System.Collections;
using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial.KillEnemy
{
    public sealed class EnemyDestroyer : MonoBehaviour, IGameAttachElement
    {
        private IGameContext gameContext;

        [SerializeField]
        private float destroyDelay = 1.25f;

        public void DestroyEnemy(UnityEntity entity)
        {
            this.StartCoroutine(this.DestroyEnemyRoutine(entity));
        }

        private IEnumerator DestroyEnemyRoutine(UnityEntity entity)
        {
            var gameElement = entity.GetComponent<IGameElement>();
            this.gameContext.UnregisterElement(gameElement);
            
            yield return new WaitForSecondsRealtime(this.destroyDelay);
            Destroy(entity.gameObject);
        }

        void IGameAttachElement.AttachGame(IGameContext context)
        {
            this.gameContext = context;
        }
    }
}