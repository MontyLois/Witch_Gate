using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WitchGate.Prototype
{
    public class CardSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action<CardSlotUI> OnHoverEnter;
        public Action<CardSlotUI> OnHoverExit;
        public Action<CardSlotUI> OnClick;
        
        public GameObject Card { get; private set; }
        
        public void AddCardToSlot(GameObject card)
        {
            Card = card;
            card.transform.DOKill();
            
            card.transform.SetParent(this.transform,false);
            
            RectTransform rect = card.GetComponent<RectTransform>();
            // Keep width
            float width = rect.rect.width;


            rect.offsetMax = new Vector2(0.7f, 0);
            rect.offsetMin = new Vector2(0, 0);
            /*
            rect.anchorMin = new Vector3(0.5f,0,0);
            rect.anchorMax = new Vector3(0.5f,1,0);
            rect.anchoredPosition = new Vector2(0, 0f);*/
            rect.sizeDelta = new Vector2(0.7f, 0);
    
          
        }

        public void RemoveCardToSlot()
        {
            Card = null;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHoverEnter?.Invoke(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnHoverExit?.Invoke(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }
    }
}