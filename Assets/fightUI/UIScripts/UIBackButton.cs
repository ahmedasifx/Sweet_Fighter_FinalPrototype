using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackButton : MonoBehaviour
{
    [SerializeField] Button _mainMenu;
        
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        ManageScene.Instance.LoadScene(ManageScene.Scene.StartScreen);
    }
}
