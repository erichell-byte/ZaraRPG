using UnityEngine;

namespace Game.GameEngine.GameResources
{
    [CreateAssetMenu(
        fileName = "ResourceInfo",
        menuName = "GameEngine/GameResources/New ResourceInfo"
    )]
    public sealed class ResourceInfo : ScriptableObject
    {
        [SerializeField]
        public ResourceType type;
        
        [SerializeField]
        public Sprite icon;
    }
}