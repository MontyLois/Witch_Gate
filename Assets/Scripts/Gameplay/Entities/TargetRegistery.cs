using System.Collections.Generic;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Battles.Entities
{
    public static class TargetRegistry
    {
        private static readonly List<ICanFight> targets = new();
        public static IReadOnlyList<ICanFight> Targets => targets;

        public static void Register(ICanFight entity) => targets.Add(entity);
        public static void Unregister(ICanFight entity) => targets.Remove(entity);
        public static void ClearRegistry() => targets.Clear();
    }
}