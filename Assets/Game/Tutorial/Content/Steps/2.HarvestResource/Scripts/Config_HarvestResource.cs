using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Harvest Resource Config",
        menuName = "Tutorial/New Harvest Resource Config"
    )]
    public sealed class Config_HarvestResource : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType targetResourceType = ResourceType.STONE;
    
        [Header("Meta")]
        [SerializeField]
        public string title = "CUT TREE";

        [SerializeField]
        public Sprite icon;
    }
}