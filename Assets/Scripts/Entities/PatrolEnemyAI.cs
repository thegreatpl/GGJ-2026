using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PatrolEnemyAI : BaseAI
{


    public Waypoint[] Waypoints;

    public int CurrentWaypoint; 

    public float Distance = 1f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        CurrentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveToAttackPlayer() && Waypoints.Length > 0)
        {
            var targetpos = Waypoints[CurrentWaypoint].transform.position;
            MoveTowardsLocation(targetpos);

            if (Vector3.Distance(transform.position, targetpos) < Distance)
            {
                CurrentWaypoint++; 
                if (CurrentWaypoint >= Waypoints.Length)
                    CurrentWaypoint = 0;
            }
            
        }


    }


    protected bool MoveToAttackPlayer()
    {
        if (GameManager.Instance.Player == null)
        {
            return false; 
        }

        if (!CanSee(GameManager.Instance.Player)) 
            { return false; }
      

        MoveTowardsLocation(GameManager.Instance.Player.transform.position);

        //insert attack code here. 

        return true;
    }
}
