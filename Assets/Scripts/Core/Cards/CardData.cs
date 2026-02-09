using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 

namespace WitchGate.Cards
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "WitchGate/Cards/Card", order = 0)]
    public class CardData : ScriptableObject
    {
        [field: SerializeField]
        public Witch WitchDeck { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public CardRarity CardRarity { get; private set; }
        [field: SerializeField]
        public Sprite Icon { get; private set; }
        [field: SerializeField]
        public Sprite BG { get; private set; }
        
        [field: SerializeField]
        public int Priority { get; private set; }
        
        [field: SerializeField, HideInInspector]
        public string ID { get; private set; }

#if UNITY_EDITOR
        public void OnValidate()
        {
            if (string.IsNullOrEmpty(ID)|| IsDuplicate(ID))
                ID = Guid.NewGuid().ToString();
            EditorUtility.SetDirty(this);
        }
        
        private bool IsDuplicate(string currentId)
        {
            string path = AssetDatabase.GetAssetPath(this);
            string[] guids = AssetDatabase.FindAssets($"t:{nameof(CardData)}");

            foreach (string guid in guids)
            {
                string otherPath = AssetDatabase.GUIDToAssetPath(guid);
                if (otherPath == path)
                    continue;

                CardData other = AssetDatabase.LoadAssetAtPath<CardData>(otherPath);
                if (other != null && other.ID == currentId)
                    return true;
            }

            return false;
        }
#endif   
        
    }
}