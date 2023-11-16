using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


using TMPro;


public class CatNipBarContoller : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Slider slider;


    private int catNipCount = 0;
    public int level = 0;

    public GameObject Swordcanvas;
    public GameObject Flamecanvas;
    public GameObject Hammercanvas;
    public GameObject Clawcanvas;


    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3; 
    public GameObject cam4;

    public void AddCatnip()
    {
        slider.value += 1;
        catNipCount += 1;

        if (slider.value == 10)
        {
            slider.value = 0;
            level++;
            levelText.text = level.ToString();
        }


        switch (catNipCount)
        {
            case 1:
                Clawcanvas.SetActive(true);

                StartCoroutine(GamePauserC());
                break;
            case 10:
                Swordcanvas.SetActive(true);
                cam2.SetActive(true);
                cam1.SetActive(false);


                StartCoroutine(GamePauserS());
                break;
            case 20:
                Flamecanvas.SetActive(true);
                cam3.SetActive(true);
                cam2.SetActive(false);

                StartCoroutine(GamePauserF());
                break;
            case 30:
                Hammercanvas.SetActive(true);

                cam4.SetActive(true);
                cam3.SetActive(false);

                StartCoroutine(GamePauserH());
                break;

            default:
                break;
        }

    }
    public IEnumerator GamePauserS()
    {

        yield return new WaitForSeconds(3);
        Swordcanvas.SetActive(false);  
    }

    public IEnumerator GamePauserF()
    {
        yield return new WaitForSeconds(3);
        Flamecanvas.SetActive(false);
    }

    public IEnumerator GamePauserH()
    {
        yield return new WaitForSeconds(3);
        Hammercanvas.SetActive(false);
    }

    public IEnumerator GamePauserC()
    {
        yield return new WaitForSeconds(3);
        Clawcanvas.SetActive(false);
    }



}
