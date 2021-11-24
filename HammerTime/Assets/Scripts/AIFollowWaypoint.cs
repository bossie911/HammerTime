using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowWaypoint : MonoBehaviour
{
    public NavMeshAgent agent;
    GameObject player;
    GameObject currentWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int lastNode = player.GetComponent<TempPlayer>().nodes.Count - 1;
        currentWayPoint = player.GetComponent<TempPlayer>().nodes[lastNode];
        agent.destination = currentWayPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == currentWayPoint)
        {
            //Set destination on the next waypoint
            int i = other.GetComponent<Node>().nodeNr + 1;
            currentWayPoint = player.GetComponent<TempPlayer>().nodes[i];
            agent.destination = currentWayPoint.transform.position;
        }
    }
}
