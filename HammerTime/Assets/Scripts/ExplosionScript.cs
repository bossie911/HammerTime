using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float power;
    [SerializeField] private float delay;
    [SerializeField] private float upwardsModifier;

    void Start()
    {
        Explosion();
    }

    private void Explosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders) {
            if (hit.CompareTag("Zombie")) 
            {
                ZombieScript zombie = hit.GetComponent<ZombieScript>();
                if (zombie.GetZombieState() != ZombieState.Sleeping)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.useGravity = true;
                        NavMeshAgent agent = hit.GetComponent<NavMeshAgent>();
                        agent.enabled = false;
                        rb.AddExplosionForce(power, explosionPos, radius, upwardsModifier);
                    }
                }
            }
        }
        StartCoroutine(SelfDestruct());
    }
    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
