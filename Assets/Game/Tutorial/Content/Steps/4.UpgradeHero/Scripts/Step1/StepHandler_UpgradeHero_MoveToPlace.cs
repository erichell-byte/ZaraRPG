using System.Collections;
using Game.Gameplay.Player;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using Game.Gameplay.Hero;
using UIFrames.Unity;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Tutorial.UpgradeHero
{
    public sealed class StepHandler_UpgradeHero_MoveToPlace : StepHandler
    {
        private IGameContext gameContext;
    
        private PointerManager pointerManager;

        private NavigationManager navigationManager;

        [Header("Quest View")]
        [SerializeField]
        private QuestViewProjector viewProjector;
        
        [Space]
        [SerializeField]
        private float showDelay = 1.0f;

        [FormerlySerializedAs("fakeVisitInteractor")]
        [Header("Visit Place")]
        [SerializeField]
        private VisitingPlaceObserver_ShowFakePopup fakeObserver;

        private VisitingWorldPlaceObserver_ShowPopup baseObserver;
        
        [SerializeField]
        private Transform pointerTransform;
        
        [Header("Upgrades Popup")]
        [SerializeField]
        private UnityFrame popupPrefab;
        
        private PopupManager popupManager;

        protected override void InitGame(IGameContext context, bool stepFinished)
        {
            this.gameContext = context;
            this.pointerManager = context.GetService<PointerManager>();
            this.navigationManager = context.GetService<NavigationManager>();
            
            this.baseObserver = context.GetService<Provider_VisitingPlaceObserver>().Observer;
            this.popupManager = context.GetService<PopupManager>();
            
            if (!stepFinished)
            {
                //Убираем базовый триггер
                this.gameContext.UnregisterElement(this.baseObserver);
            }
        }

        protected override void OnStartStep()
        {
            //Добавляем заглушечный триггер
            this.gameContext.RegisterElement(this.fakeObserver);
            this.fakeObserver.OnVisitStarted += this.OnHeroVisitUpgrades;

            //Показываем указатель:
            var targetPosition = this.pointerTransform.position;
            this.pointerManager.ShowPointer(targetPosition, this.pointerTransform.rotation);
            this.navigationManager.StartLookAt(targetPosition);
            
            //Показываем квест в UI:
            this.StartCoroutine(this.ShowQuestRoutine());
        }

        private IEnumerator ShowQuestRoutine()
        {
            yield return new WaitForSeconds(this.showDelay);
            this.viewProjector.ShowQuest();
        }

        private void OnHeroVisitUpgrades()
        {
            //Убираем заглушечный триггер
            this.fakeObserver.OnVisitStarted -= this.OnHeroVisitUpgrades;
            this.gameContext.UnregisterElement(this.fakeObserver);
            
            //Возвращаем базовый триггер
            this.gameContext.RegisterElement(this.baseObserver);

            //Убираем указатель
            this.pointerManager.HidePointer();
            this.navigationManager.Stop();

            //Убираем квест из UI:
            this.viewProjector.HideQuest();
            
            //Показываем попап:
            this.popupManager.Show(this.popupPrefab, args: null);
        }
    }
}