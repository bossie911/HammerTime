using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private ZombieState myZombieState;

    [Header("Apperance")]
    [SerializeField] private Material[] colorMaterials;
    [SerializeField] private Renderer myRenderer;

    private NavMeshAgent myAgent;
    private AIFollowWaypoint chasingScript;
    private Rigidbody myRB;

    void Start()
    {
        myZombieState = ZombieState.Sleeping;
        chasingScript = GetComponent<AIFollowWaypoint>();
        myRB = GetComponent<Rigidbody>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void UpdateZombieApperance()
    {
        myRenderer.material = colorMaterials[(int)myZombieState];
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (myZombieState == ZombieState.Sleeping) {
                myZombieState = ZombieState.Chasing;
                myAgent.enabled = true;
                chasingScript.enabled = true;
                GetComponents<Collider>()[0].enabled = true;
                GetComponents<Collider>()[1].enabled = false;
                UpdateZombieApperance();
            }
        }
    }
}
