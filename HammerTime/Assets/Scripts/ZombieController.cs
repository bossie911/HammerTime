using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        GameEvents.current.startHammering += OnHammerTime;
        GameEvents.current.hammerTimeOver += OnHammerTimeOver;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnHammerTime()
    {
        AIFollowWaypoint ai = GetComponent<AIFollowWaypoint>();
        ai.isChasing = false;
        if (ai.currentWayPoint != null)
        {
            int index = ai.currentWayPoint.GetComponent<Node>().nodeNr - 1;
            ai.currentWayPoint = player.GetComponent<TempPlayer>().nodes[index];
            ai.agent.destination = ai.currentWayPoint.transform.position;
        }     
    }

    private void OnHammerTimeOver()
    {
        AIFollowWaypoint ai = GetComponent<AIFollowWaypoint>();
        ai.isChasing = true;
        if (ai.currentWayPoint != null)
        {
            int index = ai.currentWayPoint.GetComponent<Node>().nodeNr + 1;
            ai.currentWayPoint = player.GetComponent<TempPlayer>().nodes[index];
            ai.agent.destination = ai.currentWayPoint.transform.position;
        }
    }
}
