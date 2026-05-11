using System.Collections;
using UnityEngine;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Entities;
using WitchGate.Profiles.Data;

namespace WitchGate.Gameplay.Explo.NightEvent
{
    public class FightTrigger : MonoBehaviour
    {
        [field: SerializeField]
        private Animator animator;
        
        [field: SerializeField]
        private BattleProfile enemyProfile;
        
        private void OnTriggerEnter(Collider other)
        {
            ExplorationGameplayManager.Instance.LockPlayerMovement();
            StartCoroutine(WaitAnimation());
        }
        
        private IEnumerator WaitAnimation()
        {
            animator.SetTrigger("Apparition");
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);
            StartBattle();
        }

        
        //Would be great to bind it to some dialog and be happy
        private void StartBattle()
        {
            BattleController.StartBattle(enemyProfile);
        }
    }
}
