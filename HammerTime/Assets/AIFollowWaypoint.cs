using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowWaypoint : MonoBehaviour
{
    public NavMeshAgent agent;
    GameObject player;
    GameObject currentWayPoint;
    //int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentWayPoint = player.GetComponent<TempPlayer>().nodes[0];
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
            //index++;
            int i = other.GetComponent<Node>().nodeNr + 1;
            currentWayPoint = player.GetComponent<TempPlayer>().nodes[i];
            agent.destination = currentWayPoint.transform.position;
        }
    }
}
