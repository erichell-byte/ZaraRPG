using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PresentationModel
{
    [CreateAssetMenu(
        fileName = "Product",
        menuName = "Lessons/New Product (Presentation Model)"
    )]
    public sealed class Product : ScriptableObject
    {
        [PreviewField]
        [SerializeField]
        public Sprite icon;

        [SerializeField]
        public string title;

        [TextArea]
        [SerializeField]
        public string description;
        
        [Space]
        [SerializeField]
        public BigNumber price;
    }
}