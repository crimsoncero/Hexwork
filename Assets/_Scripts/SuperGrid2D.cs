using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent( typeof(Grid))]
public class SuperGrid2D : MonoBehaviour
{
    [SerializeField] private Grid _grid;

    [field: Header("Grid Settings")]
    
    [field: SerializeField]
    public Vector3 CellSize {  get; set; }
    [field: SerializeField]
    public Vector3 CellGap {  get; set; }

    [field: Space]
    [field: SerializeField]
    public int Rows { get; private set; }
    [field: SerializeField]
    public int Columns { get; private set; }

    [SerializeField] private bool _showGizmo = true;


    public float CellWidth { get { return _grid.cellSize.x; } }
    public float CellHeight { get { return _grid.cellSize.y; } }
    public float XGap { get { return _grid.cellGap.x; } }
    public float YGap { get { return _grid.cellGap.y; } }


    public Vector3[,] Positions { get; private set; }


    private float XMidIndex { get { return Columns / 2 + 1; } }
    private float YMidIndex { get { return Rows / 2 + 1; } }


    private void Awake()
    {
        if(!_grid)
            _grid = GetComponent<Grid>();

        SetPositions();
    }

    #if UNITY_EDITOR
    private void OnValidate() { UnityEditor.EditorApplication.delayCall += _OnValidate; }
    private void _OnValidate()
    {
        if (this == null) return;

        _grid.cellGap = CellGap;
        _grid.cellSize = CellSize;

        SetPositions();
    }
    #endif

    private void SetPositions()
    {
        Positions = new Vector3[Columns, Rows];

        for(int i = 0; i < Columns; i++)
        {
            // Find x
            float x = FindX(i);
            
            for(int j = 0; j < Rows; j++)
            {
                // Find y

                float y = FindY(j);

                Positions[i,j] = new Vector3(x, y, transform.position.z);
            }
        }
    }

    private float FindX(int col)
    {
        int index = col + 1;

        float x = transform.position.x;
        x += CellWidth / 2; // Shift to cell center
        x += (index - XMidIndex) * XGap; // Add gaps
        x += (index - XMidIndex) * CellWidth; // Add cells widths

        return x;
    }

    private float FindY(int row)
    {
        int index = row + 1;

        float y = transform.position.y;
        y += CellHeight / 2; // Shift to cell center
        y += (index - YMidIndex) * YGap; // Add gaps
        y += (index - YMidIndex) * CellHeight; // Add cells heights

        return y;
    }

    private void OnDrawGizmos()
    {
        if (!_showGizmo) return;
        foreach (var cell in Positions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(cell, _grid.cellSize);

            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(cell, _grid.cellSize);
        }
    }
}
