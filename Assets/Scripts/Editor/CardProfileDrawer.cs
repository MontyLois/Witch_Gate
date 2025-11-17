using System.Collections.Generic;
using Helteix.Tools.Editor.Serialisation;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using WitchGate.Cards;
using WitchGate.Players;

namespace WitchGate.Editor
{
    [CustomPropertyDrawer(typeof(CardProfile))]
    public class CardProfileDrawer : PropertyDrawer
    {

        private static readonly Dictionary<string, CardData> Cards = new();

        [InitializeOnLoadMethod]
        private static void Load()
        {
            string[] assetsGuids = AssetDatabase.FindAssets($"t:{nameof(CardData)}");
            for (int i = 0; i < assetsGuids.Length; i++)
            {
                string guid = assetsGuids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);

                CardData cardData = AssetDatabase.LoadAssetAtPath<CardData>(path);
                Cards.Add(cardData.ID, cardData);
            }
        }
        
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement()
            {
                style =
                {
                    flexDirection = FlexDirection.Column,
                }
            };

            SerializedProperty levelProperty = property.FindBackingFieldPropertyRelative(nameof(CardProfile.Level));
            PropertyField propertyField = new PropertyField(levelProperty);

            SerializedProperty idProperty = property.FindBackingFieldPropertyRelative(nameof(CardProfile.CardID));
            ObjectField dataField = new ObjectField("Card Data")
            {
                objectType = typeof(CardData),
                allowSceneObjects = false,
            };
            string currentID = idProperty.stringValue;
            if (Cards.TryGetValue(currentID, out CardData cardData))
                dataField.value = cardData;

            dataField.RegisterValueChangedCallback(changeEvent =>
            {
                Object newValue = changeEvent.newValue;
                if (newValue is CardData newCardData)
                {
                    idProperty.stringValue = newCardData.ID;
                    //TRES IMPORTANT
                    idProperty.serializedObject.ApplyModifiedProperties();
                }
            });
            root.Add(propertyField);
            root.Add(dataField);
            return root;
        }
    }
}
