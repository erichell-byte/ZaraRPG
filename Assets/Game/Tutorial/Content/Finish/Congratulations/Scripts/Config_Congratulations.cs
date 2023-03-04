using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Congratulations Config",
        menuName = "Tutorial/New Congratulations Config"
    )]
    public sealed class Config_Congratulations : ScriptableObject
    {
        [Header("Meta")]
        [SerializeField]
        public string title;

        [TextArea]
        [SerializeField]
        public string description;
    }
}