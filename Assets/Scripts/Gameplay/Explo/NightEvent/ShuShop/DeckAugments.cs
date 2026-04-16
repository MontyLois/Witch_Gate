using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Cards.UI;
using WitchGate.Players;
using WitchGate.Prototype;

namespace WitchGate.Gameplay
{
    public class DeckAugments : CharacterDialog
    {
        
        [SerializeField]
        private MonoBehaviour[] _improvementBehaviours;
        
        
        [field: SerializeField]
        public GameObject Shop { get; private set; }
        
        private List<IDeckImprovement> _deckImprovements;

        //transfer all monobehavior to the deckimprovement list
        private void Awake()
        {
            _deckImprovements = new List<IDeckImprovement>();
            foreach (var improvement in _improvementBehaviours)
            {
                if (improvement.TryGetComponent(out IDeckImprovement deckImprovement))
                {
                    _deckImprovements.Add(deckImprovement);
                }
            }
        }
        
        private void Start()
        {
            // Bind function to dialog external function
            _dialogBehaviour.BindExternalFunction("SelectWitch", SelectWitch);
            _dialogBehaviour.BindExternalFunction("ToogleShop", ToggleShop);
        }
        
        //select which deck will be upgraded
        public void SelectWitch()
        {
            Witch witch = (Witch) _dialogBehaviour.GetVariableValue<int>("WitchIndex");
            foreach (var  deckImprovement in _deckImprovements)
            {
                deckImprovement.SelectWitch(witch);
            }
        }

        //toogle the UI for Shu Shop
        public void ToggleShop()
        {
            Shop.SetActive(!Shop.activeSelf);
        }
        
    }
}
