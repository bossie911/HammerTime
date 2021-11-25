using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ZombieScript zombie))
        {
            if (zombie.GetZombieState() == ZombieState.Fleeing)
            {
                
            }
        }
    }
}
