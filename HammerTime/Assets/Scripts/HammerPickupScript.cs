using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickupScript : MonoBehaviour
{
    [SerializeField] private int timeValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HammerScript.instance.hammerTime += timeValue;
            HammerScript.instance.setActive();
            Destroy(gameObject);
        }
    }
}
