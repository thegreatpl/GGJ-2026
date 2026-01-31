using UnityEngine;

public class PatrolEnemyAI : BaseAI
{
    public Vector3 Location1;
    public Vector3 Location2;

    public float Distance = 1f; 

    bool location1 = true; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (location1)
        {
            MoveTowardsLocation(Location1);

            if (Vector3.Distance(transform.position, Location1) < Distance) 
                location1 = false;
        }
        else
        {
            MoveTowardsLocation(Location2);
            if (Vector3.Distance(transform.position, Location2) < Distance)
                location1 = true;
        }

    }
}
