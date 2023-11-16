using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnerInterval = 3.5f;


        
  

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemyTimer");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemyTimer()
    {
        yield return new WaitForSeconds(3.5f);
        SpawnEnemy();
        StartCoroutine("SpawnEnemyTimer");  










    }


    void SpawnEnemy()
    {
        GameObject.Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
    }
}
