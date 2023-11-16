using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoomDetect : MonoBehaviour
{
    public GameObject cam;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public AudioSource source;
    public Collider2D soundTrigga;
    public AudioSource mainsong;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            mainsong.Stop();
            source.Play();
            cam.SetActive(true);
            cam2.SetActive(false);
            cam4.SetActive(false);  
            cam3.SetActive(true);
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

