using System;
using WitchGate.Controllers;

namespace WitchGate.Mission
{
    public class MissionManager
    {
        public void StartMission(EncounterSceneData encounterScene)
        {
            SceneController.Instance.TryAddMEncounterScene(encounterScene);
        }

        public void CompleteMission(EncounterSceneData encounterScene)
        {
            SceneController.Instance.RemoveEncounterScene(encounterScene);
        }
    }
}