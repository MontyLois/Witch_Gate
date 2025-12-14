using System;
using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Entities;

namespace WitchGate.Players
{
    [Serializable]
    public struct PlayerProfile
    {
        public Dictionary<Witch, WitchProfile> WitchProfiles { get; private set; }

        public PlayerProfile(BattleWitchProfile velmora, BattleWitchProfile elaris)
        {
            WitchProfiles = new Dictionary<Witch, WitchProfile>();
            WitchProfiles.Add(Witch.Velmora, new WitchProfile(velmora));
            WitchProfiles.Add(Witch.Elaris, new WitchProfile(elaris));
        }
        
    }
}