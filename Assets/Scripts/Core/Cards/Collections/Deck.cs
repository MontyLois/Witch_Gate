using System.Collections.Generic;
using UnityEngine.Pool;

namespace WitchGate.Cards.Collections
{
    public class Deck<T> : CardCollection<T> where T : ICard
    {
        public override IEnumerable<T> Cards => cards;


        private readonly Queue<T> cards = new();


        public bool TryGetTopCard(out T card)
        {
            if (cards.TryPeek(out card))
            {
                RemoveCard(card);
                return true;
            }

            return false;
        }
        protected override bool TryAddCard(T card)
        {
            cards.Enqueue(card);
            return true;
        }

        protected override bool TryRemoveCard(T card)
        {
            using (ListPool<T>.Get(out var list))
            {
                list.AddRange(cards);
                if (!list.Remove(card))
                    return false;
                
                cards.Clear();
                foreach (var c in list)
                    cards.Enqueue(c);

                return true;
            }
        }
    }
}