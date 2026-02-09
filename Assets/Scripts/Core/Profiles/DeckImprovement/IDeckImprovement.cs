using WitchGate.Cards.UI;

namespace WitchGate.Cards
{
    public interface IDeckImprovement<T>
    {
        public CardUI CardUI { get; set; }
        public T card { get; set; }
        public void OnSelect();
        public void Connect(T card);
        public T getCard();
        
        public void SelectWitch(Witch witch);
        public Witch selectedWitch { get; set; }
    
    }
}