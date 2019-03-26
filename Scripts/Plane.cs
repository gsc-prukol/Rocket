using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        float rotation = Mathf.Deg2Rad * gameObject.transform.rotation.z;
        Vector3 move = new Vector3(Mathf.Sin(rotation), Mathf.Cos(rotation));
        move *= speed * Time.deltaTime;
        gameObject.transform.Translate(move);
    }
    void FixedUpdate()
    {
        if ( gameObject.transform.position.x > 6.65f ||
             gameObject.transform.position.x < -6.65f ||
             gameObject.transform.position.y > 5.0f ||
             gameObject.transform.position.y < -5.0f )
        {
            Respawn();
        }
    }
    void Respawn()
    {
        float x = Random.Range(-6.65f, 6.65f);
        float y = Random.Range(-5f, 5f);
        float rotationZ = Random.Range(-180f, 180f);
        speed = Random.Range(0.2f, 0.4f);
        gameObject.transform.position = new Vector2(x, y);
        gameObject.transform.Rotate(new Vector3(0f, 0f, rotationZ));
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision plane");
        if (coll.gameObject.tag == "Rocket")
        {
            Destroy(coll.gameObject);
        }
    }
}
