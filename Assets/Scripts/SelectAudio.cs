using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAudio : MonoBehaviour
{
    public AudioSource selectButtonSound;
    public AudioSource MultiplayerButtonSound;
    public AudioSource fightButtonSound;

    public void PlayButtonSound()
    {
        selectButtonSound.Play();
    }

    public void PlayButtonSound2()
    {
        MultiplayerButtonSound.Play();
    }

    public void PlayButtonSound3()
    {
        fightButtonSound.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
