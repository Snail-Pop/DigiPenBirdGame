/*
 * Name: Tayvian R Eberle
 * Date: 10/6/2022
 * Desc: Basic AI. Will follow a path and chase a target if the target is close enough
 * Note: The rigidbody 2D should have a good amount of drag or it will feel very floaty and maybe get stuck orbiting
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceAndChase : MonoBehaviour
{


    public float paceSpeed = 1000;
    
    [Tooltip("Make sure at least one point is here. List of positions to move through.")]
    public Vector3[] waypoints = new Vector3[1];
    [Tooltip("This is how close it should consider close enough to stop moving")]
    public float closeEnough;
    //The waypoint index we are moving towards when pacing
    int currentWaypoint;

    //chase variables
    public float chaseSpeed = 1500;
    public float chaseRadius = 15;
    [Tooltip("Name of the tag this will chase while in the chase radius, best if only one object of with that tag")]
    public string targetTag = "Player";
    GameObject target;

    Rigidbody2D myRB2D;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<Rigidbody2D>() != null)
        {
            myRB2D = gameObject.GetComponent<Rigidbody2D>();
        }
        target = GameObject.FindWithTag(targetTag);
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //check if target is set and exists
        if(target != null)
        {
            //get a vector to the target
            Vector3 toTarget =  target.transform.position - transform.position;
            //check if target is within chase radius
            if (toTarget.sqrMagnitude < chaseRadius * chaseRadius)
            {
                //if target is in range, chase target
                Chase();
            }
            else
            {
                //if not in the radius pace as normal
                Pace();
            }
        }
        //if terget is not set, pace and try to set target
        else
        {
            Pace();
        }
    }

    void Chase()
    {
        Vector3 toTarget = (target.transform.position - transform.position);
        myRB2D.AddForce(toTarget.normalized * chaseSpeed * Time.deltaTime);
    }

    void Pace()
    {
        //Figure out the vector to where we currently want to go
        Vector3 toWaypoint = waypoints[currentWaypoint] - transform.position;
        //Check if we are close enough to that vector
        if(toWaypoint.sqrMagnitude < closeEnough * closeEnough)
        {
            //If we are close enough move to next waypoint
            ++currentWaypoint;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        //If not close enough move towards current point

        else
        {
            toWaypoint.Normalize();
            myRB2D.AddForce(toWaypoint * paceSpeed * Time.fixedDeltaTime);
        }

    }
}
