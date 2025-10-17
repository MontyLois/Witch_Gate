using System.Collections.Generic;

namespace WitchGate.Cards.Collections
{
    public class Discard<T> : CardCollection<T> where T : ICard
    {
        public override IEnumerable<T> Cards => cards;

        private readonly List<T> cards = new();

        protected override bool TryAddCard(T card)
        {
            if (cards.Contains(card))
                return false;
            
            cards.Add(card);
            return true;
        }

        protected override bool TryRemoveCard(T card) => cards.Remove(card);
    }
}