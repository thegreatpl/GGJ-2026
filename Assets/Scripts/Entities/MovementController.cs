using UnityEngine;
using UnityEngine.InputSystem;  // 1. The Input System "using" statement

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{

    public CharacterController Controller;
    public float Speed = 12f;

    public Vector2 Movement; 

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        Movement = Vector2.zero; 

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movedirection = transform.right * Movement.x + transform.forward * Movement.y;

        Controller.Move(movedirection * Speed * Time.deltaTime);
    }
}
