using UnityEngine;

namespace WitchGate.Cards.Collections.UI
{
    public abstract class CardCollectionUI<T> : MonoBehaviour where T : ICard
    {
        private CardCollection<T> current;

        public void Link(CardCollection<T> collection)
        {
            if (current != null)
                Unlink();
            
            current = collection;
            foreach (var card in collection.Cards)
                AddCardUI(card);

            collection.OnCardAdded += AddCardUI;
            collection.OnCardRemoved += RemoveCardUI;
        }

        private void Unlink()
        {
            if(current == null)
                return;
            
            current.OnCardAdded -= AddCardUI;
            current.OnCardRemoved -= RemoveCardUI;
        }

        protected abstract void AddCardUI(T card);

        protected abstract void RemoveCardUI(T obj);
    }
}