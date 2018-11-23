namespace CaseManager.Resources
{
    public class Animations
    {
        public string AnimationDictionary { get; protected set; }
        public string AnimationName { get; protected set; }
        public float BlendInSpeed { get; protected set; }
        public AnimationFlags AnimationFlag { get; protected set; }

        public Animations(string animDict, string animName, float blendSpeed = 3f, AnimationFlags flag = 0)
        {
            AnimationDictionary = animDict;
            AnimationName = animName;
            BlendInSpeed = blendSpeed;
            AnimationFlag = flag;
        }

        public enum AnimationFlags
        {
            None = 0, Loop = 1, StayInEndFrame = 2, UpperBodyOnly = 16, SecondaryTask = 32, 
            Idle = 128, NoSound1 = 512, NoSound2 = 1024, NoSound3 = 2048, DisableRootMotion = 524288,
            RagdollOnCollision = 4194304
        }
    }
}
