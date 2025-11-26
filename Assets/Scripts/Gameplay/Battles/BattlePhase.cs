using System.Collections.Generic;
using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class BattlePhase : IPhase
    {
        public readonly IBattleEnemy Enemy;
        public readonly BattleWitch Velmora;
        public readonly BattleWitch Elaris;
        
        public GameModeLayoutData GameModeLayoutData { get; private set; }

        private List<int> additionalLoadedScenesBeforeBattle;
        private int mainLoadedSceneBeforeBattle;
        
        public BattlePhase(IBattleEnemy enemy, PlayerProfile playerProfile)
        {
            this.Enemy = enemy;
            Velmora = new BattleWitch(playerProfile.VelmoraProfile);
            Elaris = new BattleWitch(playerProfile.ElarisProfile);
        }

        async Awaitable IPhase.OnBegin()
        {
            additionalLoadedScenesBeforeBattle = new();
            var activeScene = SceneManager.GetActiveScene();
            mainLoadedSceneBeforeBattle = activeScene.buildIndex;
            for (int i = 0; i < SceneManager.loadedSceneCount; i++)
            {
                Scene sceneAt = SceneManager.GetSceneAt(i);
                if(sceneAt == activeScene)
                    continue;
                
                additionalLoadedScenesBeforeBattle.Add(sceneAt.buildIndex);
            }
            
            await SceneManager.LoadSceneAsync(GameController.Metrics.BattleScenePath);
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
            
            await SceneManager.LoadSceneAsync(mainLoadedSceneBeforeBattle);
            foreach (var index in additionalLoadedScenesBeforeBattle)
                await SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            
        }
    }
}