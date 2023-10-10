using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class AnimateP1P2 : MonoBehaviour
{
    //animation time
    public float animationTime = 0.5f;
    private bool isAnimating = false;

    //buttons for Player 1
    public Button CherryPlayer1;
    public Button CremePlayer1;

    //buttons for Player 2
    public Button CherryPlayer2;
    public Button CremePlayer2;

    //Button to check if multiplayer / AI
    public Button ComputerP2;
    public Button MultiplayerP2;
    public bool isAI = false;

    //button to start the fight
    public Button fightButton;

    //image UI elements
    public RectTransform imageLeft;
    public RectTransform imageRight;

    //replacement images
    public Sprite cherryNormal;
    public Sprite cherryFlipped;
    public Sprite cremeNormal;
    public Sprite cremeFlipped;

    //panel for vsScreen
    public GameObject panel;

    //vs Screen images
    public Sprite cherryCreme;
    public Sprite cherryCherry;
    public Sprite cremeCherry;
    public Sprite cremeCreme;  

    public AudioClip cherryCherryAudio;
    public AudioClip cherryCremeAudio;
    public AudioClip cremeCherryAudio;
    public AudioClip cremeCremeAudio;

    //set active characters to identify which scene to load
    /*
     * options for ActiveP1 = "cherry", "creme"
     * options for ActiveP2 = "cherry", "creme", "cherryAI", "cremeAI"
    */

    //default active players set below
    public string ActiveP1 = "cherry";
    public string ActiveP2 = "creme";

    // Start is called before the first frame update
    void Start()
    {
        CherryPlayer1.onClick.AddListener(CherryP1);
        CherryPlayer2.onClick.AddListener(CherryP2);
        CremePlayer1.onClick.AddListener(CremeP1);
        CremePlayer2.onClick.AddListener(CremeP2);

        ComputerP2.onClick.AddListener(AIClicked);
        MultiplayerP2.onClick.AddListener(MultiClicked);
        
        fightButton.onClick.AddListener(SetScene); 
    }

    void AIClicked()
    {
        isAI = true;
        if (ActiveP2 == "cherry")
        {
            ActiveP2 = "cherryAI";
        }
        else if (ActiveP2 == "creme")
        {
            ActiveP2 = "cremeAI";
        }
    }

    void MultiClicked()
    {
        isAI = false;
        if(ActiveP2 == "cherryAI")
        {
            ActiveP2 = "cherry";
        }
        else if(ActiveP2 == "cremeAI")
        {
            ActiveP2 = "creme";
        }
    }

    //check which character button was clicked for P1 and P2
    //check if isAI is true
    //assign images to image1 and image2
    //store the character selected in ActiveP1 and ActiveP2

    void CherryP1()
    {
        imageLeft.localPosition = new Vector3(-1000f, imageLeft.localPosition.y, imageLeft.localPosition.z);
        imageLeft.GetComponent<Image>().sprite = cherryNormal;

        if (!isAnimating)
        {
            isAnimating = true;
            imageLeft.localPosition = new Vector3(-1000f, imageLeft.localPosition.y, imageLeft.localPosition.z);
            LeanTween.moveLocalX(imageLeft.gameObject, -500f, animationTime).setEaseOutCubic().setOnComplete(() => isAnimating = false);
        }

        ActiveP1 = "cherry";
    }

    void CherryP2()
    {
        imageRight.localPosition = new Vector3(1000f, imageRight.localPosition.y, imageRight.localPosition.z);
        imageRight.GetComponent<Image>().sprite = cherryFlipped;

        if(!isAnimating)
        {
            isAnimating = true;
            imageRight.localPosition = new Vector3(1000f, imageRight.localPosition.y, imageRight.localPosition.z);
            LeanTween.moveLocalX(imageRight.gameObject, 500f, animationTime).setEaseOutCubic().setOnComplete(() => isAnimating = false);
        }

        ActiveP2 = "cherry";
    }

    void CremeP1()
    {
        imageLeft.localPosition = new Vector3(-1000f, imageLeft.localPosition.y, imageLeft.localPosition.z);
        imageLeft.GetComponent<Image>().sprite = cremeFlipped;

        if (!isAnimating)
        {
            isAnimating = true;
            imageLeft.localPosition = new Vector3(-1000f, imageLeft.localPosition.y, imageLeft.localPosition.z);
            LeanTween.moveLocalX(imageLeft.gameObject, -500f, animationTime).setEaseOutCubic().setOnComplete(() => isAnimating = false);
        }

        ActiveP1 = "creme";
    }

    void CremeP2()
    {
        imageRight.localPosition = new Vector3(1000f, imageRight.localPosition.y, imageRight.localPosition.z);
        imageRight.GetComponent<Image>().sprite = cremeNormal;

        if (!isAnimating)
        {
            isAnimating = true;
            imageRight.localPosition = new Vector3(1000f, imageRight.localPosition.y, imageRight.localPosition.z);
            LeanTween.moveLocalX(imageRight.gameObject, 500f, animationTime).setEaseOutCubic().setOnComplete(() => isAnimating = false);
        }

        ActiveP2 = "creme";
    }

    void SetScene()
    {
        //when fight is clicked, enable the panel and set the image sprite to the two players selected.

        panel.GetComponent<RectTransform>().localScale = Vector3.one;

        if (ActiveP1=="cherry" && ActiveP2 == "creme")
        {
            panel.GetComponent<Image>().sprite = cherryCreme;
            PlayVsAudio(cherryCremeAudio);
            StartCoroutine(SwitchScene("CherryVsCream 1"));
        }

        else if (ActiveP1=="cherry" && ActiveP2 == "cherry")
        {
            panel.GetComponent<Image>().sprite = cherryCherry;
            PlayVsAudio(cherryCherryAudio);
            StartCoroutine(SwitchScene("Cherry vs Cherry"));
        }

        else if (ActiveP1=="creme" && ActiveP2 == "cherry")
        {
            panel.GetComponent<Image>().sprite = cremeCherry;
            PlayVsAudio(cremeCherryAudio);
            StartCoroutine(SwitchScene("Cream vs Cherry"));
        }

        else if (ActiveP1=="creme" && ActiveP2 == "creme")
        {
            panel.GetComponent<Image>().sprite = cremeCreme;
            PlayVsAudio(cremeCremeAudio);
            StartCoroutine(SwitchScene("CreamVsCream 1"));
        }

        else if (ActiveP1=="cherry" && ActiveP2 == "cremeAI")
        {
            panel.GetComponent<Image>().sprite = cherryCreme;
            PlayVsAudio(cherryCremeAudio);
            StartCoroutine(SwitchScene("Cherry vs creamAI"));
        }

        else if (ActiveP1 == "cherry" && ActiveP2 == "cherryAI")
        {
            panel.GetComponent<Image>().sprite = cherryCherry;
            PlayVsAudio(cherryCherryAudio);
            StartCoroutine(SwitchScene("cherryAi vs Cherry"));
        }

        else if (ActiveP1 == "creme" && ActiveP2 == "cherryAI")
        {
            panel.GetComponent<Image>().sprite = cremeCherry;
            PlayVsAudio(cremeCherryAudio);
            StartCoroutine(SwitchScene("Cream vs CHERRYAi"));
        }

        else if (ActiveP1 == "creme" && ActiveP2 == "cremeAI")
        {
            panel.GetComponent<Image>().sprite = cremeCreme;
            PlayVsAudio(cremeCremeAudio);
            StartCoroutine(SwitchScene("CreamVsCreamAI"));
        }
    }

    void PlayVsAudio(AudioClip clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }

    IEnumerator SwitchScene(string sceneName)
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
