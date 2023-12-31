using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackFeed : MonoBehaviour
{


    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float stength = 1, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;


    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;

        rb2d.AddForce(direction * stength, ForceMode2D.Impulse);

        StartCoroutine(Reset());
    }


    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay); 
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
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
