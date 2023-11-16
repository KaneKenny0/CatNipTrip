using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImover : MonoBehaviour
{ 
    public float speed;

    public Rigidbody2D rb;

    public Transform target;
    Vector3 direction;

    public float range = 0.5f;

    private Vector2 distanceBetween;
    public bool playerInRange = false;
    public Vector2 view = new Vector2(5.0f, 5.0f);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        distanceBetween = target.transform.position - transform.position;


        if (distanceBetween.x < view.x && distanceBetween.y < view.y)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }





        if (target.position.x > transform.position.x && playerInRange)
        {
            transform.TransformPoint(transform.position.x + 0.001f, transform.position.y, transform.position.z);
              
        }

        if (target.position.y > transform.position.y && playerInRange)
        {
            transform.TransformPoint(transform.position.x, transform.position.y + 0.001f, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
        }

        if (target.position.x < transform.position.x && playerInRange)
        {
            transform.TransformPoint(transform.position.x - 0.001f, transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x - 0.001f, transform.position.y, transform.position.z);
        }

        if (target.position.y < transform.position.y && playerInRange)
        {

            transform.TransformPoint(transform.position.x, transform.position.y - 0.001f, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.001f, transform.position.z);
        }


    }
    private void FixedUpdate()
    {
        
    }
}
