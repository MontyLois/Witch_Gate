using UnityEngine;
using UnityEngine.UI;

namespace WitchGate.Gameplay.Battles.Entities
{
    public class BattleEntityUI : MonoBehaviour
    {
        [field: SerializeField] public Image HpBar;
        private BattleEntity battleEntity;
        
        private void OnLifeUpdate(float percent)
        {
            HpBar.fillAmount = percent;
        }

        public void Connect(BattleEntity battleEntity)
        {
            battleEntity.OnDamageTaken += OnLifeUpdate;
            this.battleEntity = battleEntity;
        }

        public void Disconnect()
        {
            battleEntity.OnDamageTaken -= OnLifeUpdate;
        }
    }
}