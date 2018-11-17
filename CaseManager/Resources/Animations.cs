using Rage;

namespace CaseManager.Resources
{
    public class Animations
    {
        public string AnimationDictionary { get; protected set; }
        public string AnimationName { get; protected set; }
        public float BlendInSpeed { get; protected set; }
        public AnimationFlags AnimationFlag { get; protected set; }

        public Animations(string animDict, string animName, float blendSpeed = 3f, AnimationFlags flag = AnimationFlags.None)
        {
            AnimationDictionary = animDict;
            AnimationName = animName;
            BlendInSpeed = blendSpeed;
            AnimationFlag = flag;
        }
    }
}
