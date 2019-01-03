using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class CollectAgent : Agent {

    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    private Crash n_Crash;
    private Vector3 p;
    public GameObject ballFather;
    public GameObject floor;
    private BallGenerater ballGenerater;
    private bool b;
    private Check check;
    //private Transform[] balls;
    //private Rigidbody[] ballss;

    private void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_Transform = gameObject.GetComponent<Transform>();
        n_Crash = gameObject.GetComponent<Crash>();
        p = gameObject.transform.position;
        ballGenerater = ballFather.GetComponent<BallGenerater>();
        check = floor.GetComponent<Check>();
    }

    public override void CollectObservations()
    {
        AddVectorObs(m_Transform.position.x);
        AddVectorObs(m_Transform.position.z);
        //AddVectorObs(m_Rigidbody.velocity.x);
        //AddVectorObs(m_Rigidbody.velocity.z);
        //AddVectorObs(n_Crash.ifCollision);
        AddVectorObs(ballGenerater.x);
        AddVectorObs(ballGenerater.y);
        AddVectorObs(ballGenerater.z);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
	{
        var actionZ = 0.3f * Mathf.Clamp(vectorAction[0], -1f, 1f);
        var actionX = 0.3f * Mathf.Clamp(vectorAction[1], -1f, 1f);

        if (gameObject.transform.position.x <= 4.49f && gameObject.transform.position.x >= -4.49f ||
            gameObject.transform.position.z <= 4.49f && gameObject.transform.position.z >= -4.49f)
        {
            m_Rigidbody.velocity = 25f * new Vector3(actionX, 0, actionZ);

            /*m_Rigidbody.AddForce(0.3f * new Vector3(0, 0, actionZ), ForceMode.VelocityChange);
            m_Rigidbody.AddForce(0.3f * new Vector3(actionX, 0, 0), ForceMode.VelocityChange);*/
        }
        /*
        if (n_Crash.ifCollision == true)
        {
            Done();
            SetReward(-2f);
        }
        else
        {
            SetReward(0.05f);
        }
        */
        
        if (gameObject.transform.position.x > 4.49f || gameObject.transform.position.x < -4.49f ||
            gameObject.transform.position.z > 4.49f || gameObject.transform.position.z < -4.49f)
        {
            Done();
            SetReward(-2f);
        }

        if (check.a==true)
        {
            Done();
            SetReward(-1f);
        }
        
    }

    public override void AgentReset()
    {
        gameObject.transform.position = p;
        check.a = false;
        m_Rigidbody.velocity = new Vector3(0f, 0f, 0f);
    }

    public override void AgentOnDone()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            SetReward(3.0f);
            GameObject.Destroy(other.gameObject);
        }
    }
}
