using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMainControler : MonoBehaviour
{
    public HealthController roombahealthcontroller;
    public HealthController playerhealthcontroller;
    private bool roombachildactive;
    public float speed = 1;
    public Vector3 Direction = new Vector3(2, -1, 0);
    public float maxright;
    public float maxleft;
    public float maxtop;
    public float maxbottom;
    public Animator animator;
    public int currenthealth;
    public GameObject RoombaProjectile;
    public float interval = 8f;
    public Vector2 location;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x < maxright && transform.position.x > maxleft && transform.position.y < maxtop && transform.position.y > maxbottom)
        {
            Direction[0] *= -1;
            Direction[1] *= -1;
            Debug.Log("roomba parent collided in centre of screen");
        }
        Debug.Log("collision detected");
        
        //Debug.Log(roombachildactive);
        if (collision.gameObject.tag == "Enemy"  )
        {
            
            //Debug.Log(roombachildactive);
            roombachildactive = collision.gameObject.GetComponent<RoombaChildController>().hit;
            if (roombachildactive)
            {
                roombahealthcontroller.Damage(1);
                


            }
        
        
        }
        if (collision.gameObject.tag == "Player")
        {
            playerhealthcontroller.Damage(1);
        }

    }


    // Start is called before the first frame update





    void Start()
    {
        currenthealth = roombahealthcontroller.health;
        InvokeRepeating("repeatingMethod", 0f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Direction * Time.deltaTime * speed;
        if (transform.position.x > maxright)
        {
            Direction[0] = Mathf.Abs(Direction[0]) * -1;
        }
        if (transform.position.x < maxleft)
        {
            Direction[0] = Mathf.Abs(Direction[0]);
        }
        if (transform.position.y > maxtop)
        {
            Direction[1] = Mathf.Abs(Direction[1]) * -1;
        }
        if (transform.position.y < maxbottom)
        {
            Direction[1] = Mathf.Abs(Direction[1]);
        }

        if (currenthealth != roombahealthcontroller.health)
        {
            animator.SetTrigger("get hit");
            currenthealth = roombahealthcontroller.health;

        }

    }

    void repeatingMethod()
    {
        Debug.Log("spawning roomba");
        location = new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * 3;
        GameObject.Instantiate(RoombaProjectile, location, Quaternion.identity);
    }
}
