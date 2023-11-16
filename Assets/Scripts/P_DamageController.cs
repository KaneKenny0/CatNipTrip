using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DamageController : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private HealthController _healthController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage();
    }

    void Damage()
    {
        //_healthController.playerHealth = _healthController.playerHealth - damage;
        //_healthController.UpdateHealth();
    }
}
