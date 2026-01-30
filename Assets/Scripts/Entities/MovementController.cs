using UnityEngine;
using UnityEngine.InputSystem;  // 1. The Input System "using" statement

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{

    public CharacterController Controller;
    public float Speed = 12f;
    public float JumpHeight = 3f; 

    public Vector2 Movement;
    public bool Jump; 

    public float Gravity = -9.18f; 
    Vector3 velocity;
    bool isGrounded; 


    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask; 

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        Movement = Vector2.zero;
        isGrounded = true; 

    }

    // Update is called once per frame
    void Update()
    {
        
        GravityReset(); 
        //Normal movement. 
        Vector3 movedirection = transform.right * Movement.x + transform.forward * Movement.y;

        Controller.Move(movedirection * Speed * Time.deltaTime);

        //jumping
        if (Jump && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
            Jump = false; 
        }

        //Gravity falling stuff. 
        velocity.y += Gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime); 
    }


    void GravityReset()
    {
        if (GroundCheck == null)
        {
            return; 
        }

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (isGrounded)
        {
            //ground check might fire before hitting the actual ground,
            //so setting it to low means it slows then collides as normal. 
            velocity.y = -2f; 
        }
    }
}
