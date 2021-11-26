using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRagdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody[] ragdolls;
    private Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        ragdolls = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        Toggle(false);
    }

    public void Toggle(bool state)
    {
        animator.enabled = !state;

        foreach(Rigidbody rb in ragdolls)
        {
            rb.isKinematic = !state;
        }

        foreach(Collider col in colliders)
        {
            col.enabled = state;
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);

        foreach(Collider col in colliders)
        {
            col.enabled = false;
        }

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}

