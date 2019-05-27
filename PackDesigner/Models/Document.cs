using PackDesigner.ObjectModels.Animations;
using System.Collections.Generic;

namespace PackDesigner.ObjectModels
{
    public class Document
    {
        public bool EnableEffects { get; set; }
        public bool DebugMode { get; set; }
        public bool ShowStats { get; set; }
        public bool CalculatePanelCollisions { get; set; }
        public bool AllowMouseInteraction { get; set; }
        public bool AdjustCameraTargetPosition { get; set; }
        public bool FreeCamera { get; set; }
        public int? StartPosition { get; set; }
        public float InitialCameraX { get; set; }
        public float InitialCameraY { get; set; }
        public bool Show3DStats { get; set; }
        public string BackgroundColor { get; set; }
        public float RootX { get; set; }
        public float RootY { get; set; }
        public int OriginalDocumentHeight { get; set; }
        public int OriginalDocumentWidth { get; set; }
        public int InitialCameraRadius { get; set; }
        public string IconSetID { get; set; }
        public bool AutoPlaySequence { get; set; }
        public bool LoopSequence { get; set; }
        public float InitialCameraTargetX { get; set; }
        public float InitialCameraTargetY { get; set; }
        public float InitialCameraTargetZ { get; set; }
        public List<Light> Lights { get; set; }
        public List<Material> Materials { get; set; }
        public Panel Panel { get; set; }
        public List<Animation> Animations { get; set; }
    }
}
