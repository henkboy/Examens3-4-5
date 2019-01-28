using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public CameraX CameraX;
    public CameraY CameraY;
    private bool IsPaused;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused == true)
            {
                Continue();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CameraX.enabled = true;
        CameraY.enabled = true;
        IsPaused = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CameraX.enabled = false;
        CameraY.enabled = false;
        IsPaused = true;
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}