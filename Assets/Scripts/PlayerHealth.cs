using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 10;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayDamageSFX();
        ReduceHealth();
        UpdateHealthText();
    }

    private void PlayDamageSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
    }

    public void ReduceHealth()
    {
        playerHealth = playerHealth - 1;
    }

    private void UpdateHealthText()
    {
        healthText.text = playerHealth.ToString();
    }

}
