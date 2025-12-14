using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Controllers;
using WitchGate.Gameplay;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Controller;
using WitchGate.Gameplay.Entities;
using WitchGate.Players;

namespace WitchGate.Prototype
{
    public class Monster : MonoBehaviour
    {
        [field: SerializeField]
        private GameObject sprite;

        [field: SerializeField]
        private PlayerProfile playerProfile;
        [field: SerializeField]
        private BattleProfile enemyProfile;
        
        private void OnTriggerEnter(Collider other)
        {
            sprite.SetActive(true);
            ExplorationGameplayManager.Instance.LockPlayerMovement();
            StartCoroutine(WaitToSwapScene());
            StartBattle();
        }
        

        private IEnumerator WaitToSwapScene()
        {
            yield return new WaitForSeconds(1);
        }

        private void StartBattle()
        {
            BattlePhase phase = new BattlePhase(new BattleEnemy(enemyProfile), playerProfile);
            phase.Run();
        }
    }
}
