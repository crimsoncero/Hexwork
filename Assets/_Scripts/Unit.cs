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
    public State State { get; private set; } = State.Idle;
    
}
