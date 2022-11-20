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

        BinaryRule convay_rule = new BinaryRule(new List<int>(new int[] {2,3}),new List<int>(new int[] {3}));
        convay_rule.PrintRule();

        /*
        for(int i = 0; i < 8; i++)
        {
            Debug.Log("ALIVE (" + i + "): " + convay_rule.WillSurvive(true, i));
        }

        for(int i = 0; i < 8; i++)
        {
            Debug.Log("DEAD (" + i + "): " + convay_rule.WillSurvive(false, i));
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
