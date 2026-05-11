using TMPro;
using UnityEngine;

namespace WitchGate.VisualNovel.Visual_Novel.Cards.Data.Effect
{
    [CreateAssetMenu(fileName = "NewSeekTruthEffect", menuName = "WitchGate/Decks/Cards/Effects/VN/SeekTruth", order = 0)]
    public class SeekTruthCardVNEffectData : CardVNEffectData
    {
        
        protected override void ApplyEffect(TMP_Text text)
        {
            text.text = vision;
        }
    }
}