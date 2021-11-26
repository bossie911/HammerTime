using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickupScript : MonoBehaviour
{
    [SerializeField] private int timeValue;
    [SerializeField] private float respawnDelay;

    private MeshRenderer mesh;
    private Collider collider;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HammerScript.instance.hammerTime += timeValue;
            HammerScript.instance.StartHammering();
            StartCoroutine(Respawn());
            GameEvents.current.StartFleeing();
            Destroy(gameObject);
        }
    }
    private IEnumerator Respawn()
    {
        mesh.enabled = false;
        collider.enabled = false;
        yield return new WaitForSeconds(respawnDelay);
        mesh.enabled = true;
        collider.enabled = true;
        yield return null;
    }
}
