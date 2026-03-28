using System;
using TMPro;
using UnityEngine;
using WitchGate.Cards.Collections;

namespace WitchGate.Gameplay.Cards.UI
{
    public class DescriptionUI : MonoBehaviour
    {
        [field: SerializeField] public GameObject CardDescriptionGameObject { get; private set; }
        [field: SerializeField] public TMP_Text DescritpionText { get; private set; }
        [field: SerializeField] public TMP_Text TitleText { get; private set; }
        
        
        private void OnEnable()
        {
            UIManager.OnCardHovered += ShowDescription;
            UIManager.OnCardUnhovered += HideDescription;
            CardDescriptionGameObject.SetActive(false);
        }
        
        private void OnDisable()
        {
            CardDescriptionGameObject.SetActive(false);
            UIManager.OnCardHovered -= ShowDescription;
            UIManager.OnCardUnhovered -= HideDescription;
        }

        private void ShowDescription(IDescription description)
        {
            DescritpionText.text = description.GetDescription();
            TitleText.text = description.GetTitle();
            CardDescriptionGameObject.SetActive(true);
        }

        private void HideDescription()
        {
            DescritpionText.text = "";
            TitleText.text = "";
            CardDescriptionGameObject.SetActive(false);
        }
    }
}