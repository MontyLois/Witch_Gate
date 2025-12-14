using System;
using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Entities;

namespace WitchGate.Players
{
    [Serializable]
    public class PlayerProfile
    {
        public Dictionary<Witch, WitchProfile> WitchProfiles { get; private set; }

        public PlayerProfile(BattleWitchProfile velmora, BattleWitchProfile elaris)
        {
            WitchProfiles = new Dictionary<Witch, WitchProfile>();
            WitchProfiles.Add(Witch.Velmora, new WitchProfile(velmora));
            WitchProfiles.Add(Witch.Elaris, new WitchProfile(elaris));
        }

        public void AddCard(CardData cardData, Witch witch)
        {
            WitchProfiles[witch].AddCard(cardData);
        }

        public void RemoveCard(CardProfile cardProfile, Witch witch)
        {
            WitchProfiles[witch].RemoveCard(cardProfile);
        }
        
        public void LevelUpCard(CardProfile cardProfile, Witch witch)
        {
            WitchProfiles[witch].LevelUpCard(cardProfile);
        }

        public CardProfile GetRandomCardProfile(Witch witch)
        {
            return WitchProfiles[witch].GetRandomCardFromDeck();
        }
    }
}