using UnityEngine;

namespace WitchGate.Gameplay.Cards
{
    public interface ICardAnimator
    {
        Awaitable OnAttack();
    }
}