namespace PackDesigner.ObjectModels
{
    public class Light
    {
        public string Id { get; set; }
        public string Name { get; set;}
        public string Type { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Color { get; set; }
        public float Ambient { get; set; }
        public float Diffuse { get; set; }
        public float Specular { get; set; }
        public bool AttachToCamera { get; set; }
        public int FallOff { get; set; }
    }
}
