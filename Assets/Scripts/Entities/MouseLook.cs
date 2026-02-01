using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    public Transform PlayerBody;

    float xRotation = 0f;

    InputAction Look;

    //first person controller tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Look = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Look.ReadValue<Vector2>();

        float mouseY = mouse.y * MouseSensitivity * Time.deltaTime;
        float mouseX = mouse.x * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
