using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Cards.Collections;
using WitchGate.Gameplay.Cards.Effects;
using WitchGate.VisualNovel.Visual_Novel.Cards.Data;

namespace WitchGate.VisualNovel.Visual_Novel.Cards
{
    public static class VNCardManager
    {
        
        private static Dictionary<CardData, List<CardVNEffectData>> effects;
        private static Dictionary<CharacterData, VisionCharacterData> visions;
        
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
            
            visions = new Dictionary<CharacterData, VisionCharacterData>();
            VisionCharacterData[] loadVisions = Resources.LoadAll<VisionCharacterData>("VN/Visions");
            for (int i = 0; i < loadVisions.Length; i++)
            {
                visions.TryAdd(loadVisions[i].CharacterData, loadVisions[i]);
            }
        }
        
        public static IEnumerable<CardVNEffectData> GetEffectsFor(CardData data)
        {
            if (!effects.TryGetValue(data, out var list)) 
                yield break;
            
            foreach (var item in list)
                yield return item;
        }

        public static Sprite GetVisionFor(CharacterData data, CardType cardType)
        {
            if (!visions.TryGetValue(data, out var vision)) 
                return null;
            else
            {
                return vision.GetSprite(cardType);
            }
        }
    }
}