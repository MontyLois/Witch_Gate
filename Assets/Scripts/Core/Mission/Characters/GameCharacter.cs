using cherrydev;
using WitchGate.Mission.Data;

namespace WitchGate.Mission
{
    public class GameCharacter
    {
        private CharacterData characterData;
        private EncounterContext lastEncounterContext;

        GameCharacter(CharacterData characterData)
        {
            this.characterData = characterData;
        }
    }
}