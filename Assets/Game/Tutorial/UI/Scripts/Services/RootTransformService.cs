using UnityEngine;

namespace Game.Tutorial.UI
{
    public sealed class RootTransformService : MonoBehaviour
    {
        public Transform RootTransform
        {
            get { return this.rootTransform; }
        }

        [SerializeField]
        private Transform rootTransform;
    }
}