using System.Collections.Generic;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "TutorialStepConfig",
        menuName = "Tutorial/New TutorialStepConfig",
        order = 35
    )]
    public sealed class TutorialStepConfig : ScriptableObject
    {
        [SerializeField]
        private List<TutorialStep> steps = new();

        public int IndexOf(TutorialStep step)
        {
            return this.steps.IndexOf(step);
        }

        public List<TutorialStep> GetStepList()
        {
            return this.steps;
        }
    }
}