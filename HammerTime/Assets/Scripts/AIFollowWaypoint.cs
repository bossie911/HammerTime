using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowWaypoint : MonoBehaviour
{
    public NavMeshAgent agent;
    GameObject player;
    public GameObject currentWayPoint;
    float setDestinationInterval = 0.1f;
    float timer = 0f;

    public bool isChasing = true;
    public SphereCollider sphereCol;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int lastNode = player.GetComponent<TempPlayer>().nodes.Count - 1;
        currentWayPoint = player.GetComponent<TempPlayer>().nodes[lastNode];
        agent.destination = currentWayPoint.transform.position;

        InvokeRepeating("TurnCollOff", 1f, 1f);
        if (agent.enabled == true)
        {
            agent.destination = currentWayPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(currentWayPoint.tag == "Player" && timer >= setDestinationInterval)
        {
            if (agent.enabled == true)
            {
                agent.destination = currentWayPoint.transform.position;
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
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
                int nextNodeNr;
                if (isChasing)
                {
                    //Set destination on the next waypoint
                    nextNodeNr = other.GetComponent<Node>().nodeNr + 1;
                }
                else
                {
                    nextNodeNr = other.GetComponent<Node>().nodeNr - 1;
                }

                if (nextNodeNr >= 0)
                {
                    currentWayPoint = player.GetComponent<TempPlayer>().nodes[nextNodeNr];
                    agent.destination = currentWayPoint.transform.position;
                }               
            }
        }
    }

    void TurnCollOff()
    {
        sphereCol.enabled = false;
        StartCoroutine(ResetCol());
    }

    IEnumerator ResetCol()
    {
        yield return new WaitForFixedUpdate();
        sphereCol.enabled = true;
    }
}
