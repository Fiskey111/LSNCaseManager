using System;

namespace CaseManager.CaseData
{
    public class EvidenceData : IData // Used for docs and evidence
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        
        public DateTime TimeCollected { get; set; }
        public DateTime TimeDone { get; set; }
        public bool SeenByPlayer { get; set; }
    }
}