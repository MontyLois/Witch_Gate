using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Cards.Collections;
using WitchGate.Controllers;
using WitchGate.Mission.Dialogs;
using WitchGate.VisualNovel.Visual_Novel.Cards.Data;
using WitchGate.VisualNovel.Visual_Novel.Visions.Data;

namespace WitchGate.VisualNovel.Visual_Novel.Visions
{
    public static class VisionController
    {
        private static List<VisionCharacterData> _visionCharacterDatas = new List<VisionCharacterData>();
        
        public static void Load()
        {
            VisionCharacterData[] visions = Resources.LoadAll<VisionCharacterData>("VN/Visions");
            foreach (var vision in visions)
            {
                _visionCharacterDatas.Add(vision);
            }
        }
        
        public static Sprite GetVisionForSpecificEntity(CharacterData characterData, CardType cardType)
        {
            foreach (var vision in _visionCharacterDatas)
            {
                if (vision.CharacterData == characterData)
                {
                    return vision.GetSprite(cardType);
                }
            }
            return null;
        }
        
    }
}