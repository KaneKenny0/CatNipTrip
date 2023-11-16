using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void onAwake()
    {
        GamePauserS();
        SceneManager.LoadScene("Floor_plan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator GamePauserS()
    {

        yield return new WaitForSeconds(45);
        SceneManager.LoadScene("Floor_plan");
    }
}
