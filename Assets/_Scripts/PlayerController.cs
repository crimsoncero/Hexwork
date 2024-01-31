
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Transform;
    public Animator Animator;


    [SerializeField]
    Vector2Int _gridPos;

    [SerializeField]
    bool _canAct = true;

    private InputMap _playerInput;


    // Start is called before the first frame update
    void Start()
    {
        InitPlayerInput();
        _gridPos = new Vector2Int(1, 1);
        
    }

   

    // Update is called once per frame
    void Update()
    {
       
    }



    private void Move(Vector2Int dir)
    {
        // Check if you can move right now.
        if (!_canAct) return;

        Vector2Int newPos = new (_gridPos.x + dir.x, _gridPos.y + dir.y);
        if(CombatManager.Instance.CanMove(newPos))
        {
            if(Animator != null) Animator.SetTrigger("PhaseTrigger");
            _gridPos = newPos;
            Transform.position = CombatManager.Instance.GetWorldPos(_gridPos);
        }
        StartCoroutine(ActionCooldown(0.1f));

    }

    private IEnumerator ActionCooldown(float seconds)
    {
        _canAct = false;

        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / seconds;
            yield return null;
        }

        _canAct = true;
    }

    private void InitPlayerInput()
    {
        _playerInput = new InputMap();
        _playerInput.Enable();
        _playerInput.Combat.Enable();



        _playerInput.Combat.Up.performed += up => Move(SuperGrid.UP);
        _playerInput.Combat.Down.performed += down => Move(SuperGrid.DOWN);
        _playerInput.Combat.Left.performed += left => Move(SuperGrid.LEFT);
        _playerInput.Combat.Right.performed += right => Move(SuperGrid.RIGHT);
    }

}
