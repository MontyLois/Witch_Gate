using UnityEngine;
using UnityEngine.UI;
using WitchGate.Gameplay.Battles.Entities;

namespace WitchGate.Gameplay.Battles.UI
{
    public class BattleEnemyUI : BattleEntityUI
    {
        [field: SerializeField] public Image HpBar;
        
        public void Connect(BattleEnemy battleEnemy)
        {
            base.Connect(battleEnemy);
        }
    }
}