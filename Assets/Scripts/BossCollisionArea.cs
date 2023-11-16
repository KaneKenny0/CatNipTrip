using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaBossviourScript : MonoBehaviour
{

    public GameObject cam;
    public GameObject cam2;
    public AudioSource source;
    public Collider2D soundTrigga;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            source.Play();
            cam.SetActive(true);
            cam2.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
