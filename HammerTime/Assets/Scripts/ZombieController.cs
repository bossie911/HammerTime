using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.startHammering += OnHammerTime;
        GameEvents.current.hammerTimeOver += OnHammerTimeOver;
    }

    private void OnHammerTime()
    {
        GetComponent<AIFollowWaypoint>().isChasing = false;
    }

    private void OnHammerTimeOver()
    {
        GetComponent<AIFollowWaypoint>().isChasing = true;
    }
}
