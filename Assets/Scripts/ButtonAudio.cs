using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource startButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSound()
    {
        startButtonSound.Play();
        Debug.Log("played audio");
    }

    public void StopMusic()
    {
        startButtonSound.Stop();
        Debug.Log("audio stopped");
    }
}




