using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject targetHit;
    public float speed = 1f;
    private Vector3 moveY = new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetHit != null)
        {
            Move();
        }
    }
    public void Move()
    {
        Vector3 move = targetHit.transform.position - gameObject.transform.position;
        Quaternion rotation = Quaternion.LookRotation( new Vector3(0f, 0f, 1f), move);
        move.z = 0;
        move.Normalize();
       // Debug.Log("Here" + move);
        gameObject.transform.Translate(move * speed * Time.deltaTime, Space.World);
        //Quaternion rotation = Quaternion.LookRotation(move, new Vector3(0f, 0f, f));
        gameObject.transform.rotation = rotation;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision rocket");
        if (coll.gameObject.tag == "Plane")
        {
            Destroy(coll.gameObject);
        }
    }
}
