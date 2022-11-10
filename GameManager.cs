using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
        DontDestroyOnLoad(this);
    }

    private string levelName;
    AudioSource collectionAudio;
    private int soulsCollected = 0;

    public int SoulsCollected
    {
        get { return soulsCollected; }
        set { soulsCollected = value; }
    }

    private void Start()
    {
        collectionAudio = GetComponent<AudioSource>();
    }

    public void SubscriptToCollectableEvents()
    {
        CollectableEventSystem.current.onCollectableCollected += LoadCutScene;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadEndScreen()
    {
        SceneManager.LoadSceneAsync("EndScreen");
    }

    public void LoadCutScene(int id)
    {
        if (id != 0) collectionAudio.Play();
        UnSubscribeFromCollectableEvents();
        switch (id)
        {
            case 0:
                SceneManager.LoadSceneAsync("Day_1");
                break;

            case 1:
                SceneManager.LoadSceneAsync("Day_2");
                break;

            case 2:
                SceneManager.LoadSceneAsync("Day_3");
                break;

            case 3:
                SceneManager.LoadSceneAsync("Day_4");
                break;

            case 4:
                SceneManager.LoadSceneAsync("Day_5");
                break;

            default:
                LoadEndScreen();
                break;
        }

    }

    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("The_Level");
    }

    private void UnSubscribeFromCollectableEvents()
    {
        if (levelName != "The_Level") return;
        CollectableEventSystem.current.onCollectableCollected -= LoadCutScene;
    }

    private void OnDestroy()
    {
       UnSubscribeFromCollectableEvents();
    }
}
