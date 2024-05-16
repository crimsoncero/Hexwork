using UnityEngine;

public struct Cell
{
    public Unit Unit;
    public Tile Tile;

    public Cell(Unit unit, Tile tile)
    {
        this.Unit = unit;
        this.Tile = tile;
    }
}

public class CombatManager : Singleton<CombatManager>
{
    [SerializeField] private SuperGrid2D _superGrid2D;
    [SerializeField] private GameObject _friendlyTile;
    [SerializeField] private GameObject _enemyTile;
    [SerializeField] private PlayerController _player;

    public Vector3[,] Positions { get { return _superGrid2D.Positions; } }
    public Cell[,] Cells { get; set; }

    public Cell this[Vector2Int index]
    {
        get { return Cells[index.x, index.y]; }
        set { Cells[index.x, index.y] = value; }
    }
    protected override void Awake()
    {
        base.Awake();
        _superGrid2D.SetPositions();

        Cells = new Cell[_superGrid2D.Columns, _superGrid2D.Rows];
        for(int i = 0; i < _superGrid2D.Columns; i++)
        {
            for(int j = 0; j < _superGrid2D.Rows; j++)
            {
                GameObject tile;
                if (i < _superGrid2D.XMidIndex)
                   tile = Instantiate(_friendlyTile, Positions[i, j], Quaternion.identity);
                else
                   tile = Instantiate(_enemyTile, Positions[i, j], Quaternion.identity);

                Cells[i,j] = new Cell(null, tile.GetComponent<Tile>());
            }
        }

        Cells[_player.Position.x, _player.Position.y].Unit = _player;
        SetPosition(_player); 

    }

    public bool TryMove(Unit unit, Vector2Int target)
    {
        if(target.x < 0 || target.y < 0) return false;
        if (target.x >= _superGrid2D.Columns || target.y >= _superGrid2D.Rows) return false;

        if (this[target].Tile.Team != unit.Data.Team) return false;

        unit.Position = target;
        SetPosition(unit);
        return true;
    }


    private void SetPosition(Unit unit)
    {
        unit.transform.position = Positions[unit.Position.x,unit.Position.y];
    }
}
