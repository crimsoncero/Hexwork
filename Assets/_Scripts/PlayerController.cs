using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMovement(InputAction.CallbackContext callBackContext)
    {
        Debug.Log(callBackContext.ToString());
    }

}
