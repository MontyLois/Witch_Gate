using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using WitchGate.Cards.UI;
using WitchGate.Gameplay;

namespace WitchGate.Cards
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