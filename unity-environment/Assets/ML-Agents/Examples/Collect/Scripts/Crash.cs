using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour {

    public bool ifCollision;

	// Use this for initialization
	void Start () {
        ifCollision = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnCollisionEnter(Collision other)
    {
        ifCollision = true;
    }

    public void OnCollisionExit(Collision other)
    {
        ifCollision = false;
    }
}
