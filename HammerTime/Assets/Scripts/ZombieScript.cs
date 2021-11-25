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
        myAgent = GetComponent<NavMeshAgent>();
        myRB = GetComponent<Rigidbody>();
    }

    public void UpdateZombieApperance()
    {
        myRenderer.material = colorMaterials[(int)myZombieState];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            if (myZombieState == ZombieState.Fleeing) {
                Vector3 launchDir = new Vector3(0,-1,1);
                myRB.AddForce(launchDir, ForceMode.Force);
            }
        }
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
    public ZombieState GetZombieState()
    {
        return myZombieState;
    }
}
