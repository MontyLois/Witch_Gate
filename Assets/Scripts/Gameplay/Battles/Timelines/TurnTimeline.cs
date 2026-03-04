using System;
using System.Collections.Generic;
using Helteix.Tools.UI;
using UnityEngine.Pool;
using WitchGate.Gameplay.Battles.TurnPhases;

namespace WitchGate.Gameplay.Battles.Timelines
{
    public class TurnTimeline : IUIListSource<ITurnAction>
    {
        IEnumerable<ITurnAction> IUIListSource<ITurnAction>.Items => actions;
        
        public event Action<TurnTimeline> OnReorder; 
        public event Action<ITurnAction> ItemAdded;
        public event Action<ITurnAction> ItemRemoved;
        public IReadOnlyList<ITurnAction> Actions => actions;

        private readonly List<ITurnAction> actions;

        public TurnTimeline()
        {
            this.actions = new List<ITurnAction>();
        }

        public bool AddAction(ITurnAction action)
        {
            if (actions.Contains(action))
                return false;
            
            actions.Add(action);
            ItemAdded?.Invoke(action);
            
            Reorder();
            return true;
        }

        public bool RemoveAction(ITurnAction action)
        {
            if (actions.Remove(action))
            {
                ItemRemoved ?.Invoke(action);
                
                Reorder();
                return true;
            }

            return false;
        }

        public void Reorder()
        {
            actions.Sort((a, b) => a.Priority.CompareTo(b.Priority));
            OnReorder?.Invoke(this);
        }

        public void Clear()
        {
            using (ListPool<ITurnAction>.Get(out var list))
            {
                list.AddRange(actions);
                foreach (var action in list)
                    RemoveAction(action);
            }
        }

        public int IndexOf(ITurnAction action) => actions.IndexOf(action);
    }
}