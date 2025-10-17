using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace WitchGate.Cards
{
    public abstract class CardCollection<T> where T : ICard
    {
        public event Action<T> OnCardAdded;
        public event Action<T> OnCardRemoved;
        
        public abstract IEnumerable<T> Cards { get; }


        public virtual void Clear()
        {
            using (ListPool<T>.Get(out List<T> list))
            {
                list.AddRange(Cards);
                foreach (var card in list)
                    RemoveCard(card);
            }
        }

        public void AddCards(IEnumerable<T> cards)
        {
            foreach (var card in cards)
            {
                AddCard(card);
            }
        }
        
        public bool AddCard(T card)
        {
            if (TryAddCard(card))
            {
                OnCardAdded?.Invoke(card);
                return true;
            }

            return false;
        }

        protected abstract bool TryAddCard(T card);
        
        public bool RemoveCard(T card)
        {
            if (TryRemoveCard(card))
            {
                OnCardRemoved?.Invoke(card);
                return true;
            }

            return false;
        }

        protected abstract bool TryRemoveCard(T card);
    }
}