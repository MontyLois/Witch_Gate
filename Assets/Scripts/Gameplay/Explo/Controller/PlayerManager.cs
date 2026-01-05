using System;
using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerManager : MonoBehaviour
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