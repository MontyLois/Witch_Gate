using Helteix.Cards.Collections;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles
{
    public class BattlePhase : IPhase
    {
        public readonly IBattleEnemy Enemy;
        
        public Deck<GameCard> VelmoraDeck { get; private set; }
        public Deck<GameCard> ElarisDeck { get; private set; }
        public Hand<GameCard> VelmoraHand { get; private set; }
        public Hand<GameCard> ElarisHand { get; private set; }
        public Hand<GameCard> PlayedVelmoraHand { get; private set; }
        public Hand<GameCard> PlayedElarisHand { get; private set; }
        

        public BattlePhase(IBattleEnemy enemy)
        {
            this.Enemy = enemy;
            VelmoraHand = new Hand<GameCard>(GameController.Metrics.MaxBattleHandSize);
            ElarisHand = new Hand<GameCard>(GameController.Metrics.MaxBattleHandSize);

            VelmoraDeck = new Deck<GameCard>();
            ElarisDeck = new Deck<GameCard>();

            PlayedElarisHand = new Hand<GameCard>(1);
            PlayedVelmoraHand = new Hand<GameCard>();
        }

        public void PlayerTurn()
        {
            foreach (var card in PlayedElarisHand.Cards)
                card.Use();
            
            foreach (var card in PlayedVelmoraHand.Cards)
                card.Use();
            
            //PlayedElarisHand.;
        }

        void IPhase.OnBegin()
        {
            
        }

        void IPhase.OnComplete()
        {
            
        }

        void IPhase.OnCancel()
        {
            
        }
    }
}