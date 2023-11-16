using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxControl : MonoBehaviour
{
    private float HorizontalMoveDirection; // The direction the sprite is moving (either 1 or -1)
    private float VerticalMoveDirection; // The direction the sprite is moving (either 1 or -1)

    public float targetTime = 10.0f;


    private float posX;
    private float posY;
  
    private string direction;

    [SerializeField]
    public GameObject hitboxOrigin;

    [SerializeField]
    public GameObject playerLocation;

    public int damage;


    public Transform hitboxTransform;
    public int radius;

    private string expectedAttack;

    private bool attacking = false;

    private float timer = 0f;
    public float timeToAttack = 0.5f;

    private bool hit = false;

    public CatNipBarContoller catnipBar;

    //hitboxes
    public GameObject Clawhitbox;
    public GameObject SwordHitbox;
    public GameObject FireHitbox;
    public GameObject WhackerHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //attack cooldown
        if (attacking)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                Debug.Log("timer done");
                attacking = false;
                
            }
        }
        


       


        // Debug.Log(this.name);
        direction = getSpriteDirection();
       // Debug.Log(direction);


        //switch statement for determining direction

        switch (direction)
        {
            case "e":
                posX = 0.55f;
                posY = 0f;
                //Debug.Log(direction);
                break;

            case "w":
                posX = -0.55f;
                posY = 0f;
                
                break;

            case "n":
                posY = 0.75f;
                posX = 0f;
                //Debug.Log(direction);
                break;

            case "s":
                posX = 0f;
                posY = -0.75f;
                break;

            case "se":
                posX = 0.55f;
                posY = -0.75f;
                // Debug.Log(direction);
                break;

            case "sw":
                posX = -0.55f;
                posY = -0.75f;
                break;

            case "ne":
                posX = 0.55f;
                posY = 0.75f;
                break;

            case "nw":
                posX = -0.55f;
                posY = 0.75f;
                break;







            default:
                break;
        }

        if(this.name == "Flame Hitbox")
        {
            posX = 0;
            posY = 0;
        }

        /*

        if (this.name == "Sword Hitbox")
        {
            switch (direction)
            {

                case "n":
                    hitboxTransform.Rotate(0.0f, 0.0f, 90.0f);
                    break;

                case "s":
                    hitboxTransform.Rotate(0.0f, 0.0f, 90.0f);
                    break;

                case "se":
                    hitboxTransform.Rotate(0.0f, 0.0f, 90.0f);
                    // Debug.Log(direction);
                    break;

                case "sw":
                    hitboxTransform.Rotate(0.0f, 0.0f, 135.0f);
                    break;

                case "ne":
                    hitboxTransform.Rotate(0.0f, 0.0f, 45.0f);
                    break;

                case "nw":
                    hitboxTransform.Rotate(0f, 0.0f, 135.0f);
                    break;







                default:
                    break;
            }
        }
        */
        

        if (Input.GetAxis("Fire1") == 1 && attacking == false)
        {
            attacking = true;
            damage = 1;
            Attack1();
            targetTime = 0.5f;
            Clawhitbox.SetActive(false);
            hit = false;

        }
        if (Input.GetAxis("Fire2") == 1 && attacking == false && catnipBar.level > 0)
        {
            attacking = true;
            damage = 4;
            Attack2();
            targetTime = 1.0f;
            SwordHitbox.SetActive(false);
            hit = false;

        }
        if (Input.GetAxis("Fire3") == 1 && attacking == false && catnipBar.level > 1)
        {
            attacking = true;
            damage = 2;
            Attack3();
            targetTime = 1.0f;
            posX = 0;
            posY = 0;

            FireHitbox.SetActive(false);
            hit = false;
        }
        if (Input.GetAxis("Jump") == 1 && attacking == false && catnipBar.level > 2)
        {
            attacking = true;
            damage = 6;
            Attack4();
            targetTime = 0.5f;
            WhackerHitbox.SetActive(false);
            hit = false;
        }



        //attack cooldown timer
        if (attacking)
            {
           // Debug.Log("attacking");
            
              

            }
        
    

        //for claw attack

        Transform objTransform = playerLocation.GetComponent<Transform>();

        float P_xPos = objTransform.position.x;
        float P_yPos = objTransform.position.y;

        hitboxOrigin.transform.position = new Vector3(P_xPos + posX, P_yPos + posY, 0.0f);


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
    public void DetectColliders()
    {


        foreach (Collider2D collider in Physics2D.OverlapCircleAll(hitboxTransform.position, radius))
        {

            //Debug.Log($"{this.name} + {expectedAttack}");
            if (collider.tag == "Enemy" && !hit)
            {
                hit = true;
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
                hit = false;
            }

        }
        
        
    }

    void DoStuff()
    {
        attacking = false;
        hit = false;
        
        
        
        Debug.Log("Timer done");
    }

  


    void Attack1()
    {
        Clawhitbox.SetActive(true);

        DetectColliders();
        //Debug.Log("Attack 1");
  
    }
    void Attack2()
    {
        SwordHitbox.SetActive(true);
        DetectColliders();
       // Countdown(0.5f);
    }
    void Attack3()
    {
        FireHitbox.SetActive(true);
        DetectColliders();
 

    }
    void Attack4()
    {
        WhackerHitbox.SetActive(true);
        DetectColliders();


    }
}
