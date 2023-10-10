using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public static ManageScene Instance; //static class

    private void Awake()
    {
        Instance = this; //accessing the current class
    }

    public enum Scene
    {
        StartScreen, //index 0 
        SelectScreen //index 1
    }


    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.SelectScreen.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(Scene.SelectScreen.ToString());
    }
}
