using UnityEngine;

namespace WitchGate.Cards.Collections.UI
{
    public abstract class CardUI<T> : MonoBehaviour where T : ICard
    {
        public T Card { get; private set; }

        internal void Bind(T card)
        {
            if(Card != null)
                Unbind();

            Card = card;
            LinkWithCard(card);
        }


        internal void Unbind()
        {
            if(Card == null)
                return;
            
            UnlinkWithCard(Card);
            Card = default;
        }

        protected abstract void LinkWithCard(T card);
        protected abstract void UnlinkWithCard(T card);
    }
}