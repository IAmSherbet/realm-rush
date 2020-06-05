using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters (can be custom) of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] GameObject gun;
    float attackRange = 30f;

    //state
    Transform targetEnemy;
    bool isEnemyInRange;

    void Update()
    {
        SetTargetEnemy();

        CheckEnemyDistance();

        if (isEnemyInRange)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        } else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (Enemy enemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform currentEnemy, Transform newEnemy)
    {
        float distanceToCurrentEnemy = Vector3.Distance(gameObject.transform.position, currentEnemy.position);
        float distanceToNewEnemy = Vector3.Distance(gameObject.transform.position, newEnemy.position);

        if (distanceToNewEnemy < distanceToCurrentEnemy)
        {
            return newEnemy;
        } else
        {
            return currentEnemy;
        }
    }

    private void CheckEnemyDistance()
    {
        if (targetEnemy)
        {
            float distanceToEnemy = Vector3.Distance(gameObject.transform.position, targetEnemy.position);

            if (distanceToEnemy < attackRange)
            {
                isEnemyInRange = true;
            }
            else
            {
                isEnemyInRange = false;
            }

        } else
        {
            isEnemyInRange = false;
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = gun.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }
}
