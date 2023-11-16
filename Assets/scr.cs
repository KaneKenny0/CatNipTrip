using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Floor_plan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadscene()
    {
        SceneManager.LoadScene("Floor_plan");
    }
}
