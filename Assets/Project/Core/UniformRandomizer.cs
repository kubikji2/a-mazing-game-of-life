using UnityEngine;

namespace AMGOLCore
{
    public class UniformRandomizer : ARandomizer
    {
        public UniformRandomizer(int seed = 42)
        {
            Random.InitState(seed);
        }

        public override bool IsAlive()
        {
            return Random.Range(0f,1f) < 0.5f;
        }
    }
}