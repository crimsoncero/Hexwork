using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutLineGrid : MonoBehaviour
{
    public Grid GridData;
    public Vector2Int GridSize;
    public Transform CenterPoint;
    GridManager _grid;
    

    // Update is called once per frame
    void Update()
    {
       
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var cell in _grid.GridWorldPos)
        {
            Gizmos.DrawWireCube(cell, GridData.cellSize);
        }
    }
    private void OnValidate()
    {
        _grid = new GridManager(GridSize, GridData, CenterPoint.position);
    }
}
