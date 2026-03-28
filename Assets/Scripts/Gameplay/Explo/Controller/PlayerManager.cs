using System;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [field: SerializeField]
        public PlayerMovement Movement { get; private set; }
        [field: SerializeField]
        public PlayerBody Body { get; private set; }

        private void Start()
        {
            Body.setCanMove(true);
        }
    }
}