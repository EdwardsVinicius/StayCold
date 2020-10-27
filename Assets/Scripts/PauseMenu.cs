using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private EventSystem _event;
    public GameObject pauseMenuUI;
    public GameObject configMenuUI;
    public GameObject firstToSelect;
    public GameObject configButton;
    private GameController _controller;
    private bool inConfig=false;

    void Start()
    {
        _event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        _controller = GameObject.Find("GameController").GetComponent<GameController>();
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!inConfig)
            {
                if(GameIsPaused)
                {
                    Resume();   
                }else
                {
                    Pause();
                }
            }else
            {
                switchState();
                configMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
                _event.SetSelectedGameObject(configButton);
                _controller.saveChanges();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        // Time.timeScale = 1f;
        GameIsPaused = false;
        _event.SetSelectedGameObject(null);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        // Time.timeScale = 0f;
        GameIsPaused = true;
        _event.SetSelectedGameObject(firstToSelect);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu",  LoadSceneMode.Single);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,  LoadSceneMode.Single);
    }

    public void switchState()
    {
        inConfig = !inConfig;
    }
}
