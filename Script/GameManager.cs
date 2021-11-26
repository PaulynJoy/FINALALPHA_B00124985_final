using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int score;
    public static GameManager inst;
    public Text scoreText;
    public PlayerMovement playermovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "COINS: " + score;
        //Increase the speed
        playermovement.speed += playermovement.speedIncreases;
    }

    private void Awake()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
