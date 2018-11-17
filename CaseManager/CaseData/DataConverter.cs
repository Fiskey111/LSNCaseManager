using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Rage;

namespace CaseManager.CaseData
{
    public class DataConverter
    {
        private string FilePath { get; }
        private dynamic FileData { get; }
        
        public DataConverter(string path)
        {
            Game.Console.Print($"DataConverter({path})");
            if (!File.Exists(path)) return;
            FilePath = path;
            
            dynamic value = JsonConvert.DeserializeObject<dynamic>(FilePath);

            FileData = value;
        }
        
        public object ConvertToObject()
        {
            Game.Console.Print($"DataConverter.ConvertToObject()");

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

        private Type GetTypeFromData()
        {
            Game.Console.Print($"DataConverter.GetTypeFromData()");
            Type checkType = (Type) Type.GetType(Convert.ToString(FileData.DataType));
            return checkType;
        }
    }
}