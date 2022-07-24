using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigationController : MonoBehaviour
{
    NavMeshAgent agent;
    //public Transform[] waypoints;//an array of waypoints
    int waypointIndex;//the index of the waypoints
    Transform waypoint;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = Random.Range(0, GameController.instance.targets.Length);
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();//so we have somewhere to go when the game begins
    }

    // Update is called once per frame
    void Update()
    {
       
        //check if the distance to our target is less than a certain amount, if it is then we will iterate our waypoints and update our destination
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination()
    {
        target = GameController.instance.targets[waypointIndex].position; //get the position of our waypoints
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {

        //Debug.Log(waypointIndex);
        waypointIndex = Random.Range(0, GameController.instance.targets.Length);
    }
}
