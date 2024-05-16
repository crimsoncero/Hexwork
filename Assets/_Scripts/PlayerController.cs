using UnityEngine;

public class PlayerController : Unit
{
    [field: SerializeField] public CharacterData CharData { get; set; }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CombatManager.Instance.TryMove(this, Position + Vector2Int.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CombatManager.Instance.TryMove(this, Position + Vector2Int.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CombatManager.Instance.TryMove(this, Position + Vector2Int.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CombatManager.Instance.TryMove(this, Position + Vector2Int.left);
        }
    }


}
