using System;
using cherrydev;
using System.Collections.Generic;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Mission.Plannings.Data;

namespace WitchGate.Mission.Plannings
{
    public static class PlanningController
    {
        private static List<Planning> planningsList = new List<Planning>();
        
        public static void Load()
        {
            PlanningData[] planningDatas = GameController.GameDatabase.PlanningDatas;
            foreach (var planningData in planningDatas)
            {
                planningsList.Add(new Planning(planningData));
            }
        }

        public static List<CharacterData> GetAllCharacterPresent()
        {
            List<CharacterData> characterDatas = new List<CharacterData>();
            foreach (var planning in planningsList)
            {
                if (planning.CheckAvailability())
                {
                    characterDatas.Add(planning.CharacterData);
                    Debug.Log(planning.CharacterData.displayName);
                }
                    
            }
            return characterDatas;
        }
    }
}