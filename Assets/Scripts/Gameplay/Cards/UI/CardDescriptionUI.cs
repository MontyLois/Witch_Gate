using System;
using Helteix.Cards;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards;

namespace WitchGate
{
    public class CardDescriptionUI : CardUIComponent<IGameCard>, ICardPointerHoverHandler
    {
        [field: SerializeField] public GameObject CardDescriptionGameObject { get; private set; }
        [field: SerializeField] public TMP_Text DescritpionText { get; private set; }
        

        private void OnEnable()
        {
            CardDescriptionGameObject.SetActive(false);
        }
        
        private void OnDisable()
        {
            CardDescriptionGameObject.SetActive(false);
        }

        void Update()
        {
            CardDescriptionGameObject.transform.rotation = Camera.main.transform.rotation;
        }

        public override void Connect(IGameCard current)
        {
            base.Connect(current);
            DescritpionText.text = current.Data.Description;
        }

        public override void Disconnect(IGameCard current)
        {
            base.Disconnect(current);
            DescritpionText.text = "";
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            CardDescriptionGameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CardDescriptionGameObject.SetActive(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            
        }
    }
}
