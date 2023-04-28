using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager
{
    public static Vector2Int UP = new Vector2Int(-1, 0);
    public static Vector2Int DOWN = new Vector2Int(1, 0);
    public static Vector2Int RIGHT = new Vector2Int(0, 1);
    public static Vector2Int LEFT = new Vector2Int(0, -1);






    public Vector2[,] GridWorldPos { get; private set; }
    private Cell[,] _grid;
    private Grid _gridData;
    private Vector2Int _gridSize; //Rows and Columns;
    private Vector2 _centerPos;


    public int Rows { get { return _gridSize.x; } }
    public int Columns { get { return _gridSize.y; } }


    public GridManager(Vector2Int gridSize, Grid gridData, Vector2 centerPos)
    {
        _gridSize = gridSize;
        _gridData = gridData;
        _centerPos = centerPos;
        _grid = new Cell[Rows, Columns];
        GridWorldPos = InitWorldPos();
    }


    public Vector2 GetWorldPos(Vector2Int gridPos)
    {
        return GridWorldPos[gridPos.x, gridPos.y];
    }


    private Vector2[,] InitWorldPos()
    {
        Vector2[,] worldPos = new Vector2[Rows, Columns];
        Vector2Int Dist = new Vector2Int(Columns/2, Rows / 2);
        for(int i = 0; i < Rows; i ++)
        {

            float y = 0;
            if(Rows % 2 == 0)
            {
                if(i < Dist.y)
                {
                    y = _centerPos.y + (Dist.y - i - 0.5f) * _gridData.cellGap.y + (Dist.y - i - 0.5f)*_gridData.cellSize.y;
                }
                else
                {
                    y = _centerPos.y - (i - Dist.y + 0.5f)  * _gridData.cellGap.y - (i - Dist.y + 0.5f) * _gridData.cellSize.y;
                }
            }
            else
            {
                if(i < Dist.y)
                {
                    y = _centerPos.y + (Dist.y - i) * _gridData.cellGap.y + (Dist.y - i) * _gridData.cellSize.y;
                }
                else if(i > Dist.y)
                {
                    y = _centerPos.y - (i - Dist.y + 1) * _gridData.cellGap.y - (i - Dist.y) * _gridData.cellSize.y;
                }
                else
                {
                    y = _centerPos.y;
                }

            }

            for(int j = 0;  j < Columns; j++)
            {
                float x = 0;
                if (Columns % 2 == 0)
                {
                    if (j < Dist.x)
                    {
                        x = _centerPos.x - (Dist.x - j - 0.5f) * _gridData.cellGap.x - (Dist.x - j - 0.5f) * _gridData.cellSize.x;
                    }
                    else
                    {
                        x = _centerPos.x + (j - Dist.x + 0.5f) * _gridData.cellGap.x + (j - Dist.x + 0.5f) * _gridData.cellSize.x;
                    }
                }
                else
                {
                    if (j < Dist.x)
                    {
                        x = _centerPos.x - (Dist.x -j) * _gridData.cellGap.x - (Dist.x - j) * _gridData.cellSize.x;

                    }
                    else if (j > Dist.x)
                    {
                        x = _centerPos.x + (j - Dist.x) * _gridData.cellGap.x + (j - Dist.x) * _gridData.cellSize.x;
                    }
                    else
                    {
                        x = _centerPos.x;
                    }

                }


                worldPos[i, j] = new Vector2(x, y);
            }
        }






        return worldPos;
    }

    


}


public struct Cell
{
    // Cell characteristics
    public bool isFriendly; // whether this is a panel of the player or the enemy.
    public CellType type;
    public CellCondition condition;

    public GameObject gameObject; // The game object that is currently in the cell; Null if empty.

    public Cell(bool isFriendly, CellType type, CellCondition condition) : this()
    {
        this.isFriendly = isFriendly;
        this.type = type;
        this.condition = condition;
    }
}


public enum CellType
{
    Normal,
}

public enum CellCondition
{
    Normal,
    Cracked,
    Broken,
}