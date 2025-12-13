using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WitchGate.Gameplay.Battles.Entities
{
    public class BattleEntityUI : MonoBehaviour
    {
        [field: SerializeField] public Image HpBar;
        [field: SerializeField] public TMP_Text HpMax;
        [field: SerializeField] public TMP_Text CurrentHp;
        private BattleEntity battleEntity;
        
        private void OnLifeUpdate(float percent)
        {
            HpBar.fillAmount = percent;
            CurrentHp.text = battleEntity.CurrentHealth.ToString();
        }

        public virtual void Connect(BattleEntity battleEntity)
        {
            battleEntity.OnDamageTaken += OnLifeUpdate;
            this.battleEntity = battleEntity;
            HpMax.text = battleEntity.MaxHealth.ToString();
            CurrentHp.text = battleEntity.CurrentHealth.ToString();
        }

        public void Disconnect()
        {
            battleEntity.OnDamageTaken -= OnLifeUpdate;
        }
    }
}