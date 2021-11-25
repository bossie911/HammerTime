using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowWaypoint : MonoBehaviour
{
    public NavMeshAgent agent;
    GameObject player;
    public GameObject currentWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int lastNode = player.GetComponent<TempPlayer>().nodes.Count - 1;
        currentWayPoint = player.GetComponent<TempPlayer>().nodes[lastNode];
        agent.destination = currentWayPoint.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentWayPoint.tag == "Player")
        {
            agent.destination = currentWayPoint.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject == currentWayPoint && other.gameObject.tag != "Player")
        {
            //Check if collided node is the last one
            if (other.GetComponent<Node>().nodeNr == player.GetComponent<TempPlayer>().nodes.Count - 1)
            {
                currentWayPoint = player;
                agent.destination = currentWayPoint.transform.position;
                player.GetComponent<TempPlayer>().chasingZombies.Add(gameObject);
            }
            else
            {
                //Set destination on the next waypoint
                int nextNodeNr = other.GetComponent<Node>().nodeNr + 1;
                currentWayPoint = player.GetComponent<TempPlayer>().nodes[nextNodeNr];
                agent.destination = currentWayPoint.transform.position;
            }

        }
    }
}
