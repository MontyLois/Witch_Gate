using Helteix.Tools.UI;
using TMPro;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Cards.Collections;

namespace WitchGate.Gameplay.Cards.Description
{
    public class CardDescriptionUI : UIItem<IGameCard>
    {
        [field: SerializeField] public GameObject CardDescriptionGameObject { get; private set; }
        [field: SerializeField] public TMP_Text DescritpionText { get; private set; }
        [field: SerializeField] public TMP_Text TitleText { get; private set; }
        
        protected override void SyncUI(IGameCard current)
        {
            DescritpionText.text = current.GetDescription();
            TitleText.text = current.GetTitle();
        }

        protected override void ClearUI()
        {
            
        }
    }
}