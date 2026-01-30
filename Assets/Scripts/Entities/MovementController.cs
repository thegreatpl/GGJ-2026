using UnityEngine;
using UnityEngine.InputSystem;  // 1. The Input System "using" statement


public class MovementController : MonoBehaviour
{

    public CharacterController Controller;
    public float Speed = 12f;
    void Start()
    {
        Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
