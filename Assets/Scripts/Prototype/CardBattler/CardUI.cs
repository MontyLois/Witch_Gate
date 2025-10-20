using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace WitchGate.Prototype
{
    public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action<CardUI> OnHoverEnter;
        public Action<CardUI> OnHoverExit;
        public Action<CardUI> OnClick;
        
        public HandUI HandUI { get; private set; }
        public Vector3 originalLocalPositions { get; private set; }
        
        private Vector3 originPosition;
        [field: SerializeField] public float Padding { get; private set; }

        public void SetHand(HandUI handUI)
        {
            HandUI = handUI;
        }
        
        public void SetPosition(Vector3 pos)
        {
            originalLocalPositions = pos;
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
