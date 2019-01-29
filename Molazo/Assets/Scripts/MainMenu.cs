using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject MenuPanel;
    public GameObject PlayPanel;
    public Button ContinueButton;

    void Start()
    {
        if(PlayerPrefs.GetInt("Progress") == 0)
        {
            ContinueButton.interactable = false;
        }
    }

    public void Play()
    {
        MenuPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Progress", 0);
        SceneManager.LoadScene("MainScene");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainScene");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
