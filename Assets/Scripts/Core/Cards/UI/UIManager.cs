using System;
using WitchGate.Cards.Collections;

namespace WitchGate.Gameplay.Cards.UI
{
    public static class UIManager
    {
        public static event Action<IDescription> OnCardHovered ;
        public static event Action OnCardUnhovered ;

        public static void TriggerOnCardHovered(IDescription description) => OnCardHovered?.Invoke(description);

        public  static void TriggerOnCardUnhovered() => OnCardUnhovered?.Invoke();
    }
}