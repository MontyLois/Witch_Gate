using System.Collections.Generic;
using WitchGate.Controllers;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers.LocationLayouts;

namespace WitchGate
{
    public class GameDatabase
    {
        public GameModeLayoutData[] GameModeLayouts { get; private set; }
        public LocationLayoutData[] LocationLayouts { get; private set; }

        private readonly Dictionary<string, CardData> cards;
        public IReadOnlyDictionary<string, CardData> Cards => cards;

        public GameDatabase()
        {
            GameModeLayouts = Resources.LoadAll<GameModeLayoutData>("GameModeLayouts");
            LocationLayouts = Resources.LoadAll<LocationLayoutData>("LocationLayouts");
            CardData[] c = Resources.LoadAll<CardData>("Cards/Datas");
            cards = new Dictionary<string, CardData>(c.Length);
            for (int i = 0; i < c.Length; i++)
            {
                var data = c[i];
                cards.TryAdd(data.ID, data);
            }
        }


        public bool TryGetCard(string id, out CardData cardData) => cards.TryGetValue(id, out cardData);
    }
}