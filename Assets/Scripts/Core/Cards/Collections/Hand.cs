using System.Collections.Generic;

namespace WitchGate.Cards.Collections
{
    public class Hand<T> : CardCollection<T> where T : ICard
    {
        public override IEnumerable<T> Cards => cards;

        private readonly int maxSize;
        private readonly List<T> cards;

        public Hand(int maxSize)
        {
            this.maxSize = maxSize;
            cards = maxSize > 0 ? new List<T>(maxSize) : new List<T>();
        }
        
        
        protected override bool TryAddCard(T card)
        {
            if (maxSize > 0 && cards.Count >= maxSize)
                return false;

            if (cards.Contains(card))
                return false;
            
            cards.Add(card);
            return true;
        }

        protected override bool TryRemoveCard(T card) => cards.Remove(card);
    }
}