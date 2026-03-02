using System.Collections.Generic;
using System.Linq;
using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Battles.Timelines;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class BattlePhase : IPhase
    {
        public readonly BattleEnemy Enemy;

        public readonly Dictionary<Witch, BattleWitch> BattleWitches;
        public Hand<GameCard>[] PlayedHands { get; private set; }
        public TurnTimeline TurnTimeline { get; private set; }
        
        
        public BattlePhase(BattleEnemy enemy)
        {
            this.Enemy = enemy;
            BattleWitches = new Dictionary<Witch, BattleWitch>();

            
            foreach (var witchProfile in GameController.GameDatabase.PlayerProfile.WitchProfiles)
            {
                BattleWitches.Add(witchProfile.Key, new BattleWitch(witchProfile.Value));
            }
            
            TurnTimeline = new();

            PlayedHands = new Hand<GameCard>[GameController.Metrics.MaxPlayedHandSize];
            for (int i = 0; i < GameController.Metrics.MaxPlayedHandSize; i++)
            {
                PlayedHands[i] = new Hand<GameCard>();
            }
        }

        public BattleWitch GetBattleWich(Witch witch)
        {
            if (BattleWitches.ContainsKey(witch))
            {
                return BattleWitches[witch];
            }
            return BattleWitches.Values.FirstOrDefault();
        }

        async Awaitable IPhase.OnBegin()
        {
            await SceneController.Instance.LoadGameMode(GameMode.Fight);
        }

        async Awaitable IPhase.Execute()
        {
            foreach (var battleWitch in BattleWitches)
            {
                battleWitch.Value.DrawMissingCards();
            }
            
            while (true)
            {
                TurnTimeline.Clear();
                EnemyTurnPhase enemyTurnPhase = new EnemyTurnPhase(this);
                PlayerTurnPhase playerTurnPhase = new PlayerTurnPhase(this);

                await enemyTurnPhase.DrawPossibleCards();
                
                await playerTurnPhase.RunAsync();
                await enemyTurnPhase.RunAsync();
                
                ResolutionPhase resolutionPhase = new ResolutionPhase(TurnTimeline);
                await resolutionPhase.RunAsync();
                
                if(IsASideDefeated())
                    break;

                using (ListPool<ICanFight>.Get(out List<ICanFight> list))
                {
                    list.AddRange(TargetRegistry.Targets);
                    foreach (var target in list)
                    {
                        target.OnEndTurn();
                    }
                }
            }
        }

        private bool IsASideDefeated() => EnemiesDefeated()||PlayerDefeated();

        private bool EnemiesDefeated() => Enemy.CurrentHealth <= 0;

        private bool PlayerDefeated() => GetBattleWich(Witch.Elaris).CurrentHealth <= 0 &&
                                         GetBattleWich(Witch.Velmora).CurrentHealth <= 0;

        async Awaitable IPhase.OnEnd()
        {
            TargetRegistry.ClearRegistry();
        }

        public List<GameCard> GetAllPlayedCards()
        {
            List<GameCard> playedCards = new List<GameCard>();
            foreach (var playedHand in PlayedHands)
            {
                if (playedHand.TryGetCard(0, out GameCard card))
                {
                    playedCards.Add(card);
                }
            }
            return playedCards;
        }
    }
}