using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private ZombieState myZombieState;

    [Header("Apperance")]
    [SerializeField] private Material[] colorMaterials;
    [SerializeField] private Renderer myRenderer;

    
    void Start()
    {
        myZombieState = ZombieState.Sleeping;
    }

    void Update()
    {

    }
    public void UpdateZombieApperance()
    {
        myRenderer.material = colorMaterials[(int)myZombieState];
    }
    private void ChasingBehaviour()
    {

    }
    private void FleeingBehaviour()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myZombieState++;
        }
    }
}
