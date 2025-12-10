using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.VisualNovel.Visual_Novel.Cards
{
    public static class VNCardManager
    {
        
        private static Dictionary<CardData, List<CardVNEffectData>> effects;
        
        [RuntimeInitializeOnLoadMethod]
        private static void Load()
        {
            effects = new Dictionary<CardData, List<CardVNEffectData>>();
            CardVNEffectData[] loadedEffects = Resources.LoadAll<CardVNEffectData>("Cards/VNEffect");
            for (int i = 0; i < loadedEffects.Length; i++)
            {
                CardVNEffectData vnEffectData = loadedEffects[i];
                if (vnEffectData!=null)
                {
                    if (!effects.TryGetValue(vnEffectData.CardData, out List<CardVNEffectData> list))
                    {
                        list = new List<CardVNEffectData>();
                        effects.Add(vnEffectData.CardData, list);
                    }
                    list.Add(vnEffectData);
                }
            }
        }
    }
}