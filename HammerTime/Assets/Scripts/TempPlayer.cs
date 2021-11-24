﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    public Rigidbody rb;
    float speed = 1;
    public GameObject node;
    public List<GameObject> nodes = new List<GameObject>();
    public List<GameObject> chasingZombies = new List<GameObject>(); //This list is irrelevant rn
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

        /*
        //When spawing nodes we want to check if any zombies are currently chasing the player if they do they need to chase the last node
        if(chasingZombies.Count > 0)
        {
            foreach(GameObject zombie in chasingZombies)
            {
                zombie.GetComponent<AIFollowWaypoint>().agent.destination = p.transform.position;
                chasingZombies.Remove(zombie);
                Debug.Log("Pasta");
            }
        }
        */
    }
}
