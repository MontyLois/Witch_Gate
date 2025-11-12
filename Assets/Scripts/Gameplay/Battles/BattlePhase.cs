using System.Collections.Generic;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

        private List<int> additionalLoadedScenesBeforeBattle;
        private int mainLoadedSceneBeforeBattle;
        
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
            while (!Keyboard.current.spaceKey.wasPressedThisFrame)
                await Awaitable.NextFrameAsync();
        }

        async Awaitable IPhase.OnEnd()
        {
            await SceneManager.LoadSceneAsync(mainLoadedSceneBeforeBattle);
            foreach (var index in additionalLoadedScenesBeforeBattle)
                await SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            
        }
    }
}