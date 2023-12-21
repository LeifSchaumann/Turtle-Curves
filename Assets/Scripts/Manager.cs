using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public float globalSpeed;

    private void Awake()
    {
        instance = this;
    }
}
