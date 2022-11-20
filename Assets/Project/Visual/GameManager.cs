using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AMGOLCore;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GridVisualizer _grid_visualizer;

    private BinaryRule _rule;

    private RegularGrid _grid;

    // Start is called before the first frame update
    void Start()
    {
        _InitGrid();

        InvokeRepeating(nameof(_UpdateGrid), 0.01f, 0.25f);
    }

    private void _InitGrid()
    {
        _grid = new RegularGrid(new Vector2Int(200,100), 6);
        //_grid.PrintNeighCount();
        _grid.InitializeGrid(new UniformRandomizer());

        _grid_visualizer.InitializeGrid(_grid);

        _rule = new BinaryRule(new List<int>(new int[] {2,3}),new List<int>(new int[] {3}));

    }

    private void _UpdateGrid()
    {
        _grid.UpdateGrid(_rule);
        //_grid.PrintGrid();
        _grid_visualizer.Redraw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
