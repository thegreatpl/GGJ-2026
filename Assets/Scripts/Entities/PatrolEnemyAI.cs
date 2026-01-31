using UnityEngine;

public class PatrolEnemyAI : BaseAI
{
    public Vector3 LookLocation; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsLocation(LookLocation);
    }
}
