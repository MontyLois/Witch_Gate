using System;
using WitchGate.Controllers;

namespace WitchGate.Mission
{
    public class MissionManager
    {
        public void StartMission(MissionSceneData missionScene)
        {
            SceneController.Instance.AddMissionScene(missionScene);
        }

        public void CompleteMission(MissionSceneData missionScene)
        {
            SceneController.Instance.RemoveMissionScene(missionScene);
        }
    }
}