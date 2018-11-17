using System;
using System.Xml.Serialization;

namespace CaseManager.Resources
{
    [Serializable]
    public class DialogueLine
    {
        [XmlAttribute("PedID")]
        public int PedId { get; }
        public string Text { get; }

        public DialogueLine() {}

        public DialogueLine(int pedId, string txt)
        {
            PedId = pedId;
            Text = txt;
        }
    }
}
