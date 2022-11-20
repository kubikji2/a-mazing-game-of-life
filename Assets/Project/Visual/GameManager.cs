using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AMGOLCore;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this._Test();
    }

    private void _Test()
    {
        RegularGrid grid = new RegularGrid(new Vector2Int(10,5), 6);
        grid.PrintNeighCount();
        grid.InitializeGrid(new UniformRandomizer());
        grid.PrintGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
