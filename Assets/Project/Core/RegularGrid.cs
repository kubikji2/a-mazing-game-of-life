using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMGOLCore
{
    public class RegularGrid : AGrid
    {

        private Vector2Int _size;

        private bool _is_continous;

        private int _neigbors_count;

        private List<Vector2Int> _offsets = new List<Vector2Int>();

        private List<ATile> _tiles = new List<ATile>();

        private int[,] _grid;

        private RegularTile[,] _tile_grid;

        public RegularGrid(Vector2Int size, int neigbors = 8, bool is_continous = false)
        {
            this._size = size;
            this._is_continous = is_continous;
            this._neigbors_count = neigbors;
            _ProcessOffests();

            this._grid = new int[size.x,size.y];
            this._tile_grid = new RegularTile[size.x,size.y];

            _PopulateGrid();
        }

        private void _ProcessOffests()
        {
            // default setting is 4-neighborhood
            Vector2Int[] neight4 = {new Vector2Int(-1,0),new Vector2Int(1,0), new Vector2Int(0,-1), new Vector2Int(0,1)};
            this._offsets.AddRange(neight4);

            // in case of hexagonal (and 8-neightborhood) grid, left diagonal positions are added
            if (this._neigbors_count > 4)
            {
                this._offsets.Add(new Vector2Int(-1,1));
                this._offsets.Add(new Vector2Int(-1,-1));
            }
            // in case of 8-neigborhood, right diagonal positions are added too
            if (this._neigbors_count > 6)
            {
                this._offsets.Add(new Vector2Int(1,1));
                this._offsets.Add(new Vector2Int(1,-1));
            }
        }

        private void _PopulateGrid()
        {
            for(int y = 0; y < this._size.y; y++)
            {
                for (int x = 0; x < this._size.x; x++)
                {
                    RegularTile tile = new RegularTile(new Vector2Int(x,y), this);
                    _tile_grid[x,y] = tile;
                    _tiles.Add((ATile) tile);
                }
            }
        }


        public List<RegularTile> GetNeighborsOf(Vector2Int coord)
        {
            List<RegularTile> ret = new List<RegularTile>();
            if (this._IsInGrid(coord))
            {
                foreach(Vector2Int neigh in GetNeighborCoords(coord))
                {
                    if(_IsInGrid(neigh))
                    {
                        ret.Add(this._tile_grid[neigh.x,neigh.y]);
                    }
                }
            }
            return ret;
        }

        private bool _IsInGrid(Vector2Int coord)
        {
            return 0 <= coord.x && coord.x < this._size.x && 0 <= coord.y && coord.y < this._size.y;
        }

        private List<Vector2Int> GetNeighborCoords(Vector2Int center)
        {
            List<Vector2Int> coords = new List<Vector2Int>();
            foreach (Vector2Int offset in this._offsets)
            {
                coords.Add(center + offset);
            }
            return coords;
        }

        public void PrintNeighCount()
        {
            string s = "";
            for(int y = this._size.y-1; y >= 0; y--)
            {
                for(int x = 0; x < this._size.x; x++)
                {
                    s += string.Format("{0:d} ", GetNeighborsOf(new Vector2Int(x,y)).Count);
                }
                s += "\n";
            }
            Debug.Log(s);            
        }

        // OVERRIDED
        public override void PrintGrid()
        {
            string s = "";
            for(int y = this._size.y-1; y >= 0; y--)
            {
                for(int x = 0; x < this._size.x; x++)
                {
                    s += string.Format("{0:d} ", this._grid[x,y]);
                }
                s += "\n";
            }
            Debug.Log(s);   
        }

        public override void InitializeGrid(ARandomizer randomizer)
        {
            for (int y = 0; y < _size.y; y++)
            {
                for (int x = 0; x < _size.x; x++)
                {
                    _grid[x,y] = randomizer.IsAlive() ?  1 : 0;
                }
            }
        }

        // OVERRIDED
        public override List<ATile> GetTiles()
        {
            return this._tiles;
        }
        
        // OVERRIDED
        public override void UpdateGrid(ARule rule)
        {
            throw new System.NotImplementedException();
        }

    }

}
