using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MenuPanel;
    public GameObject PlayPanel;

    public void Play()
    {
        MenuPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Continue()
    {

    }

    public void Back()
    {
        PlayPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
