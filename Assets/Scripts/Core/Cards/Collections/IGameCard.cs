using Helteix.Cards;

namespace WitchGate.Cards
{
    public interface IGameCard : ICard
    {
        public CardData Data { get; }
    }
}