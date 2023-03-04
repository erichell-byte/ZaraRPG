using UnityEngine;

namespace Game.Tutorial.Welcome
{
    [CreateAssetMenu(
        fileName = "Welcome Config",
        menuName = "Tutorial/New Welcome Config"
    )]
    public sealed class Config_Welcome : ScriptableObject
    {
        [SerializeField]
        public string title;

        [TextArea]
        [SerializeField]
        public string description;
    }
}