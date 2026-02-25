using UnityEngine;
using WitchGate.Cards.UI;

namespace WitchGate.Cards
{
    public interface IDeckImprovement
    {
        public void SelectWitch(Witch witch);
        public Witch selectedWitch { get; set; }
    }
    
    public interface IDeckImprovement<T> : IDeckImprovement
    {
        public CardUI CardUI { get; set; }
        public T card { get; set; }
        public void OnSelect();
        public void Connect(T card);
        public T getCard();
    }
}