using System;
using cherrydev;
using UnityEngine;
using UnityEngine.UI;
using WitchGate.Cards.Collections;
using WitchGate.Controllers;

namespace WitchGate.VisualNovel.Visual_Novel.Cards.UI
{
    public class VisionUI : MonoBehaviour, IPhaseListener<TestimonyPhase>
    {
        [field: SerializeField]
        public Image visionSprite {get; private set;}
        [field: SerializeField]
        public ToogleUI Vision { get; private set; }

        private TestimonyPhase phase;

        public void OnVision(CharacterData characterData, CardType cardType)
        {
            visionSprite.sprite = VNCardManager.GetVisionFor(characterData, cardType);
            Vision.Toogle();
        }

        public void CloseVision()
        {
            Vision.Toogle();
        }

        public void OnPhaseBegins(TestimonyPhase phase)
        {
            this.phase = phase;
            phase.CardUsed += OnVision;
        }

        public void OnPhaseEnds(TestimonyPhase phase)
        {
            phase.CardUsed -= OnVision;
            this.phase = null;
        }

        private void OnDisable()
        {
            phase.CardUsed -= OnVision;
        }
    }
}