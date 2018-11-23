using System.Collections.Generic;
using CaseManager.Resources;

namespace CaseManager.CaseData
{
    public class SceneData : IData
    {
        // IData
        public string ID { get; set; }
        public string Name { get; set; } // Not Needed
        public string DataType { get; set; }
        
        // SceneItems
        public List<SceneItem> Items { get; set; }
    }
}
