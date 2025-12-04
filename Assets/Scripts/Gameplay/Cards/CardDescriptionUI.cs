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
    public class CardDescriptionUI : CardUIComponent<IGameCard>
    {
        [field: SerializeField] public GameObject CardDescriptionGameObject { get; private set; }
        [field: SerializeField] public TMP_Text DescritpionText { get; private set; }


        public void Start()
        {
            CardDescriptionGameObject.SetActive(false);
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


        /*
        public  void OnPointerEnter(PointerEventData eventData)
        {
            CardDescriptionGameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CardDescriptionGameObject.SetActive(false);
        }*/
    }
}
