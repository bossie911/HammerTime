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
    private ZombieController zombieController;
    private Rigidbody myRB;

    void Start()
    {
        myZombieState = ZombieState.Sleeping;
        chasingScript = GetComponent<AIFollowWaypoint>();
        zombieController = GetComponent<ZombieController>();
        myAgent = GetComponent<NavMeshAgent>();
        GetComponent<Animator>().SetBool("Idle", true);
        myRB = GetComponent<Rigidbody>();
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
                zombieController.enabled = true;
                GetComponents<Collider>()[0].enabled = true;
                GetComponents<Collider>()[1].enabled = false;
                GetComponent<Animator>().SetBool("Idle", false);
                GetComponent<Animator>().SetBool("Run", true);
                UpdateZombieApperance();
            }
        }
    }
    public ZombieState GetZombieState()
    {
        return myZombieState;
    }
}
