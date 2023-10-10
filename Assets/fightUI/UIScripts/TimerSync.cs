using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSync : MonoBehaviour
{
    public CountDownController countdownController;
    public float countdownTime = 3f; // Countdown timer length
    public float gameTime = 60f; // Main game timer length
    public GameObject FightCountDown; // GameObject with the countdown timer script
    public GameObject Timer; // GameObject with the main game timer script

    private float startDelay; // Delay before starting the main game timer
    public bool isSynced = false;


    void Start()
    {
        startDelay = countdownTime;
        countdownController = GameObject.FindObjectOfType<CountDownController>();
    }

    void Update()
    {
        if (countdownTime > 0f)
        {
            countdownTime -= Time.deltaTime;
        }
        else if (startDelay > 0f)
        {
            startDelay -= Time.deltaTime;
            if (startDelay <= 0f)
            {
                Timer.SetActive(true);
                FightCountDown.SetActive(false);
            }
        }
        else
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0f)
            {
                // Game over logic
            }
        }


        if (countdownController.countdownTime == 0 && !isSynced)
        {
            isSynced = true;
        }

    }
}