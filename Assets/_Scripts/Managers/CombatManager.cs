using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatManager : StaticInstance<CombatManager>
{
    public Grid GridData;
    public int Rows;
    public int Columns;
    public Transform GridOrigin;


    public Grid Grid { get; private set; } 

    private void Start()
    {
        
    }


    public Vector2 GetWorldPos(Vector2Int gridPos)
    {
        return Grid.GetWorldPos(gridPos);
    }

    public bool CanMove(Vector2Int gridPos)
    {
        if(0 > gridPos.x || gridPos.x >= Rows)
            return false;
        if (0 > gridPos.y || gridPos.y >= Columns)
            return false;
        
        
        
        return true;
    }

    private void OnValidate()
    {
        Grid = new Grid(new Vector2Int(Rows, Columns), GridData, GridOrigin.position);
    }

}
