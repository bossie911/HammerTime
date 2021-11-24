using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private ZombieState myZombieState;

    [Header("Apperance")]
    [SerializeField] private Material[] colorMaterials;
    [SerializeField] private Renderer myRenderer;

    private AIFollowWaypoint chasingScript;
    private Rigidbody myRB;

    void Start()
    {
        myZombieState = ZombieState.Sleeping;
        chasingScript = GetComponent<AIFollowWaypoint>();
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
                myRB.useGravity = true;
                myRB.isKinematic = false;
                chasingScript.enabled = true;
                UpdateZombieApperance();
            }
        }
    }
}
