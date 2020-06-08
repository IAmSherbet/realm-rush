using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHits : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 12;
    [SerializeField] int value = 100;
    [SerializeField] AudioClip hitSFX;
    Vector3 hitSpawnPosition;

    private void Update()
    {
        hitSpawnPosition = transform.position + new Vector3(0, 4, 0);
    }

    private void OnParticleCollision(GameObject other) //(GameObject other) is a Unity default, dw about it
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
       PlayerScore playerScore = FindObjectOfType<PlayerScore>();
       playerScore.IncreaseScore(value);
    }

    private void ProcessHit()
    {
        hits = hits - 1;
        Instantiate(hitFX, hitSpawnPosition, Quaternion.identity, parent); //todo: provide parent to store in hierarchy during runtime
        GetComponent<AudioSource>().PlayOneShot(hitSFX);
    }

    private void KillEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}