using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject hammer;
    private bool smash;

    void Update()
    {
        rb.angularVelocity = Vector3.zero;
        if(Mathf.Abs(rb.velocity.magnitude) > 0.2f)
        {
            TurnOffBools(animator);
            animator.SetBool("RunLegs", true);
            animator.SetBool("RunArms", true);
        }
        else if(Mathf.Abs(rb.velocity.magnitude) < 0.2f)
        {
            TurnOffBools(animator);
            animator.SetBool("IdleLegs", true);
            animator.SetBool("IdleArms", true);
        }
    }

    public void SetAnimation(GameObject animObject, string animtionName)
    {
        TurnOffBools(animObject.GetComponent<Animator>());
        animObject.GetComponent<Animator>().SetBool(animtionName, true);
    }

    private void TurnOffBools(Animator anim)
    {
        foreach(AnimatorControllerParameter parameter in anim.parameters) 
        {
            anim.SetBool(parameter.name, false);            
        }
    }
}
