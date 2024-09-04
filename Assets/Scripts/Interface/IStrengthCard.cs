using Main;
using UnityEngine;
using UnityEngine.UIElements;

namespace Interface
{
    public interface IStrengthCard: ICard,IEffectable
    {
        public void AttachEffect(ICard card);
        public void DetachEffect(ICard card);
        public ICard Target { get; set; }
        
        public GameObject myself { get; set; }

        public UIManager UIManager { get; set; }
    }
}
