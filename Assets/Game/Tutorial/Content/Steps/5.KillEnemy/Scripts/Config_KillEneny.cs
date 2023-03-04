using UnityEngine;

namespace Game.Tutorial.KillEnemy
{
    [CreateAssetMenu(
        fileName = "Kill Eneny Config",
        menuName = "Tutorial/New Kill Eneny Config"
    )]
    public sealed class Config_KillEneny : ScriptableObject
    {
        [Header("Meta")]
        [SerializeField]
        public string title = "KILL ENEMY";

        [SerializeField]
        public Sprite icon;
    }
}