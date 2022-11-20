using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AMGOLCore
{
    public class RegularTile : ATile
    {
        private List<ATile> _neighbors;

        public RegularTile(Vector2Int position, RegularGrid grid)
        {
            //this._neighbors = (List<ATile>) grid.GetNeighborsOf(position);
        }

        public override bool IsAlive()
        {
            throw new System.NotImplementedException();
        }

        public override List<ATile> GetNeighbors()
        {
            return this._neighbors;
        }

    }
}    

