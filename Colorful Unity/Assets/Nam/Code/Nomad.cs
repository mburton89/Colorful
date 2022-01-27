using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad : MonoBehaviour
{
    public static Nomad Instance;

    public GameObject axe;

    void Awake()
    {
        Instance = this;
    }
}
