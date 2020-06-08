using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int playerScore = 0;

    void Start()
    {
        scoreText.text = playerScore.ToString();   
    }

    public void IncreaseScore(int enemyValue)
    {
        playerScore = playerScore + enemyValue;
        scoreText.text = playerScore.ToString();
    }
}
