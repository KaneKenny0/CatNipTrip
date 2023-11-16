using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public int health;




    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
   void Update()
    {

    }


    public void Damage(int amount)
    {
        
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Can't have negetive damage");
        }

        health = health - amount;
        if (health <= 0)
        {
            
            Death();
        }
    }



    public void Death()
    {
        //gameObject.SetActive(false);
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }else if(gameObject.tag == "boss")
        {
           SceneManager.LoadScene("EndCutscene");
        }
        else
        {
            Destroy(gameObject);
        }
        

       
    }
}
