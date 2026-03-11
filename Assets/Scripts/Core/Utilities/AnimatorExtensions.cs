using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace WitchGate.Utilities
{
    public static class AnimatorExtensions
    {
        public static async Task WaitForAnimation(this Animator animator, string stateName, int layer = 0)
        {
            // Wait until animator enters the state
            while (!animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
                await Task.Yield();

            // Wait until animation finishes
            while (animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1f ||
                   animator.IsInTransition(layer))
                await Task.Yield();
        }
        
    }
}