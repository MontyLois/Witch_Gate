using System;
using WitchGate.Controllers;

namespace WitchGate.Mission
{
    public class MissionManager
    {
        public void StartMission(MissionData mission)
        {
            SceneController.Instance.AddMissionScene(mission);
        }

        public void CompleteMission(MissionData mission)
        {
            SceneController.Instance.RemoveMissionScene(mission);
        }
    }
}