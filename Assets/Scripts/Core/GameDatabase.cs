using System.Collections.Generic;
using WitchGate.Controllers;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers.LocationLayouts;
using WitchGate.Gameplay.Entities;
using WitchGate.Mission.Data;
using WitchGate.Mission.Plannings.Data;
using WitchGate.Players;
using WitchGate.VisualNovel.Visual_Novel.Dialog;

namespace WitchGate
{
    public class GameDatabase
    {
        public GameModeLayoutData[] GameModeLayouts { get; private set; }
        public LocationLayoutData[] LocationLayouts { get; private set; }
        
        [Header("Characters")]
        public VNCharacterData[] VNCharacters { get; private set; }
        private readonly Dictionary<string, CharacterData> characters;
        public IReadOnlyDictionary<string, CharacterData> Characters => characters;

        [Header("Cards")]
        private readonly Dictionary<string, CardData> cards;
        public IReadOnlyDictionary<string, CardData> Cards => cards;
        
        public PlayerProfile PlayerProfile { get; private set; }
        
        [Header("Encounters")]
        private PlanningData[] planningDatas;

        public GameDatabase()
        {
            VNCharacters = Resources.LoadAll<VNCharacterData>("Dialogues/CharactersVN_Datas");
            GameModeLayouts = Resources.LoadAll<GameModeLayoutData>("SceneManagment/GameModeLayouts");
            LocationLayouts = Resources.LoadAll<LocationLayoutData>("SceneManagment/LocationLayouts");
            CardData[] c = Resources.LoadAll<CardData>("Cards/Datas");
            cards = new Dictionary<string, CardData>(c.Length);
            for (int i = 0; i < c.Length; i++)
            {
                var data = c[i];
                cards.TryAdd(data.ID, data);
            }

            CharacterData[] cD = Resources.LoadAll<CharacterData>("Characters/Datas");
            this.characters = new Dictionary<string, CharacterData>();
            for (int i = 0; i < cD.Length; i++)
            {
                characters.TryAdd(cD[i].id, cD[i]);
            }

            planningDatas = Resources.LoadAll<PlanningData>("Plannings");

            //Sisters decks
            BattleWitchProfile Elaris = Resources.Load<BattleWitchProfile>("Cards/BattleProfiles/Witches/Elaris");
            BattleWitchProfile Velmora = Resources.Load<BattleWitchProfile>("Cards/BattleProfiles/Witches/Velmora");
            PlayerProfile = new PlayerProfile(Velmora, Elaris);
        }


        public bool TryGetCard(string id, out CardData cardData)
        {
            return cards.TryGetValue(id, out cardData);
        }
    }
}