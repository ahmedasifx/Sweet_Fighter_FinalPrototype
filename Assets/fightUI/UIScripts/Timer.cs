using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private TimerSync timerSync;
    public float currentTime;
    public float startingTime = 60f;


    [SerializeField] Text countdownText;

    void Start()
    {
        timerSync = GameObject.FindObjectOfType<TimerSync>();
        currentTime = startingTime;
    }

    void Update()
    {
        if (timerSync.isSynced)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0f);
            int minutes = (int)currentTime / 60;
            int seconds = (int)currentTime % 60;
            countdownText.text = string.Format("{0:00}", seconds);

            if (currentTime <= 0)
            {
                currentTime = 0;
                // Game Over!
            }
        }

    }
}
