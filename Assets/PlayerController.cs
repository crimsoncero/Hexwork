using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class PlayerController : MonoBehaviour
{
    public Transform Transform;
    public Animator Animator;


    [SerializeField]
    private Vector2Int _gridPos;

    private bool _canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        _gridPos = new Vector2Int(1, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector2Int.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2Int.down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Animator.SetTrigger("SlashTrigger");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Animator.SetTrigger("ThrowTrigger");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Animator.SetTrigger("CastTrigger");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Animator.SetTrigger("HitTrigger");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Animator.SetTrigger("ShotTrigger");
        }
    }



    private void Move(Vector2Int dir)
    {
        Vector2Int newPos = new (_gridPos.x + dir.x, _gridPos.y + dir.y);

        if(CombatManager.Instance.CanMove(newPos))
        {
            Animator.SetTrigger("PhaseTrigger");
            _gridPos = newPos;
            Transform.position = CombatManager.Instance.GetWorldPos(_gridPos);
        }
    }

}
