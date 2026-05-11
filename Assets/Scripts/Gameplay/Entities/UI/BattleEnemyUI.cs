using UnityEngine;
using UnityEngine.UI;

namespace WitchGate.Gameplay.Entities.UI
{
    public class BattleEnemyUI : BattleEntityUI
    {
        [field: SerializeField] public Image somethinglikeintentions;
        
        public void Connect(BattleEnemy battleEnemy)
        {
            base.Connect(battleEnemy);
        }
    }
}