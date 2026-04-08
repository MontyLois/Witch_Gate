using System;
using System.Collections.Generic;
using System.Linq;
using Helteix.Cards;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards.Collections;
using WitchGate.Cards.UI;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;
using WitchGate.Gameplay.Cards.Effects;
using WitchGate.Gameplay.Cards.UI;
using WitchGate.Players;

namespace WitchGate.Cards
{
    public abstract class DeckImprovement : MonoBehaviour, IDeckImprovement<CardProfile>, IDescription
    {
        [field: SerializeField]
        public WitchCardUI WitchCardUI { get; set; }
        public CardProfile card { get; set; }

        protected PlayerProfile playerProfile;
        private ICardUI cardUI;
        private ICardUI cardUI1;

        public Witch selectedWitch  { get; set; } = Witch.None;
        
        
        
        public IEnumerable<CardBattleEffectData> Effects => CardManager.GetEffectsFor(card.CardData);

        protected virtual void Start()
        {
            playerProfile = GameController.GameDatabase.PlayerProfile;
        }

        public void Connect(CardProfile card)
        {
            WitchCardUI.ConnectCard(card);
        }

        public virtual void OnSelect()
        {
            
        }
        
        public abstract CardProfile GetCard();
        
        public void SelectWitch(Witch witch)
        {
            Start();
            selectedWitch = witch;
            card = GetCard();
            Connect(card);
        }

        public string GetDescription()
        {
            string description = "";
            int effectsLenght = Effects.Count();
            for (int i = 0; i < effectsLenght; i++)
            {
                description += Effects.ElementAt(i).GetEffectDescription(card.Level);
                if (i < Effects.Count() - 1)
                {
                    description += ", ";
                }
            }
            description += ".";
            return description;
        }

        public string GetTitle()
        {
            return card.CardData.Name;
        }

        ICardUI ICardUIComponent.CardUI
        {
            get => cardUI1;
            set => cardUI1 = value;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("aaaaaaaaaaa");
            UIManager.TriggerOnCardHovered(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIManager.TriggerOnCardUnhovered();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
           
        }
    }
}