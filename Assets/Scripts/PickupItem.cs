using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    public CatNipBarContoller catNipBar;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
// Debug.Log(other.name);
        if (other.tag == "Player")
        {
            if (gameObject.tag == "CatNip")
            {
                CatnipControl catnip = other.GetComponent<CatnipControl>();
                catnip.Catnip += 1;
                Debug.Log($"Yo ass got {catnip.Catnip} in yo wallet");
                catNipBar.AddCatnip();
            }


            if (gameObject.tag == "biscuit")
            {
                HealthController healthController = other.GetComponent<HealthController>();
                healthController.health = 8;
            }

            gameObject.SetActive(false);



        }
    }
}
