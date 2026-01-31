using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PatrolEnemyAI : BaseAI
{


    public Waypoint[] Waypoints;

    public int CurrentWaypoint; 

    public float Distance = 1f;
    public float AttackDistance = 1f; 

    public Animator Animator; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        CurrentWaypoint = 0;
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveToAttackPlayer() && Waypoints.Length > 0)
        {
            
            var targetpos = Waypoints[CurrentWaypoint].transform.position;
            Animator.SetFloat("Animation", 0); 
            MoveTowardsLocation(targetpos);

            if (Vector3.Distance(transform.position, targetpos) < Distance)
            {
                CurrentWaypoint++; 
                if (CurrentWaypoint >= Waypoints.Length)
                    CurrentWaypoint = 0;
            }
            
        }
        else
        {
            Animator.SetFloat("Animation", 3);

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

        if (Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position) < AttackDistance)
        {

            //insert attack code here. 
            Animator.SetFloat("Animation", 1); //attacking. 

        }

        return true;
    }
}
