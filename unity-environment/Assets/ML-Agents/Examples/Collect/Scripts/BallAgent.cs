using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BallAgent : MonoBehaviour {

    private Transform n_Transform;
    private Rigidbody n_Rigidbody;

    private void Start()
    {
        n_Transform = gameObject.GetComponent<Transform>();
        n_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {/*
        collectAgent.AddVectorObs(n_Transform.position.x);
        collectAgent.AddVectorObs(n_Transform.position.y);
        collectAgent.AddVectorObs(n_Transform.position.z);
        collectAgent.AddVectorObs(n_Rigidbody.velocity.y);*/
    }
    /*
    public override void CollectObservations()
    {
        AddVectorObs(n_Transform.position.x);
        AddVectorObs(n_Transform.position.y);
        AddVectorObs(n_Transform.position.z);
        AddVectorObs(n_Rigidbody.velocity.y);
    }*/

    
}
