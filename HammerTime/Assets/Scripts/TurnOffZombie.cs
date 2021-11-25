using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffZombie : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Zombie"))
        {
            collider.GetComponent<ZombieScript>().enabled = false;
            collider.GetComponent<AIFollowWaypoint>().enabled = false;
            collider.GetComponent<Animator>().enabled = false;
        }
    }
}
