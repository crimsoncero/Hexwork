using UnityEngine;


public enum Team
{
    Neutral,
    Player,
    Enemy
}

public abstract class UnitData : ScriptableObject
{
    public string Name = "";
    public Team Team = Team.Neutral;
}
