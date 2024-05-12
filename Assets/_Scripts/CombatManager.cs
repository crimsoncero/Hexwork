using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    [SerializeField] private SuperGrid2D _superGrid2D;

    public Vector3[,] Positions { get { return _superGrid2D.Positions; } }
}
