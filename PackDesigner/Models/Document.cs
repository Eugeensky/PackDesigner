using System.Collections.Generic;

namespace PackDesigner.ObjectModels
{
    public class Document
    {
        public float RootX { get; set; }
        public float RootY { get; set; }
        public float OriginalDocumentHeight { get; set; }
        public float OriginalDocumentWidth { get; set; }
        public Panel Panel { get; set; }
    }
}
