using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace WitchGate.Prototype
{
    public class CardShopManager : MonoBehaviour
    {
        [field: SerializeField] public GameObject CardPrefab { get; private set; }
        [field: SerializeField] public int StartDrawCount { get; private set; }

        //hand for each girl
        [field: SerializeField] public HandUI  HandUI { get; private set; }
        
        //card Slot
        [field: SerializeField] public Transform DrawPosition { get; private set; } 
        private List<GameObject> cardsGO = new List<GameObject>();
      
        //effect and animation
        [field: SerializeField] public float hoverOffset { get; private set; }
        [field: SerializeField] public float hoverScale { get; private set; }
        [field: SerializeField] public float animDuration { get; private set; }


        private GameObject selectedCard;

        private void OnEnable()
        {
           
                for (int i=0; i < StartDrawCount; i++)
                {
                    GameObject card = Instantiate(CardPrefab, DrawPosition.position, DrawPosition.rotation);
                    cardsGO.Add(card);
                    HandUI.AddCardToHand(card);
                
                    CardUI cardUI = card.GetComponent<CardUI>();
                    cardUI.SetPosition(card.transform.localPosition);
                    cardUI.SetHand(HandUI);
                    RegisterCard(cardUI);
                }
        }

        private void OnDisable()
        {
            foreach (var card in cardsGO)
            {
                UnRegisterCard(card);
            }
        }
        
        private void RegisterCard(CardUI card)
        {
            card.OnHoverEnter += HandleHoverEnter;
            card.OnHoverExit += HandleHoverExit;
            card.OnClick += ClickOnHandCard;
        }
        
        private void UnRegisterCard(GameObject card)
        {
            
            CardUI cardUI = card.GetComponent<CardUI>();
            cardUI.OnHoverEnter -= HandleHoverEnter;
            cardUI.OnHoverExit -= HandleHoverExit;
            cardUI.OnClick -= ClickOnHandCard;
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

        private void RemoveCard()
        {
            HandUI.RemoveCardToHand(selectedCard);
            UnRegisterCard(selectedCard);
            Destroy(selectedCard);
        }
    }
}