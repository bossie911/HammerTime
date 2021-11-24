using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    public Rigidbody rb;
    float speed = 8;

    public GameObject node;

    public List<GameObject> nodes = new List<GameObject>();

    public int index = 0;

    private void Awake()
    {
        GameObject p = Instantiate(node, transform.position, Quaternion.identity);
        nodes.Add(p);
        p.GetComponent<Node>().nodeNr = index;
        index++;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWayPoints", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        var locVel = transform.InverseTransformDirection(rb.velocity);
        locVel.z = speed;
        rb.velocity = transform.TransformDirection(locVel);
    }

    void SpawnWayPoints()
    {
        GameObject p = Instantiate(node, transform.position, Quaternion.identity);
        nodes.Add(p);
        p.GetComponent<Node>().nodeNr = index;
        index++;
    }
}
