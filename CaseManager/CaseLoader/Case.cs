using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        
        public int TotalCurrentFiles()
        {
            int files = 0;
            files = files + Progress.Count;
            files = files + CSIData.Count;
            files = files + CurrentData.Count;
            files = files + EntityData.Count;
            files = files + EvidenceData.Count;
            files = files + InterrogationData.Count;
            files = files + SceneData.Count;
            files = files + StageData.Count;
            files = files + WrittenData.Count;
            return files;
        }

        public List<string> GetAllIDs()
        {
            List<string> idList = new List<string>();
            idList.AddRange(Progress.Values.Select(q => q.ID));
            idList.AddRange(CSIData.Values.Select(q => q.ID));
            idList.AddRange(CurrentData.Values.Select(q => q.ID));
            idList.AddRange(EntityData.Values.Select(q => q.ID));
            idList.AddRange(EvidenceData.Values.Select(q => q.ID));
            idList.AddRange(InterrogationData.Values.Select(q => q.ID));
            idList.AddRange(SceneData.Values.Select(q => q.ID));
            idList.AddRange(StageData.Values.Select(q => q.ID));
            idList.AddRange(WrittenData.Values.Select(q => q.ID));
            return idList;
        }

        public int FileCount => _files.Length;
        private readonly string[] _files;

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
            Progress = new Dictionary<string, CaseProgress>();
            CSIData = new Dictionary<string, CSIData>();
            CurrentData = new Dictionary<string, CurrentCaseData>();
            EntityData = new Dictionary<string, EntityData>();
            EvidenceData = new Dictionary<string, EvidenceData>();
            InterrogationData =  new Dictionary<string, InterrogationData>();
            SceneData = new Dictionary<string, SceneData>();
            StageData = new Dictionary<string, StageData>();
            WrittenData = new Dictionary<string, WrittenData>();
            
            _files = Directory.GetFiles(rootLocation, "*.data", SearchOption.AllDirectories);
            
            LoadData();
        }

        private void LoadData()
        {
            foreach (string file in _files)
            {
                if (!File.Exists(file)) continue;
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
        
        /// <summary>
        /// ATTENTION: ONLY FOR USE WITH CASE CREATOR TOOL -- ***DO NOT*** USE IN GAME
        /// </summary>
        public void SaveData(string root)
        {
            foreach (string loc in Progress.Keys)
            {
                SerializeAndSave(Progress[loc], Progress[loc].ID, root);
            }
            foreach (string loc in CSIData.Keys)
            {
                SerializeAndSave(CSIData[loc], CSIData[loc].ID, root);
            }
            foreach (string loc in CurrentData.Keys)
            {
                SerializeAndSave(CurrentData[loc], CurrentData[loc].ID, root);
            }
            foreach (string loc in EntityData.Keys)
            {
                SerializeAndSave(EntityData[loc], EntityData[loc].ID, root);
            }
            foreach (string loc in EvidenceData.Keys)
            {
                SerializeAndSave(EvidenceData[loc], EvidenceData[loc].ID, root);
            }
            foreach (string loc in InterrogationData.Keys)
            {
                SerializeAndSave(InterrogationData[loc], InterrogationData[loc].ID, root);
            }
            foreach (string loc in SceneData.Keys)
            {
                SerializeAndSave(SceneData[loc], SceneData[loc].ID, root);
            }
            foreach (string loc in StageData.Keys)
            {
                SerializeAndSave(StageData[loc], StageData[loc].ID, root);
            }
            foreach (string loc in WrittenData.Keys)
            {
                SerializeAndSave(WrittenData[loc], WrittenData[loc].ID, root);
            }
        }

        private void SerializeAndSave(object data, string id, string root)
        {
            string d = JsonConvert.SerializeObject(data);
            File.WriteAllText($"{root}/{id}.data", d);
        }
    }
}