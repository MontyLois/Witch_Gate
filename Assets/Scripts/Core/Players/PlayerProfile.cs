using System;
using UnityEngine;

namespace WitchGate.Players
{
    [Serializable]
    public struct PlayerProfile
    {
        [field: SerializeField]
        public WitchProfile VelmoraProfile { get; private set; }
        [field: SerializeField]
        public WitchProfile ElarisProfile { get; private set; }
        
    }
}