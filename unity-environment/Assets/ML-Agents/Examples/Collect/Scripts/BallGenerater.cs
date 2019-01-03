using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerater : MonoBehaviour {

    public GameObject prefab_Ball;
    private Transform m_Transform;
    private GameObject ball;
    public float x;
    public float y;
    public float z;

    // Use this for initialization
    void Start () {
        InvokeRepeating("CreatBall", 0.0f, 4.5f);
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (null != ball.gameObject)
        {
            x = ball.GetComponent<Transform>().position.x;
            y = ball.GetComponent<Transform>().position.y;
            z = ball.GetComponent<Transform>().position.z;
        }
    }

    void CreatBall () {
        //Vector3 pos = new Vector3(0f, 4.4f, 0f);
        Vector3 pos = new Vector3(Random.Range(-4.5f, 4.5f), 4.5f, Random.Range(-4.5f, 4.5f));
        ball = GameObject.Instantiate(prefab_Ball, pos, Quaternion.identity) as GameObject;
        ball.GetComponent<Transform>().SetParent(m_Transform);
        if (null != ball.gameObject)
        {
            GameObject.Destroy(ball.gameObject, 5.5f);
        }
    }
}
