using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool attacking = false;

    private float timeToAttack = 1.0f;
    private float timer = 0f;

    public int damage = 3;

    public int attackType = 0;

    public Animator animator;

    private string expectedAttack;

    public CatNipBarContoller catNipBar;


    private float HorizontalMoveDirection; // The direction the sprite is moving (either 1 or -1)
    private float VerticalMoveDirection; // The direction the sprite is moving (either 1 or -1)

    public Transform circleOrigin;
    public float radius;


    public void DetectColliders(int type)
    {
        switch (type)
        {
            case 1:
                expectedAttack = "Claw Hitbox";
                break;
            case 2:
                expectedAttack = "Sword Hitbox";
                break;
            case 3:
                expectedAttack = "Flame Hitbox";
                break;
            case 4:
                expectedAttack = "whacker hitbox";
                break;
            default:
                expectedAttack = "no hitbox";
                break;
        }

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
           // Debug.Log($"{this.name} + {expectedAttack}");
            if (collider.tag == "Enemy" && this.name == expectedAttack)
            {
                
                Debug.Log(damage);
                //Debug.Log(collider.name);
                if (collider.GetComponent<HealthController>() != null)
                {
                    HealthController healthController = collider.GetComponent<HealthController>();
                    healthController.Damage(damage);

                    KnockBackFeed knockBack = collider.GetComponent<KnockBackFeed>();
                    knockBack.PlayFeedback(gameObject);

                    //  Debug.Log("Pop pop motherfuckerrrrr");
                }
            }

        }
    }

    public string getSpriteDirection()
    {
        HorizontalMoveDirection = Input.GetAxisRaw("Horizontal");
        VerticalMoveDirection = Input.GetAxisRaw("Vertical");

        if (VerticalMoveDirection < 0 && HorizontalMoveDirection > 0)
        {
            return "se";
        }
        else if (VerticalMoveDirection < 0 && HorizontalMoveDirection < 0)
        {
            return "sw";
        }
        else if (VerticalMoveDirection > 0 && HorizontalMoveDirection > 0)
        {
            return "ne";
        }
        else if (VerticalMoveDirection > 0 && HorizontalMoveDirection < 0)
        {
            return "nw";
        }
        else if (HorizontalMoveDirection > 0)
        {
            return "e"; // Face right
        }

        else if (HorizontalMoveDirection < 0)
        {
            return "w"; // Face left
        }

        else if (VerticalMoveDirection > 0)
        {
            return "n";
        }
        else if (VerticalMoveDirection < 0)
        {
            return "s";
        }

        //diagonals


        else
        {
            return "s";
        }
    }

    public void Attack1()
        {
            string direction = getSpriteDirection();
            attackType = 1;
            Debug.Log(attackType);

            switch (direction)
            {
                case "e":
                    animator.SetTrigger("attack 1 right");

                    break;

                case "w":
                    animator.SetTrigger("attack 1 left");
                    break;

                case "n":
                    animator.SetTrigger("attack 1 up");
                    break;

                case "s":
                    animator.SetTrigger("attack 1 down");
                    break;

                case "se":
                    animator.SetTrigger("attack 1 right");
                    break;

                case "sw":
                    animator.SetTrigger("attack 1 left");
                    break;

                case "ne":
                    animator.SetTrigger("attack 1 right");
                    break;

                case "nw":
                    animator.SetTrigger("attack 1 left");
                    break;




                default:
                    break;


            }

            DetectColliders(attackType);
            attacking = true;
            Debug.Log("Attack");

            

        }
    public void Attack2()
    {
        string direction = getSpriteDirection();
        attackType = 2;
        Debug.Log(attackType);
        if (catNipBar.level > 0)
        {
            switch (direction)
            {
                case "e":
                    animator.SetTrigger("attack 2 right");

                    break;

                case "w":
                    animator.SetTrigger("attack 2 left");
                    break;

                case "n":
                    animator.SetTrigger("attack 2 up");
                    break;

                case "s":
                    animator.SetTrigger("attack 2 down");
                    break;

                case "se":
                    animator.SetTrigger("attack 2 right");
                    break;

                case "sw":
                    animator.SetTrigger("attack 2 left");
                    break;

                case "ne":
                    animator.SetTrigger("attack 2 right");
                    break;

                case "nw":
                    animator.SetTrigger("attack 2 left");
                    break;




                default:
                    break;


            }

            DetectColliders(attackType);
            attacking = true;
            Debug.Log("Attack");
        }




    }

    public void Attack3()
    {
        if (catNipBar.level > 1)
        {
            string direction = getSpriteDirection();
            attackType = 3;
            Debug.Log(attackType);



            //space bar by right is neccessary :(

            switch (direction)
            {
                case "e":
                    animator.SetTrigger("attack 3 right ");

                    break;

                case "w":
                    animator.SetTrigger("attack 3 left");
                    break;

                case "n":
                    animator.SetTrigger("attack 3 up");
                    break;

                case "s":
                    animator.SetTrigger("attack 3 down");
                    break;

                case "se":
                    animator.SetTrigger("attack 3 right ");
                    break;

                case "sw":
                    animator.SetTrigger("attack 3 left");
                    break;

                case "ne":
                    animator.SetTrigger("attack 3 right ");
                    break;

                case "nw":
                    animator.SetTrigger("attack 3 left");
                    break;




                default:
                    break;


            }

            DetectColliders(attackType);
            attacking = true;
            Debug.Log("Attack");
        }




    }
    public void Attack4()
    {
        if (catNipBar.level > 2)
        {
            string direction = getSpriteDirection();
            attackType = 4;
            Debug.Log(attackType);

            switch (direction)
            {
                case "e":
                    animator.SetTrigger("attack 4 right");

                    break;

                case "w":
                    animator.SetTrigger("attack 4 left");
                    break;

                case "n":
                    animator.SetTrigger("attack 4 up");
                    break;

                case "s":
                    animator.SetTrigger("attack 4 down");
                    break;

                case "se":
                    animator.SetTrigger("attack 4 right");
                    break;

                case "sw":
                    animator.SetTrigger("attack 4 left");
                    break;

                case "ne":
                    animator.SetTrigger("attack 4 right");
                    break;

                case "nw":
                    animator.SetTrigger("attack 4 left");
                    break;




                default:
                    break;


            }

            DetectColliders(attackType);
            attacking = true;
            Debug.Log("Attack");
        }
        



    }

    /*
        private void OnDrawGizmosSelected()
        {


            //claw
            Gizmos.color = Color.yellow;
            Vector3 ClawPosition = circleOrigin == null ? Vector3.zero : circleOrigin.position;
            Gizmos.DrawWireSphere(ClawPosition, radius);


            //sword
            Gizmos.color = Color.yellow;

            Vector3 SwordOffset = new Vector3(0.2f, 0.5f, 0.0f);

            Vector3 SwordPosition = circleOrigin == null ? Vector3.zero : circleOrigin.position + SwordOffset;
            Vector3 SwordSize = new Vector3(3.0f, 0.5f, 0.0f);

            Gizmos.DrawWireCube(SwordPosition, SwordSize);
        }
    */
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1") == 1 && attacking == false)
        {
            Attack1();
        }
        if (Input.GetAxis("Fire2") == 1 && attacking == false)
        {
            Attack2();
        }
        if (Input.GetAxis("Fire3") == 1 && attacking == false)
        {
            Attack3();
        }
        if (Input.GetAxis("Jump") == 1 && attacking == false)
        {
            Attack4();
        }



        //attack cooldown timer
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                attacking = false;
                timer = 0;

            }
        }
    }

}





