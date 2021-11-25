﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public static HammerScript instance;

    private float timer;

    public bool isActive;
    public float hammerTime;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer > hammerTime)
            {
                timer = 0;
                hammerTime = 0;
                isActive = false;
                gameObject.SetActive(false);
            }
        }
    }
    public void setActive()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
}
