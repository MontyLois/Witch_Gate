using UnityEngine;
using WitchGate.Controllers;
using WitchGate.VisualNovel.Visual_Novel.Cards.UI;

namespace WitchGate.Prototype.UI
{
    public class TestimonyPhaseUI : MonoPhaseListener<TestimonyPhase>
    {
        private TestimonyPhase testimonyPhase;
        
        [field: SerializeField] public VNPlayedHandUI CardDropZone { get; private set; }
        [field: SerializeField] public GameObject Hand { get; private set; }
        
        protected override void OnPhaseBegins(TestimonyPhase phase)
        {
            this.Register();
            testimonyPhase = phase;
        }

        protected override void OnPhaseEnds(TestimonyPhase phase)
        {
            this.Unregister();
            testimonyPhase = null;
        }
    }
}