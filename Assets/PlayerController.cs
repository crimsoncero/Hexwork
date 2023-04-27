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
        if (_canMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(GridManager.UP);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(GridManager.DOWN);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(GridManager.LEFT);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(GridManager.RIGHT);
            }
        }
    

       
    }



    private void Move(Vector2Int dir)
    {

        Vector2Int newPos = new (_gridPos.x + dir.x, _gridPos.y + dir.y);

        if(CombatManager.Instance.CanMove(newPos))
        {
            if(Animator != null) Animator.SetTrigger("PhaseTrigger");
            _gridPos = newPos;
            Transform.position = CombatManager.Instance.GetWorldPos(_gridPos);
        }
    }

}
