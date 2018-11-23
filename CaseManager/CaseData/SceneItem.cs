using CaseManager.Resources;

namespace CaseManager.CaseData
{
    public class SceneItem
    {
        public SceneItem() {}
        
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
        public enum Type { Object, Ped, Vehicle }
        public Type ItemType { get; set; }
    }
}