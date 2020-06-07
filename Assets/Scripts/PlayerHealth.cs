using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 10;

    private void OnTriggerEnter(Collider other)
    {
        ReduceHealth();
    }

    public void ReduceHealth()
    {
        playerHealth = playerHealth - 1;
    }
}
