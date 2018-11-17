using System.Collections.Generic;

namespace CaseManager.CaseData
{
    public class CaseProgress : IData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        
        public Dictionary<int, string> AllCases = new Dictionary<int, string>();
    }
}