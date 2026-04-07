using System;
using System.Linq;
using cherrydev;
using UnityEngine;
using WitchGate.Cards.Collections;
using WitchGate.Controllers;
using WitchGate.VisualNovel.Visual_Novel.Cards;

namespace WitchGate.Prototype
{
    public class TestimonyPhase : IPhase
    {
        
        public VNWitch VnWitch { get; private set; }
        public CharacterData CurrentClient { get; private set; }
        public bool IsReady { get; private set; }

        public Action<CharacterData, CardType> CardUsed;

        public TestimonyPhase(Witch witch, CharacterData currentClient)
        {
            VnWitch = new VNWitch(GameController.GameDatabase.PlayerProfile.WitchProfiles[witch]);
            CurrentClient = currentClient;
        }
        async Awaitable IPhase.OnBegin()
        {
            IsReady = false;
        }

        async Awaitable IPhase.Execute()
        {
            VnWitch.DrawMissingCards();
            
            while (!IsReady)
                await Awaitable.NextFrameAsync();
        }

        async Awaitable IPhase.OnEnd()
        {
            
        }
        
        public void SetReady()
        {
            IsReady = true;
        }

        public void UseCard(VNCard card)
        {
            card.Use();
            VnWitch.Discard.TryAddCard(card);
            CardUsed?.Invoke(CurrentClient, card.Data.CardType);
        }
    }
}