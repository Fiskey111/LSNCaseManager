using System;
using System.Collections.Generic;
using System.IO;
using CaseManager.CaseData;
using Newtonsoft.Json;

namespace CaseManager.CaseLoader
{
    public class Case
    {
        public Dictionary<string, CaseProgress> Progress { get; private set; }
        public Dictionary<string, CSIData> CSIData { get; private set; }
        public Dictionary<string, CurrentCaseData> CurrentData { get; private set; }
        public Dictionary<string, EntityData> EntityData { get; private set; }
        public Dictionary<string, EvidenceData> EvidenceData { get; private set; }
        public Dictionary<string, InterrogationData> InterrogationData { get; private set; }
        public Dictionary<string, SceneData> SceneData { get; private set; }
        public Dictionary<string, StageData> StageData { get; private set; }
        public Dictionary<string, WrittenData> WrittenData { get; private set; }

        private string[] _fileLocations;

        public Case()
        {
            Progress = new Dictionary<string, CaseProgress>();
            CSIData = new Dictionary<string, CSIData>();
            CurrentData = new Dictionary<string, CurrentCaseData>();
            EntityData = new Dictionary<string, EntityData>();
            EvidenceData = new Dictionary<string, EvidenceData>();
            InterrogationData = new Dictionary<string, InterrogationData>();
            SceneData = new Dictionary<string, SceneData>();
            StageData = new Dictionary<string, StageData>();
            WrittenData = new Dictionary<string, WrittenData>();
        }
        
        public Case(string rootLocation)
        {
            string[] folders = Directory.GetDirectories(rootLocation);
            List<string> caseFiles = new List<string>();
            
            foreach (string folder in folders)
            {
                caseFiles.AddRange(Directory.GetFiles(rootLocation, "*.*", SearchOption.AllDirectories));
            }

            _fileLocations = caseFiles.ToArray();

            Progress = new Dictionary<string, CaseProgress>();
            CSIData = new Dictionary<string, CSIData>();
            CurrentData = new Dictionary<string, CurrentCaseData>();
            EntityData = new Dictionary<string, EntityData>();
            EvidenceData = new Dictionary<string, EvidenceData>();
            InterrogationData =  new Dictionary<string, InterrogationData>();
            SceneData = new Dictionary<string, SceneData>();
            StageData = new Dictionary<string, StageData>();
            WrittenData = new Dictionary<string, WrittenData>();
            
            LoadData();
        }

        /// <summary>
        /// ATTENTION: ONLY FOR USE WITH CASE CREATOR TOOL -- ***DO NOT*** USE IN GAME
        /// </summary>
        /// <param name="location">The save location</param>
        public void SaveData()
        {
            foreach (string loc in Progress.Keys)
            {
                SerializeAndSave(Progress[loc], loc);
            }
            foreach (string loc in CSIData.Keys)
            {
                SerializeAndSave(CSIData[loc], loc);
            }
            foreach (string loc in CurrentData.Keys)
            {
                SerializeAndSave(CurrentData[loc], loc);
            }
            foreach (string loc in EntityData.Keys)
            {
                SerializeAndSave(EntityData[loc], loc);
            }
            foreach (string loc in EvidenceData.Keys)
            {
                SerializeAndSave(EvidenceData[loc], loc);
            }
            foreach (string loc in InterrogationData.Keys)
            {
                SerializeAndSave(InterrogationData[loc], loc);
            }
            foreach (string loc in SceneData.Keys)
            {
                SerializeAndSave(SceneData[loc], loc);
            }
            foreach (string loc in StageData.Keys)
            {
                SerializeAndSave(StageData[loc], loc);
            }
            foreach (string loc in WrittenData.Keys)
            {
                SerializeAndSave(WrittenData[loc], loc);
            }
        }

        private void LoadData()
        {
            foreach (string file in _fileLocations)
            {
                DataGetter data = new DataGetter(file);
                Type t = data.GetTypeFromData();
                
                if (t == typeof(CaseProgress)) Progress.Add(file, (CaseProgress) data.ConvertToObject());
                if (t == typeof(CSIData)) CSIData.Add(file, (CSIData) data.ConvertToObject());
                if (t == typeof(CurrentCaseData)) CurrentData.Add(file, (CurrentCaseData) data.ConvertToObject());
                if (t == typeof(EntityData)) EntityData.Add(file, (EntityData) data.ConvertToObject());
                if (t == typeof(EvidenceData)) EvidenceData.Add(file, (EvidenceData) data.ConvertToObject());
                if (t == typeof(InterrogationData)) InterrogationData.Add(file, (InterrogationData) data.ConvertToObject());
                if (t == typeof(SceneData)) SceneData.Add(file, (SceneData) data.ConvertToObject());
                if (t == typeof(StageData)) StageData.Add(file, (StageData) data.ConvertToObject());
                if (t == typeof(WrittenData)) WrittenData.Add(file, (WrittenData) data.ConvertToObject());
            }
        }

        private void SerializeAndSave(object data, string location)
        {
            string d = JsonConvert.SerializeObject(data);
            File.WriteAllText(location, d);
        }
    }
}