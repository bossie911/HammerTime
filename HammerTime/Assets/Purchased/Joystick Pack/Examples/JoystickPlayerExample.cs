using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;

    private int hammerDelay = 2;

    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown("space"))
        {
            Instantiate(Explosion, transform.position + Vector3.forward / 2, transform.rotation);
        }
    }
    private IEnumerator HammerTimer()
    {
        //do stuff with hammer delay and a bool. mabye make hammer script.
        
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        //rb.velocity = direction * speed;
		yield return null;
    }
}