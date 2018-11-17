using LtFlash.Common;

namespace CaseManager.CaseData
{
    public class CSIData : IData
    {
        // IData
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        // String
        public string Description { get; set; }
        public string Model { get; set; }
        public string Traces { get; set; }
        public string DeadBodyObjectAdditionalTextWhileInspecting { get; set; } // DeadBody + Object

        // String[]
        public string[] WitnessIDs { get; set; }
        public string[] ServiceIDs { get; set; }

        // Spawnpoint
        public SpawnPoint Spawn { get; set; }

        // Boolean
        public bool IsImportant { get; set; }
        public bool CanBeInspected { get; set; }
        public bool PlaySoundImportantNearby { get; set; }
        public bool PlaySoundImportantCollected { get; set; }
       
        // Enum
        public enum CSIDataType { DeadBody, Object }
        public CSIDataType Type { get; set; }
    }
}
