using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHits : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 6;

    private void OnParticleCollision(GameObject other) //(GameObject other) is a Unity default, dw about it
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        //consider adding hit FX
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity, parent);
        Destroy(gameObject);
    }
}
