using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject controlsPanel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        GameManager.instance.SoulsCollected = 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.instance.LoadCutScene(0);
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        GameManager.instance.LoadMainMenu();
    }
}
