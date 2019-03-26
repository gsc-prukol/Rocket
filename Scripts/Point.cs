using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Plane myTarget;
    public Rocket rocket;
    public bool moving = true;
    public float deltaTimeMeans = 0.25f;
    private float rocketSpeed = 1f;
    private Vector3 rocketPosition = new Vector3(0f, 0f, 0f);
    void Awake()
    {
        rocketSpeed = rocket.speed;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(moving)
        {
            rocketPosition = new Vector3(0f, 0f, 0f);
            Vector3 planePosition = myTarget.transform.position;
            Vector3 rocketMove = planePosition - rocketPosition;
            float rotation = Mathf.Deg2Rad * myTarget.transform.rotation.z;
            Vector3 planeMove = new Vector3(Mathf.Sin(rotation), Mathf.Cos(rotation));
            // Debug.Log(planePosition);
            float planeSpeed = myTarget.speed;
            rocketMove.Normalize();
            planeMove *= planeSpeed;
            rocketMove *= rocketSpeed;
            int i = 0;
            while ((planePosition - rocketPosition).sqrMagnitude > .5f && i < 60)
            {
                i++;
                planePosition += planeMove * deltaTimeMeans;
                rocketPosition += rocketMove * deltaTimeMeans;
                rocketMove = planePosition - rocketPosition;
                rocketMove.Normalize();
                rocketMove *= rocketSpeed;
            }
            Debug.Log(i);
            gameObject.transform.position = planePosition;
        }        
    }
}
