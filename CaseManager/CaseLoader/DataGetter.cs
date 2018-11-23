using System;
using System.IO;
using CaseManager.CaseData;
using Newtonsoft.Json;

namespace CaseManager.CaseLoader
{
    public class DataGetter
    {
        private string FilePath { get; }
        private dynamic FileData { get; }
        
        public DataGetter(string path)
        {
            
            if (!File.Exists(path)) return;
            FilePath = path;
            
            dynamic value = JsonConvert.DeserializeObject<dynamic>(FilePath);

            FileData = value;
        }
        
        public object ConvertToObject()
        {
            if (GetTypeFromData() == typeof(CaseProgress)) 
                return (CaseProgress) JsonConvert.DeserializeObject<CaseProgress>(FileData);
            if (GetTypeFromData() == typeof(CSIData)) 
                return (CSIData) JsonConvert.DeserializeObject<CSIData>(FileData);
            if (GetTypeFromData() == typeof(CurrentCaseData)) 
                return (CurrentCaseData) JsonConvert.DeserializeObject<CurrentCaseData>(FileData);
            if (GetTypeFromData() == typeof(EntityData)) 
                return (EntityData) JsonConvert.DeserializeObject<EntityData>(FileData);
            if (GetTypeFromData() == typeof(InterrogationData)) 
                return (InterrogationData) JsonConvert.DeserializeObject<InterrogationData>(FileData);
            if (GetTypeFromData() == typeof(SceneData)) 
                return (SceneData) JsonConvert.DeserializeObject<SceneData>(FileData);
            if (GetTypeFromData() == typeof(StageData)) 
                return (StageData) JsonConvert.DeserializeObject<StageData>(FileData);
            if (GetTypeFromData() == typeof(WrittenData)) 
                return (WrittenData) JsonConvert.DeserializeObject<WrittenData>(FileData);

            return null;
        }

        public Type GetTypeFromData()
        {
            Type checkType = (Type) Type.GetType(Convert.ToString(FileData.DataType));
            return checkType;
        }
    }
}