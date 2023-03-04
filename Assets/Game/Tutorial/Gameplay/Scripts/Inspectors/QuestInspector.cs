using System;
using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public abstract class QuestInspector : MonoBehaviour
    {
        public abstract void InspectQuest(Action callback);
    }
}