﻿using LtFlash.Common;

namespace CaseManager.CaseData
{
    public class SceneData : IData
    {
        // IData
        public string ID { get; set; }
        public string Name { get; set; } // Not Needed
        public string DataType { get; set; }

        // String
        public string Model { get; set; }
        public string Scenario { get; set; } // Ped

        // Spawnpoint
        public SpawnPoint Spawn { get; set; }
        
        // Bool
        public bool ActivateWhenNear { get; set; } // Ped
        public bool IsSirenOn { get; set; } // Vehicle
        public bool IsSirenSilent { get; set; } // Vehicle

        // Animation
        public Resources.Animations Animation { get; set; } // Ped

        // Enum
        public enum SceneDataType { SceneMedicalExaminer, Scene }
        public enum SceneItem { Object, Ped, Vehicle }
        public SceneDataType Type { get; set; }
        public SceneItem ItemType { get; set; }
    }
}
