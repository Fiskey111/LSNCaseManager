﻿using System.Collections.Generic;
using CaseManager.Resources;

namespace CaseManager.CaseData
{
    public class EntityData : IData
    {
        // IData
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        // String
        public string Description { get; set; }
        public string Scenario { get; set; }
        public string Model { get; set; }
        public string WeaponName { get; set; } // Suspect
        public string ReportID { get; set; } // EMS + Coroner

        // Spawnpoint
        public SpawnPoint Spawn { get; set; }
        public SpawnPoint WitnessPickupPosition { get; set; } // Witness

        // Dialogue
        public List<DialogueLine> Dialogue { get; set; } = new List<DialogueLine>();

        // Float
        public float SuspectChanceResisting { get; set; } // Suspect

        // Boolean
        public bool WitnessIsCompliant { get; set; } // Wit
        public bool FirstOfficerIsImportant { get; set; } // FO
        public bool FirstOfficerCanBeInspected { get; set; } // FO
        public bool ServicesSpawnAtScene { get; set; } // EMS + Coroner
        public bool ParamedicsTransportToHospital { get; set; } // EMS
        public bool IsCollected { get; set; } // EMS + Coroner
        
        //Enums
        public enum EntityDataType { FirstOfficer, Witness, Suspect, Interrogation, EMS, Coroner }
        public EntityDataType Type { get; set; }
    }
}
