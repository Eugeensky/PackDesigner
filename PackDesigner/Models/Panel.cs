using System.Collections.Generic;

namespace PackDesigner.ObjectModels
{
    public class Panel
    {
        public string PanelId { get; set; }
        public string PanelName { get; set; }
        public int MinRot { get; set; }
        public int MaxRot { get; set; }
        public int InitialRot { get; set; }
        public int StartRot { get; set; }
        public int EndRot { get; set; }
        public float HingeOffset { get; set; }
        public float PanelWidth { get; set; }
        public float PanelHeight { get; set; }
        public int AttachedToSide { get; set; }
        public float CreaseBottom { get; set; }
        public float CreaseTop { get; set; }
        public float CreaseLeft { get; set; }
        public float CreaseRight { get; set; }
        public bool IgnoreCollisions { get; set; }
        public bool MouseEnabled { get; set; }
        public List<Panel> AttachedPanels { get; set; }

    }
}
