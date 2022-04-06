using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject Interface_4;
    public GameObject Interface_6;
    public GameObject Interface_7;

    public GameObject interface_4;

    void Start()
    {
        for (int i = 0; i < 10; i++)
            Instantiate(interface_4, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
    }
}
