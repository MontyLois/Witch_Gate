using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using WitchGate.Cards.UI;

namespace WitchGate.Cards
{
    public interface IDeckImprovement : ICardPointerHoverHandler
    {
        public void SelectWitch(Witch witch);
        public Witch selectedWitch { get; set; }
    }
    
    public interface IDeckImprovement<T> : IDeckImprovement
    {
        public WitchCardUI WitchCardUI { get; set; }
        public T card { get; set; }
        public void OnSelect();
        public void Connect(T card);
        public T GetCard();
        
    }
}