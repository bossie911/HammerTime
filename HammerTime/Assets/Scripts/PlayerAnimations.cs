using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatinos : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
        rb.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(rb.velocity.magnitude);
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
