using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AMGOLCore;

public class GridVisualizer : MonoBehaviour
{

    [SerializeField]
    private GameObject cell_template;

    [SerializeField]
    private Vector2 cell_size;

    private GameObject[,] _cells;

    private Vector2Int _size;

    private RegularGrid _grid;

    public void InitializeGrid(RegularGrid grid)
    {
        _size = grid.GetSize();
        _grid = grid;
        _cells = new GameObject[_size.x,_size.y];
        Vector2 offset = new Vector2(-cell_size.x*_size.x/2,-cell_size.y*_size.y/2);
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                Vector3 position = new Vector3(cell_size.x*x + offset.x,0,cell_size.y*y + offset.y);
                GameObject go = Instantiate(cell_template, position, Quaternion.identity);
                go.transform.parent = transform;
                _cells[x,y] = go;
                _cells[x,y].SetActive(false);
            }
        }
    }

    public void Redraw()
    {
        int [,] grid = _grid.GetGrid();
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                _cells[x,y].SetActive(grid[x,y]==1);
            }
        }
    }
}
