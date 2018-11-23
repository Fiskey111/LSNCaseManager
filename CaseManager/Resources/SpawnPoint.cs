namespace CaseManager.Resources
{
    public class SpawnPoint
    {
        public Vector3 Position { get; set; }
        public float Heading { get; set; }
        public Rotator Rotation { get; set; }
        
        public SpawnPoint() { }
    }

    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        
        public Vector3() { }
    }

    public class Rotator
    {
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float Yaw { get; set; }
        
        public Rotator() { }
    }
}