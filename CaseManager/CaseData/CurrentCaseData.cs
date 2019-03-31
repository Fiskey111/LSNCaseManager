using System.Collections.Generic;

namespace CaseManager.CaseData
{
    public class CurrentCaseData : IData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        
        public int CaseNo;
        public bool Finished;

        public string LastStageID;
        public List<string> StagesPassed = new List<string>();
        public List<string> NextScripts = new List<string>();
        
        public List<string> Victims = new List<string>();
        public List<string> Officers = new List<string>();
        public List<string> WitnessesInterviewed = new List<string>();

        public List<string> DialogsPassed = new List<string>();
        public List<string> InterrogationsPassed = new List<string>();

        public List<string> ReportsReceived = new List<string>();
        public List<string> NotesMade = new List<string>();

        public List<string> SuspectsArrested = new List<string>();
        public List<string> SuspectsKilled = new List<string>();

        public List<string> PersonsTalkedTo = new List<string>();

        public List<EvidenceData> CollectedEvidenceAndDocs = new List<EvidenceData>();
    }
}