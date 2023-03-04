using System.Collections;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UIFrames.Unity;
using UnityEngine;

namespace Game.Tutorial
{
    public sealed class CompleteHandler_Congratulations : CompleteHandler
    {
        [SerializeField]
        private UnityFrame popupPrefab;

        [SerializeField]
        private Config_Congratulations config;

        [SerializeField]
        private float showPopupDelay = 0.5f;
        
        private PopupManager popupManager;
        
        protected override void OnComplete()
        {
            this.StartCoroutine(this.ShowPopupRoutine());
        }

        protected override void InitGame(IGameContext context, bool isCompleted)
        {
            base.InitGame(context, isCompleted);
            this.popupManager = context.GetService<PopupManager>();
        }

        private IEnumerator ShowPopupRoutine()
        {
            yield return new WaitForSeconds(this.showPopupDelay);
            var args = new PopupArgs(this.config.title, this.config.description);
            this.popupManager.Show(this.popupPrefab, args);
        }
    }
}