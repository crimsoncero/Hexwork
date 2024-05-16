using UnityEngine;


public enum Team
{
    Neutral,
    Player,
    Enemy
}

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Objects/Data/Unit Data")]
public class UnitData : ScriptableObject
{
    public string Name = "";
    public Team Team = Team.Neutral;
}
