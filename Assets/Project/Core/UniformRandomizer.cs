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
            return Random.Range(0,1) < 0.5f;
        }
    }
}