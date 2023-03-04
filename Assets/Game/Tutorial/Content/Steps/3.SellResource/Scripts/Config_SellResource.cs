using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Sell Resource Config",
        menuName = "Tutorial/New Sell Resource Config"
    )]
    public sealed class Config_SellResource : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType targetResourceType = ResourceType.STONE;
    
        [Header("Meta")]
        [SerializeField]
        public string title = "SELL TREE";

        [SerializeField]
        public Sprite icon;
    }
}