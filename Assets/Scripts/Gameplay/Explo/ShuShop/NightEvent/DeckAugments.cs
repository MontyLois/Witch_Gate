using System;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Prototype;

namespace WitchGate.Gameplay
{
    public class DeckAugments : CharacterDialog
    {
        
        [field: SerializeField]
        public RemoveCardUpgrade removeCardUpgrade { get; private set; }
        [field: SerializeField]
        public LevelUpCardUpgrade levelUpCardUpgrade { get; private set; }
        [field: SerializeField]
        public NewCardUpgrade newCardUpgrade { get; private set; }
        
        
        [field: SerializeField]
        public GameObject Shop { get; private set; }
        
        
        private void Start()
        {
            _dialogBehaviour.BindExternalFunction("SelectWitch", SelectWitch);
            _dialogBehaviour.BindExternalFunction("ToogleShop", ToggleShop);
        }
        
        public void SelectWitch()
        {
            Witch witch = (Witch) _dialogBehaviour.GetVariableValue<int>("WitchIndex");
        }

        public void ToggleShop()
        {
            Shop.SetActive(!Shop.activeSelf);
        }
    }
}
