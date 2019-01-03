using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {

    public bool a = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="ball")
        {
            a = true;
        }
    }
}
