using System;
using System.Text;
using Helteix.Tools.UI;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Battles.Timelines;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Battles.UI;

namespace WitchGate.Gameplay
{
    public class BattleTimelineUI : UIList<ITurnAction, TurnActionUI>, IPhaseListener<BattlePhase>
    {
        public string name;
        public BattleTimelineUI()
        {
        }
        private void OnEnable()
        {
            this.Register();
        }

        private void OnDisable()
        {
            this.Unregister();
        }

        void IPhaseListener<BattlePhase>.OnPhaseBegins(BattlePhase phase)
        {
            Connect(phase.TurnTimeline);
            phase.TurnTimeline.OnReorder += Reorder;
        }


        void IPhaseListener<BattlePhase>.OnPhaseEnds(BattlePhase phase)
        {
            Disconnect();
            phase.TurnTimeline.OnReorder -= Reorder;
        }
        
        
        private void Reorder(TurnTimeline turnTimeline)
        {
            for (int i = 0; i < turnTimeline.Actions.Count; i++)
            {
                ITurnAction action = turnTimeline.Actions[i];
                if (TryGetUIFor(action, out TurnActionUI ui))
                    ui.transform.SetSiblingIndex(i);
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < turnTimeline.Actions.Count; i++)
            {
                builder.Append($"{turnTimeline.Actions[i].Label} is {i} \n");
            }
        }
    }
}
