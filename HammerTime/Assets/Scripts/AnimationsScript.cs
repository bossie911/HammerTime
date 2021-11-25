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

        if(smash)
        {
            hammer.SetActive(true);
            animator.SetBool("Attack", true);
            animator.SetBool("RunArms", false);
            animator.SetBool("IdleArms", false);
        }
        else
        {
            hammer.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            smash = !smash;
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
