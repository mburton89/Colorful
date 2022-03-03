using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad : MonoBehaviour
{
    public static Nomad Instance;

    public GameObject axe;
    public bool canBreakDoor;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwingAxe();
        }
    }

    void SwingAxe()
    {
        if (canBreakDoor && axe.activeInHierarchy)
        {
            FindObjectOfType<Door>().Open();
        }
    }
}
