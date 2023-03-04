using Game.Meta;
using UnityEngine;

namespace Game.Tutorial.UpgradeHero
{
    [CreateAssetMenu(
        fileName = "Upgrade Hero Config",
        menuName = "Tutorial/New Upgrade Hero Config"
    )]
    public sealed class Config_UpgradeHero : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public UpgradeConfig upgradeConfig;
        
        [SerializeField]
        public int targetLevel = 3;
    
        [Header("Meta")]
        [SerializeField]
        public string title = "UPGRADE DAMAGE";

        [SerializeField]
        public Sprite icon;
    }
}