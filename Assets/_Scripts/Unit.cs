using UnityEngine;
public enum State
{
    Idle,
    Moving,
    Attacking,
    TakingDamage,
    Dead,
}
public abstract class Unit : MonoBehaviour
{
    [field: SerializeField]
    public UnitData Data { get; set; }
    [field: SerializeField]
    public Vector2Int Position { get; set; }
    public State State { get; private set; } = State.Idle;


}
