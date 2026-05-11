namespace WitchGate.Gameplay.Cards.DeckImprovement
{
    public interface IDeckImprovement
    {
        public void SelectWitch(Witch witch);
        public Witch SelectedWitch { get; set; }
    }
    
    public interface IDeckImprovement<T> : IDeckImprovement
    {
        //public WitchGameCardUI WitchGameCardUI { get; set; }
        public T card { get; set; }
        public void OnSelect();
        public void Connect(T card);
        public T GetCard();
        
    }
}