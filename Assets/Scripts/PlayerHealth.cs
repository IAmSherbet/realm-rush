using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 10;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = playerHealth.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        ReduceHealth();
        healthText.text = playerHealth.ToString();
    }

    public void ReduceHealth()
    {
        playerHealth = playerHealth - 1;
    }
}
