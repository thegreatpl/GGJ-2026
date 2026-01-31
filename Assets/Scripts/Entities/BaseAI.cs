using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class BaseAI : MonoBehaviour
{
    public MovementController MovementController;

    public float RotationSpeed = 1f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void MoveTowardsLocation(Vector3 location)
    {
        //look at the object. 
        transform.LookAt(location);
        Vector3 euler = transform.eulerAngles;
        euler.x = 0f; 
        euler.z = 0f;
        transform.rotation = Quaternion.Euler(euler); 



        //var targetdirection = location - transform.position;

        //float singlestep = RotationSpeed * Time.deltaTime;

        //Quaternion.LookRotation()

        //var newdirection = Vector3.RotateTowards(transform.forward, targetdirection, singlestep, 0f);

        ////debug stuff. 
        //Debug.DrawRay(transform.position, newdirection, Color.red);
        //Debug.Log($"Rotation: {newdirection}"); 


        //transform.rotation = Quaternion.LookRotation(newdirection);
    }

}
