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
        private static Dictionary<CardData, List<CardBattleEffectData>> effects;
        
        [RuntimeInitializeOnLoadMethod]
        private static void Load()
        {
            effects = new Dictionary<CardData, List<CardBattleEffectData>>();
            CardBattleEffectData[] loadedEffects = Resources.LoadAll<CardBattleEffectData>("Cards/CombatEffect");
            for (int i = 0; i < loadedEffects.Length; i++)
            {
                CardBattleEffectData battleEffectData = loadedEffects[i];
                if (battleEffectData!=null)
                {
                   if (!effects.TryGetValue(battleEffectData.CardData, out List<CardBattleEffectData> list))
                    {
                        list = new List<CardBattleEffectData>();
                        effects.Add(battleEffectData.CardData, list);
                    }
                    list.Add(battleEffectData);
                }
            }
        }

        public static IEnumerable<CardBattleEffectData> GetEffectsFor(CardData data)
        {
            if (!effects.TryGetValue(data, out var list)) 
                yield break;
            
            foreach (var item in list)
                yield return item;
        }
    }
}