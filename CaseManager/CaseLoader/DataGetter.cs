using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CaseManager.CaseData;
using Newtonsoft.Json;

namespace CaseManager.CaseLoader
{
    public class DataGetter
    {
        private readonly string _fileAsString;
        
        public DataGetter(string path)
        {
            if (!File.Exists(path)) return;
            _fileAsString = File.ReadAllText(path);
        }
        
        public object ConvertToObject()
        {
            if (GetTypeFromData() == typeof(CaseProgress)) 
                return (CaseProgress) JsonConvert.DeserializeObject<CaseProgress>(_fileAsString);
            if (GetTypeFromData() == typeof(CSIData)) 
                return (CSIData) JsonConvert.DeserializeObject<CSIData>(_fileAsString);
            if (GetTypeFromData() == typeof(CurrentCaseData)) 
                return (CurrentCaseData) JsonConvert.DeserializeObject<CurrentCaseData>(_fileAsString);
            if (GetTypeFromData() == typeof(EntityData)) 
                return (EntityData) JsonConvert.DeserializeObject<EntityData>(_fileAsString);
            if (GetTypeFromData() == typeof(InterrogationData)) 
                return (InterrogationData) JsonConvert.DeserializeObject<InterrogationData>(_fileAsString);
            if (GetTypeFromData() == typeof(SceneData)) 
                return (SceneData) JsonConvert.DeserializeObject<SceneData>(_fileAsString);
            if (GetTypeFromData() == typeof(StageData)) 
                return (StageData) JsonConvert.DeserializeObject<StageData>(_fileAsString);
            if (GetTypeFromData() == typeof(WrittenData)) 
                return (WrittenData) JsonConvert.DeserializeObject<WrittenData>(_fileAsString);

            return null;
        }

        /// <summary>
        /// Gets the proper data type from the raw data
        /// </summary>
        /// <returns>DataType</returns>
        public Type GetTypeFromData()
        {
            List<string> splitData = _fileAsString.Split(':').ToList();
            for (int i = 0; i < splitData.Count; i++)
            {
                if (splitData[i].Contains("\"")) splitData[i] = splitData[i].Replace("\"", "");

                if (!splitData[i].Contains(',')) continue;
                
                string[] s = splitData[i].Split(',');
                splitData.RemoveAt(i);
                splitData.InsertRange(i, s);
            }

            // Gets the index of the DataType string :: thus, the actual data type is in the next position
            int dataTypeIndex = splitData.IndexOf("DataType");

            switch (splitData[dataTypeIndex + 1])
            {
                case "CaseProgress":
                    return typeof(CaseProgress);
                case "CSIData":
                    return typeof(CSIData);
                case "CurrentCaseData":
                    return typeof(CurrentCaseData);
                case "EntityData":
                    return typeof(EntityData);
                case "InterrogationData":
                    return typeof(InterrogationData);
                case "SceneData":
                    return typeof(SceneData);
                case "StageData":
                    return typeof(StageData);
                case "WrittenData":
                    return typeof(WrittenData);
                default:
                    return null;
            }
        }
    }
}