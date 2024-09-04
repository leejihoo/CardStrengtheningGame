using UnityEngine;
using UnityEngine.EventSystems;

namespace Interface
{
    public interface ICard: IProduct, IPointerClickHandler
    {
        public int Cost { get; set; }
        public Sprite CardSprite { get; set; }
    }
}
