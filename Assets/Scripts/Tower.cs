using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] GameObject gun;

    float attackRange = 30f;
    float distanceToEnemy;
    Enemy enemy;

    private void Start()
    {

    }

    void Update()
    {
        enemy = FindObjectOfType<Enemy>();

        if (enemy) // Check for enemy
        {
            // Calculate distance to enemy
            distanceToEnemy = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
            print(distanceToEnemy);
        }

        // Fire at enemy
        if (enemy && distanceToEnemy <= attackRange)
        {
            // Look at enemy
            objectToPan.LookAt(enemy.transform);
            SetTowerActive(true);
        } else
        {
            SetTowerActive(false);
        }
    }

    void SetTowerActive(bool isActive)
    {
        var emissionModule = gun.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }
}
