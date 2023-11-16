using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class AIChase : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public Animator animator;
    private float distance;
    public Vector3 OffSetHorizontal;
    public Vector3 OffSetUp;
    public Vector3 OffSetDown;
    public float acceptablerange;


    private Vector2 distanceBetween;
    public bool playerInRange = false;
    public Vector2 view = new Vector2(5.0f, 5.0f);

    // Update is called once per frame
    void Update()
    {

        distanceBetween = player.transform.position - transform.position;



        Vector3 uplockon = player.transform.position + OffSetUp;  //point enemy moves to
        Vector3 downlockon = player.transform.position - OffSetDown; 
        Vector3 rightlockon = player.transform.position + OffSetHorizontal;
        Vector3 leftlockon = player.transform.position - OffSetHorizontal;  
        //Debug.Log($"{player.transform.position} + {uplockon}");
        
        //get distance bewteen enemy and point
        distance = Vector2.Distance(transform.position, player.transform.position);
        float updistance = Vector3.Distance(transform.position,uplockon);
        float downdistance = Vector3.Distance(transform.position,downlockon);
        float rightdistance = Vector3.Distance(transform.position,rightlockon);
        float leftdistance = Vector3.Distance(transform.position,leftlockon);


        if(distanceBetween.x < view.x && distanceBetween.y < view.y)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;  
        }


        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);

        if (updistance < acceptablerange)
        {
            //kanes attack function
            animator.SetTrigger("attack down");
           // Debug.Log("Attack u");
        }
        if (downdistance < acceptablerange)
        {
            //kanes attack function
            animator.SetTrigger("attack up");
           // Debug.Log("Attack d ");
        }
        if (rightdistance < acceptablerange)
        {
            //kanes attack function
            animator.SetTrigger("attack left");
            //Debug.Log("Attack r");
        }
        if (leftdistance < acceptablerange)
        {
            //kanes attack function
            animator.SetTrigger("attack right");
           // Debug.Log("Attack l");
        }
        if (updistance < downdistance && updistance < rightdistance && updistance < leftdistance && updistance < 8 && updistance > acceptablerange && playerInRange)
         {
            Vector2 direction = uplockon - transform.position;
            
            transform.position = Vector2.MoveTowards(this.transform.position, uplockon, speed * Time.deltaTime);
            //Debug.Log(transform.position);

            Double MagnitudeHorizontal = Math.Sqrt(direction[0] * direction[0]);
            Double MagnitudeVertical = Math.Sqrt(direction[1] * direction[1]);
            //Debug.Log($"{MagnitudeHorizontal} + {MagnitudeVertical}"  );

            if (MagnitudeHorizontal > MagnitudeVertical)
            {
                animator.SetFloat("Horizontal", direction[0]);
                animator.SetFloat("Vertical", 0);
            }
            if (MagnitudeHorizontal < MagnitudeVertical)
            {
                animator.SetFloat("Vertical", direction[1]);
                animator.SetFloat("Horizontal", 0);
            }
         }
        if (downdistance < updistance && downdistance < rightdistance && downdistance < leftdistance && downdistance < 8 && downdistance > acceptablerange && playerInRange)
        {
            Vector2 direction = downlockon - transform.position;
            
            transform.position = Vector2.MoveTowards(this.transform.position, downlockon, speed * Time.deltaTime);
            //Debug.Log(transform.position);

            Double MagnitudeHorizontal = Math.Sqrt(direction[0] * direction[0]);
            Double MagnitudeVertical = Math.Sqrt(direction[1] * direction[1]);
            //Debug.Log($"{MagnitudeHorizontal} + {MagnitudeVertical}"  );

            if (MagnitudeHorizontal > MagnitudeVertical)
            {
                animator.SetFloat("Horizontal", direction[0]);
                animator.SetFloat("Vertical", 0);
            }
            if (MagnitudeHorizontal < MagnitudeVertical)
            {
                animator.SetFloat("Vertical", direction[1]);
                animator.SetFloat("Horizontal", 0);
            }
        }
        if (rightdistance < downdistance && rightdistance < updistance && rightdistance < leftdistance && rightdistance < 8 && rightdistance > acceptablerange && playerInRange)
        {
            Vector2 direction = rightlockon - transform.position;
            
            transform.position = Vector2.MoveTowards(this.transform.position, rightlockon, speed * Time.deltaTime);


            Double MagnitudeHorizontal = Math.Sqrt(direction[0] * direction[0]);
            Double MagnitudeVertical = Math.Sqrt(direction[1] * direction[1]);
            //Debug.Log($"{MagnitudeHorizontal} + {MagnitudeVertical}"  );

            if (MagnitudeHorizontal > MagnitudeVertical)
            {
                animator.SetFloat("Horizontal", direction[0]);
                animator.SetFloat("Vertical", 0);
            }
            if (MagnitudeHorizontal < MagnitudeVertical)
            {
                animator.SetFloat("Vertical", direction[1]);
                animator.SetFloat("Horizontal", 0);
            }
        }
        if (leftdistance < downdistance && leftdistance < rightdistance && leftdistance < updistance && leftdistance < 8 && leftdistance > acceptablerange && playerInRange)
        {
            Vector2 direction = leftlockon - transform.position;
            
            transform.position = Vector2.MoveTowards(this.transform.position, leftlockon, speed * Time.deltaTime);


            Double MagnitudeHorizontal = Math.Sqrt(direction[0] * direction[0]);
            Double MagnitudeVertical = Math.Sqrt(direction[1] * direction[1]);
            //Debug.Log($"{MagnitudeHorizontal} + {MagnitudeVertical}"  );

            if (MagnitudeHorizontal > MagnitudeVertical)
            {
                animator.SetFloat("Horizontal", direction[0]);
                animator.SetFloat("Vertical", 0);
            }
            if (MagnitudeHorizontal < MagnitudeVertical)
            {
                animator.SetFloat("Vertical", direction[1]);
                animator.SetFloat("Horizontal", 0);
            }
        }

        //if (distance < 8)       //check if you are close enough
        //{


        //    Vector2 direction = player.transform.position - transform.position;

        //    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        //    Double MagnitudeHorizontal = Math.Sqrt(direction[0] * direction[0]);
        //    Double MagnitudeVertical = Math.Sqrt(direction[1] * direction[1]);
        //    //Debug.Log($"{MagnitudeHorizontal} + {MagnitudeVertical}"  );

        //    if (MagnitudeHorizontal > MagnitudeVertical)
        //    {
        //        animator.SetFloat("Horizontal", direction[0]);
        //        animator.SetFloat("Vertical", 0);
        //    }
        //    if (MagnitudeHorizontal < MagnitudeVertical)
        //    {
        //        animator.SetFloat("Vertical", direction[1]);
        //        animator.SetFloat("Horizontal", 0);
        //    }
        
    }
}
