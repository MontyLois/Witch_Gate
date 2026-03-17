using Helteix.Cards;

namespace WitchGate.Cards.Collections
{
    public interface ITaroCard : ICard
    {
        public string GetCardDescription();
        public string GetCardName();
    }
}