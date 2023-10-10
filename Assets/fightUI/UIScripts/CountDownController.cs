using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public PlayerControler player1;

    private bool countdownFinished = false;

    private void Start()
    {
        player1.enabled = false; // Disable player 1 movement
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO!";
        countdownFinished = true;

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
        player1.enabled = true; // Enable player 1 movement
        //player2.enabled = true; // Enable player 2 movement
    }

    private void Update()
    {
        if (!countdownFinished)
        {
            if (player1 != null)
            {
                player1.enabled = false; // Disable player 1 movement
            }

            //if (player2 != null)
            //{
            //player2.enabled = false; // Disable player 2 movement
        }
    }
}