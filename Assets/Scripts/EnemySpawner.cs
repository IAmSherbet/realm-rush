using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesToSpawn;
    [SerializeField] Transform parentObject;
    [SerializeField] float secondsBetweenSpawns = 4f;
 
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (GameObject enemy in enemiesToSpawn)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            Instantiate(enemy, transform.position, Quaternion.identity, parentObject);
        }
    }
}
