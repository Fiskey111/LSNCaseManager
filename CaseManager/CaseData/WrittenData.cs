using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace CaseManager.CaseData
{
    public class WrittenData : IData
    {
        // IData
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        // String
        public string To { get; set; }
        public string Text { get; set; }
        
        // String List
        public List<string> EvidenceIDRequiredToRequest { get; set; } = new List<string>();
        public List<string> DialogueIDRequiredToRequest { get; set; } = new List<string>();
        public List<string> ReportIDRequiredToRequest { get; set; } = new List<string>();
        public List<string> StageIDRequiredToRequest { get; set; } = new List<string>();
        public List<string> EvidenceIDRequiredToAccept { get; set; } = new List<string>();
        public List<string> DialogueIDRequiredToAccept { get; set; } = new List<string>();
        public List<string> ReportIDRequiredToAccept { get; set; } = new List<string>();
        public List<string> StageIDRequiredToAccept { get; set; } = new List<string>();

        // Enum
        public enum WrittenDataType { Document, Notes, Reports }
        public WrittenDataType Type { get; set; }
    }
}
