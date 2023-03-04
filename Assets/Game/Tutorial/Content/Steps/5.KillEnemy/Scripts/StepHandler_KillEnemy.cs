using System.Collections;
using Entities;
using Game.Tutorial.Gameplay;
using Game.Tutorial.KillEnemy;
using UnityEngine;

namespace Game.Tutorial.KillEnemy
{
    public sealed class StepHandler_KillEnemy : StepHandler
    {
        [Space]
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private EnemyDestroyer enemyDestroyer;

        [Space]
        [SerializeField]
        private QuestInspector questInspector;

        [SerializeField]
        private QuestViewProjector viewProjector;
        
        [Space]
        [SerializeField]
        private float showUIDelay = 1.0f;

        protected override void OnStartStep()
        {
            var enemy = this.enemySpawner.SpawnEnemy();
            this.questInspector.InspectQuest(enemy, this.OnEnemyDestroyed);
            this.StartCoroutine(this.ShowQuestRoutine());
        }

        private IEnumerator ShowQuestRoutine()
        {
            yield return new WaitForSeconds(this.showUIDelay);
            this.viewProjector.ShowQuest();
        }

        private void OnEnemyDestroyed(UnityEntity enemy)
        {
            this.viewProjector.HideQuest();
            this.enemyDestroyer.DestroyEnemy(enemy);
            this.FinishStepAndMoveNext();
        }
    }
}