using System;
using UnityEngine;
using WitchGate.Gameplay.Entities;

namespace WitchGate.Players
{
    [Serializable]
    public struct PlayerProfile
    {
        [field: SerializeField]
        public WitchProfile VelmoraProfile { get; private set; }
        [field: SerializeField]
        public WitchProfile ElarisProfile { get; private set; }
        
        [field: SerializeField]
        public BattleWitchProfile VelmoraBattleProfile { get; private set; }
        [field: SerializeField]
        public BattleWitchProfile ElarisBattleProfile { get; private set; }
        
    }
}