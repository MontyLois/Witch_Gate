using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

namespace WitchGate.Prototype
{
    public class CardManager : MonoBehaviour
    {
        [field: SerializeField] public GameObject CardPrefab { get; private set; }
        [field: SerializeField] public int StartDrawCount { get; private set; }

        //hand for each girl
        [field: SerializeField] public List<HandUI>  HandUI { get; private set; }
        
        //card Slot
        [field: SerializeField] public List<CardSlotUI>  CardSlotUI { get; private set; }
        [field: SerializeField] public Transform DrawPosition { get; private set; } 
        private List<GameObject> cardsGO = new List<GameObject>();
      
        //effect and animation
        [field: SerializeField] public float hoverOffset { get; private set; }
        [field: SerializeField] public float hoverScale { get; private set; }
        [field: SerializeField] public float animDuration { get; private set; }


        private GameObject selectedCard;

        private void OnEnable()
        {
            foreach (var hand in HandUI)
            {
                for (int i=0; i < StartDrawCount; i++)
                {
                    GameObject card = Instantiate(CardPrefab, DrawPosition.position, DrawPosition.rotation);
                    cardsGO.Add(card);
                    hand.AddCardToHand(card);
                
                    CardUI cardUI = card.GetComponent<CardUI>();
                    cardUI.SetPosition(card.transform.localPosition);
                    cardUI.SetHand(hand);
                    RegisterCard(cardUI);
                }
            }

            foreach (var cardSlot in CardSlotUI)
            {
                cardSlot.OnClick += SelectSlot;
            }
           
        }

        private void OnDisable()
        {
            foreach (var card in cardsGO)
            {
                CardUI cardUI = card.GetComponent<CardUI>();
                UnRegisterCard(cardUI);
            }
            
            foreach (var cardSlot in CardSlotUI)
            {
                cardSlot.OnClick -= SelectSlot;
            }
        }
        
        private void RegisterCard(CardUI card)
        {
            card.OnHoverEnter += HandleHoverEnter;
            card.OnHoverExit += HandleHoverExit;
            card.OnClick += ClickOnHandCard;
        }
        
        private void UnRegisterCard(CardUI card)
        {
            card.OnHoverEnter -= HandleHoverEnter;
            card.OnHoverExit -= HandleHoverExit;
            card.OnClick -= ClickOnHandCard;
        }
        
        private void HandleHoverEnter(CardUI card)
        {
            HandUI hand = card.HandUI;
            Vector3 basePos = card.originalLocalPositions;
            card.transform.DOKill();
            card.transform.DOLocalMove(basePos + Vector3.up * hoverOffset, animDuration);
            //card.transform.DOScale(hoverScale, animDuration);
        }

        private void HandleHoverExit(CardUI card)
        {
            HandUI hand = card.HandUI;
            Vector3 basePos = card.originalLocalPositions;
            card.transform.DOKill();
            card.transform.DOLocalMove(basePos, animDuration).SetEase(Ease.OutQuad);
            //card.transform.DOScale(1f, animDuration);
        }

        private void ClickOnHandCard(CardUI card)
        {
            Debug.Log($"Clicked on: {card.name}");
            selectedCard = card.gameObject;
        }
        
        private void SelectSlot(CardSlotUI cardSlot)
        {
            if (selectedCard != null)
            {
                if (cardSlot.Card != null)
                {
                    selectedCard = null;
                }
                else
                {
                    HandUI handUI = selectedCard.GetComponent<CardUI>().HandUI;
                    handUI.RemoveCardToHand(selectedCard);
                    cardSlot.AddCardToSlot(selectedCard);
                    selectedCard = null;
                }
            }
            else
            {
                if (cardSlot.Card != null)
                {
                    HandUI handUI = cardSlot.Card.GetComponent<CardUI>().HandUI;
                    handUI.AddCardToHand(cardSlot.Card);
                    cardSlot.RemoveCardToSlot();
                }
            }
        }
    }
}