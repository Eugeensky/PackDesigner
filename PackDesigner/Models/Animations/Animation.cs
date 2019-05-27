namespace PackDesigner.ObjectModels.Animations
{
    public abstract class Animation
    {
        public string TargetType { get; set; }
        public int Delay { get; set; }
        public int Time { get; set; }
        public string Easing { get; set; }
    }
}