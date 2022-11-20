using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMGOLCore
{

    public abstract class ATile
    {
        //public abstract ATile();

        public abstract bool IsAlive();

        public abstract List<ATile> GetNeighbors();

    }
}
