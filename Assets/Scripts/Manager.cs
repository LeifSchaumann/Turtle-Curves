using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public float globalSpeed;
    public bool expSpeed;
    public float expSpeedRate;
    public float expSpeedMultiplier;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (expSpeed)
        {
            globalSpeed = Mathf.Pow(expSpeedRate, Time.time * expSpeedMultiplier);
        }
        
    }
}
