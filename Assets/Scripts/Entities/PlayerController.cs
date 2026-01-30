using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    InputAction Move; 

    public CharacterController Controller;
    public float Speed = 12f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Move = InputSystem.actions.FindAction("Move"); 
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Move.ReadValue<Vector2>(); 

        Vector3 movedirection = transform.right * movement.x + transform.forward * movement.y;

        Controller.Move(movedirection * Speed * Time.deltaTime);


    }
}
