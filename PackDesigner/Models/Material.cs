namespace PackDesigner.ObjectModels
{
    public class Material
    {
        public string Id { get; set; }
        public int Transparency { get; set; }
        public string MaterialType { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ResourceMap { get; set; }
        public float Ambient { get; set; }
        public string AmbientColor { get; set; }
        public float Specular { get; set; }
        public int? Gloss { get; set; }
        public int PageNumber { get; set; }
        public string DocumentIdentifier { get; set; }
        public string EmbossMapType { get; set; }
        public string EmbossMap { get; set; }
        public string SpecularMap { get; set; }
        public int ReflectionIntensity { get; set; }
        public string ReflectionMask { get; set; }
        public string ReflectionMapName { get; set; }
        public string Mask { get; set; }
        public bool MirrorMaskOverYAxis { get; set; }
        public bool RenderPanelOutLines { get; set; }
        public bool InvertMask { get; set; }
        public bool MirrorMask { get; set; }
    }
}
