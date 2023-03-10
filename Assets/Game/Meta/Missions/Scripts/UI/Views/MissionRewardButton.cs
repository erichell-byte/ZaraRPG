using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Meta
{
    public sealed class MissionRewardButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [Space]
        [SerializeField]
        private Image buttonBackground;

        [SerializeField]
        private Sprite availableBackground;

        [SerializeField]
        private Sprite unavailableBackground;

        [Space]
        [SerializeField]
        private GameObject processingText;

        [SerializeField]
        private GameObject getText;

        [SerializeField]
        private TextMeshProUGUI rewardText;

        [Space]
        [SerializeField]
        private State state;

        public void AddListener(UnityAction action)
        {
            this.button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            this.button.onClick.RemoveListener(action);
        }

        public void SetReward(string reward)
        {
            this.rewardText.text = reward;
        }

        public void SetState(State state)
        {
            this.state = state;

            if (state == State.COMPLETE)
            {
                this.button.interactable = true;
                this.buttonBackground.sprite = this.availableBackground;
                this.getText.SetActive(true);
                this.processingText.SetActive(false);
            }
            else if (state == State.PROCESSING)
            {
                this.button.interactable = false;
                this.buttonBackground.sprite = this.unavailableBackground;
                this.getText.SetActive(false);
                this.processingText.SetActive(true);
            }
            else
            {
                throw new Exception($"Undefined button state {state}!");
            }
        }

        public enum State
        {
            COMPLETE = 0,
            PROCESSING = 1
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            try
            {
                this.SetState(this.state);
            }
            catch (Exception)
            {
                // ignored
            }
        }
#endif
    }
}