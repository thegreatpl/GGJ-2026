using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour
{
    InputAction Move; 

    MovementController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Move = InputSystem.actions.FindAction("Move"); 
        controller = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Move.ReadValue<Vector2>(); 
        controller.Movement = movement;


    }
}
