using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaChildController : MonoBehaviour
{
    public bool hit = false;
    public int bouncesleft = 0;
    public GameObject Player;
    public float speed = 1;
    public Vector3 Direction;
    public float maxright;
    public float maxleft;
    public float maxtop;
    public float maxbottom;
    public PlayerAttack playerAttack;
    public RoombaMainControler roombachildcontroller;
    public GameObject Roomba;
    public HealthController healthcontroller;
    public Animator animator;
    public int currenthealth;
    public HealthController playerhealthcontroller;

    


    //public void roombaHit()
    //{
    //    hit = true;
    //    animator.SetTrigger("Hit");
    //    Direction = Roomba.transform.position - transform.position;
    //    bouncesleft = 2;
    //    Debug.Log("hit by coots");
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x < maxright && transform.position.x > maxleft && transform.position.y < maxtop && transform.position.y > maxbottom)
        {
            Direction[0] *= -1;
            Direction[1] *= -1;
            Debug.Log("roomba child collided in centre of screen");
        }

       
        if (collision.gameObject.name == "Roomba" && hit)
        {
            healthcontroller.Damage(1000);
        }
        if (collision.gameObject.tag == "Player" && hit== false)
        {
            playerhealthcontroller.Damage(1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Roomba" && hit)
        {
            healthcontroller.Damage(1000);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Direction = Player.transform.position - transform.position;
        currenthealth = healthcontroller.health;
        Roomba = GameObject.Find("Roomba");
    }

    void Update()
    {
        if (hit==false)
        {
            
            transform.position = transform.position + Direction.normalized * Time.deltaTime * speed;
        }
        else
        {
            if (Roomba != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, Roomba.transform.position, speed * Time.deltaTime);
            }
            
        }
        
        
        if (transform.position.x > maxright)
        {
            Direction[0] = Mathf.Abs(Direction[0]) * -1;
            if (bouncesleft > 0)
            {
                bouncesleft -= 1;
            }
        }
        if (transform.position.x < maxleft)
        {
            Direction[0] = Mathf.Abs(Direction[0]);
            if (bouncesleft > 0)
            {
                bouncesleft -= 1;
            }
        }
        if (transform.position.y > maxtop)
        {
            Direction[1] = Mathf.Abs(Direction[1]) * -1;
            if (bouncesleft > 0)
            {
                bouncesleft -= 1;
            }
        }
        if (transform.position.y < maxbottom)
        {
            Direction[1] = Mathf.Abs(Direction[1]);
            if (bouncesleft > 0)
            {
                bouncesleft -= 1;
            }
        }
        if (hit && bouncesleft == 0)
        {
            //destroy object
        }
        //Debug.Log("healths");
        //Debug.Log(currenthealth);
        //Debug.Log(healthcontroller.health);
        if (currenthealth != healthcontroller.health)
        {
            hit = true;
            speed = 3;
            animator.SetTrigger("Hit");
            if (Roomba != null)
            {
                Direction = Roomba.transform.position - transform.position;
            }
            
            bouncesleft = 2;
            Debug.Log("hit by coots");
            currenthealth = healthcontroller.health;

        }
    }
}