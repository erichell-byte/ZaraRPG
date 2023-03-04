using System;
using System.Collections.Generic;
using Tutorial;
using UnityEngine;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Tutorial Manager")]
    public sealed class TutorialManager : TutorialManager<TutorialStep>
    {
        internal static TutorialManager Instance { get; private set; }

        protected override TutorialIterator<TutorialStep> Iterator
        {
            get { return iterator; }
        }

        private TutorialIterator<TutorialStep> iterator;

        [SerializeField]
        private TutorialStepConfig config;

        private void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("TutorialManager is already created!");
            }

            var steps = this.config.GetStepList();
            this.iterator = new TutorialIterator<TutorialStep>(steps);
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}