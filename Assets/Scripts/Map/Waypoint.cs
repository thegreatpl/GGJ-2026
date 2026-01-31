using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public string Name; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //force the damn thing to always be in the floor. 
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
