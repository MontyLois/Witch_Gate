using System.Collections.Generic;
using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class BattlePhase : IPhase
    {
        public readonly BattleEnemy Enemy;
        public readonly BattleWitch Velmora;
        public readonly BattleWitch Elaris;
        
        public Hand<GameCard>[] PlayedHands { get; private set; }
        
        
        public BattlePhase(BattleEnemy enemy, PlayerProfile playerProfile)
        {
            this.Enemy = enemy;
            Velmora = new BattleWitch(playerProfile.VelmoraProfile);
            Elaris = new BattleWitch(playerProfile.ElarisProfile);

            PlayedHands = new Hand<GameCard>[GameController.Metrics.MaxPlayedHandSize];
            for (int i = 0; i < GameController.Metrics.MaxPlayedHandSize; i++)
            {
                PlayedHands[i] = new Hand<GameCard>();
            }
        }

        async Awaitable IPhase.OnBegin()
        {
            await SceneController.Instance.LoadGameMode(GameMode.Fight);
        }

        async Awaitable IPhase.Execute()
        {
            while (true)
            {
                PlayerTurnPhase playerTurnPhase = new PlayerTurnPhase(this);

                await playerTurnPhase.RunAsync();
                if(!AreAllAlive())
                    break;

                EnemyTurnPhase enemyTurnPhase = new EnemyTurnPhase(this);
                await enemyTurnPhase.RunAsync();
                
                if(!AreAllAlive())
                    break;
            }
        }

        private bool AreAllAlive() => Enemy.CurrentHealth > 0 && 
                                      Elaris.CurrentHealth > 0 && 
                                      Velmora.CurrentHealth > 0;

        async Awaitable IPhase.OnEnd()
        {
            await SceneController.Instance.LoadGameModeAsync(GameMode.Exploration);
        }
    }
}