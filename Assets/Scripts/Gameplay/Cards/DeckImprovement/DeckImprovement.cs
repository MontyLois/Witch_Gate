using System;
using System.Collections.Generic;
using System.Linq;
using Helteix.Cards;
using Helteix.Cards.Collections;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using WitchGate.Cards.Collections;
using WitchGate.Cards.UI;
using WitchGate.Controllers;
using WitchGate.Gameplay;
using WitchGate.Gameplay.Battles.UI;
using WitchGate.Gameplay.Cards;
using WitchGate.Gameplay.Cards.Effects;
using WitchGate.Gameplay.Cards.UI;
using WitchGate.Players;

namespace WitchGate.Cards
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
        

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("aaaaaaaaaaa");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}