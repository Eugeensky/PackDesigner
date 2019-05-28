using System.Collections.Generic;

namespace PackDesigner.ObjectModels
{
    public class Panel
    {
        public string PanelId { get; set; }
        public string PanelName { get; set; }
        public float HingeOffset { get; set; }
        public float PanelWidth { get; set; }
        public float PanelHeight { get; set; }
        public int AttachedToSide { get; set; }
        public List<Panel> AttachedPanels { get; set; }

    }
}
