using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatManager : StaticInstance<CombatManager>
{
    public Grid Grid;
    public int Rows;
    public int Columns;


    public Vector2[,] GridPos;

 

    private void Start()
    {
        GridPos = new Vector2[6, 3];
        SetGridPos();
        foreach(var pos in GridPos)
        {
            Debug.Log($"{pos.x}, {pos.y}");
        }
    }


    public Vector2 GetWorldPos(Vector2Int gridPos)
    {
        return GridPos[gridPos.x, gridPos.y];
    }

    public bool CanMove(Vector2Int gridPos)
    {
        if(0 <= gridPos.x && gridPos.x < Columns)
        {
            if(0 <= gridPos.y && gridPos.y < Rows)
            {
                return true;
            }
        }

        return false;
    }

    private void SetGridPos()
    {
        for(int i = 0; i < Columns; i++)
        {
            for(int j = 0; j < Rows; j++)
            {
                double x = 0, y = 0;
                if(i < Columns / 2)
                {
                    x = Grid.cellSize[0] * (i - 2.5);
                }
                else if(i >= Columns / 2)
                {
                    x = Grid.cellSize[0] * (i - 2.5);
                }

                if (j < Rows / 2)
                {
                    y = Grid.cellSize[1] * (j - 1);
                }
                else if (j > Rows / 2)
                {
                    y = Grid.cellSize[1] * (j - 1);
                }


                GridPos[i, j] = new Vector2((float)x, (float)y);


            }
        }
    }

}
