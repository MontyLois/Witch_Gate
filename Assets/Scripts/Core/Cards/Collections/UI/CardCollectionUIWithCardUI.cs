using System;
using System.Collections.Generic;
using UnityEngine;

namespace WitchGate.Cards.Collections.UI
{
    public class CardCollectionUIWithCardUI<T> : CardCollectionUI<T> where T : ICard
    {
        [SerializeField] 
        private CardUI<T> prefab;
        [SerializeField] 
        private Transform root;


        private Dictionary<T, CardUI<T>> cards;

        private void Awake()
        {
            cards = new Dictionary<T, CardUI<T>>();
        }

        protected override void AddCardUI(T card)
        {
            if(cards.ContainsKey(card))
                return;
            
            CardUI<T> instance = Instantiate(prefab, root == null ? transform : root);
            cards.Add(card, instance);
            instance.Bind(card);
        }

        protected override void RemoveCardUI(T card)
        {
            if (cards.Remove(card, out CardUI<T> ui))
            {
                ui.Unbind();
                Destroy(ui.gameObject);
            }
        }
    }
}