using System.Collections.Generic;
using System.Drawing;
using CaseManager.Resources;

namespace CaseManager.CaseData
{
    public class StageData : IData
    {
        // IData
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        // String
        public string SceneID { get; set; }

        // Int
        public int DelayMinSeconds { get; set; }
        public int DelayMaxSeconds { get; set; }

        // Blip Data
        public CallBlipData BlipData { get; set; }

        // Notification Data
        public CallNotificationData NotificationData { get; set; }

        // Data IDs
        public string[] ID_EntityData { get; set; }
        public string[] ID_CSIData { get; set; }
        public string[] ID_WrittenData { get; set; }
        public string[] ID_SceneData { get; set; }
        public string[] ID_InterrogationData { get; set; }

        // List<string>
        public List<string> NextScript { get; set; }
    }

    public class StageBlipData
    {
        public string BlipName { get; set; }
        public float BlipRadius { get; set; }
        public int AreaRadius { get; set; }
        public Vector3 Position { get; set; }
        public Color BlipColor { get; set; }
        public string BlipSprite { get; set; }
    }

    public class CallNotificationData
    {
        public string TextureDictionary { get; set; }
        public string TextureName { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        
        public CallNotificationData() { }
    }

    public class CallBlipData
    {
        public string Name { get; set; }
        public float Radius { get; set; }
        public string Color { get; set; }
        public int Sprite { get; set; }
        
        public CallBlipData() { }
    }
}
