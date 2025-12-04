using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.Gameplay.Cards
{
    public static class CardManager
    {
        private static Dictionary<CardData, List<CardEffect>> effects;
        
        [RuntimeInitializeOnLoadMethod]
        private static void Load()
        {
            effects = new Dictionary<CardData, List<CardEffect>>();
            CardEffect[] loadedEffects = Resources.LoadAll<CardEffect>("Cards/CombatEffect");
            for (int i = 0; i < loadedEffects.Length; i++)
            {
                CardEffect effect = loadedEffects[i];
                if (effect!=null)
                {
                   if (!effects.TryGetValue(effect.CardData, out List<CardEffect> list))
                    {
                        list = new List<CardEffect>();
                        effects.Add(effect.CardData, list);
                    }
                    list.Add(effect);
                }
            }
        }

        public static IEnumerable<CardEffect> GetEffectsFor(CardData data)
        {
            if (!effects.TryGetValue(data, out var list)) 
                yield break;
            
            foreach (var item in list)
                yield return item;
        }
    }
}