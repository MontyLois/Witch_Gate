using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards.UI;
using WitchGate.Profiles;

namespace WitchGate.Gameplay.Cards.DeckImprovement
{
    public abstract class DeckImprovement : MonoBehaviour, IDeckImprovement<CardProfile>,
        IPointerEnterHandler, IPointerExitHandler
    {
        public CardProfile card { get; set; }
        protected PlayerProfile playerProfile;
        public Witch SelectedWitch  { get; set; } = Witch.None;

        [field: SerializeField]
        public WitchGameCardUI cardUIW { get; private set;}

        private void OnEnable()
        {
            playerProfile = GameController.GameDatabase.PlayerProfile;
        }
        
        protected virtual void Start()
        {
            playerProfile = GameController.GameDatabase.PlayerProfile;
            card = GetCard();
            Connect(card);
        }

        public void Connect(CardProfile card)
        {
            GameCard gameCard = new GameCard(card);
            cardUIW.Connect(gameCard);
        }

        public abstract void OnSelect();
        public abstract CardProfile GetCard();
        
        public void SelectWitch(Witch witch)
        {
            SelectedWitch = witch;
            Start();
        }

        public string GetTitle()
        {
            return card.CardData.Name;
        }


        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}