using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMGOLCore
{
    public abstract class AGrid
    {
        // Print current grid
        public abstract void PrintGrid();

        // Updates grid using ARule
        public abstract void UpdateGrid(ARule rule);

        // Returns all tiles in the AGrid
        public abstract List<ATile> GetTiles();

        // Computes number of alive neigbors next to the 'tile'
        protected static int GetNumberOfAliveNeighbors(ATile tile)
        {
            return _GetNumberOfNeighbors(tile, true);
        }

        // Computes number of dead neigbors next to the 'tile'
        protected static int GetNumberOfDeadNeighbors(ATile tile)
        {
            return _GetNumberOfNeighbors(tile, false);
        }

        private static int _GetNumberOfNeighbors(ATile tile, bool alive)
        {
            int on_alive = alive ? 1 : 0;
            int on_dead = alive ? 0 : 1;
            int cnt = 0;
            List<ATile> cells = tile.GetNeighbors();
            foreach (ATile cell in cells)
            {
                cnt += cell.IsAlive() ? on_alive : on_dead; 
            }
            return cnt;
        }

    }
}
