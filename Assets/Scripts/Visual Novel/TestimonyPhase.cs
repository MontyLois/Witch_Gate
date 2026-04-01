using System.Linq;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.VisualNovel.Visual_Novel.Cards;

namespace WitchGate.Prototype
{
    public class TestimonyPhase : IPhase
    {
        
        public VNWitch VnWitch { get; private set; }
        public bool IsReady { get; private set; }

        public TestimonyPhase(Witch witch)
        {
            VnWitch = new VNWitch(GameController.GameDatabase.PlayerProfile.WitchProfiles[witch]);
            Debug.Log(VnWitch.Deck.Cards.Count());
        }
        async Awaitable IPhase.OnBegin()
        {
            IsReady = false;
        }

        async Awaitable IPhase.Execute()
        {
            VnWitch.DrawMissingCards();
            VnWitch.DrawCard();
            
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
    }
}