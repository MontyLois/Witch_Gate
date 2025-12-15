using TMPro;
using UnityEngine;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewSeekTruthEffect", menuName = "WitchGate/Cards/Effects/VN/SeekTruth", order = 0)]
    public class SeekTruthCardVNEffectData : CardVNEffectData
    {
        
        protected override void ApplyEffect(TMP_Text text)
        {
            text.text = vision;
        }
    }
}