using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private EventSystem _event;
    public GameObject gameHUD;
    public GameObject pauseMenuUI;
    public GameObject configMenuUI;
    public GameObject firstToSelect;
    public GameObject configButton;
    //public GameObject backFromConfigButton;
    //public GameObject firstInConfigButton;
    //public Scene main;
    private GameController _controller;
    //private UIController _uiController;
    private bool inConfig=false;

    void Start()
    {
        _event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        _controller = GameObject.Find("GameController").GetComponent<GameController>();
        //_uiController = GameObject.Find("UIController").GetComponent<UIController>();
        //configButton.GetComponent<Button>().onClick.AddListener(delegate() {_event.SetSelectedGameObject(firstInConfigButton);});
        //backFromConfigButton.GetComponent<Button>().onClick.AddListener(delegate() {_event.SetSelectedGameObject(configButton);});
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
        gameHUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _event.SetSelectedGameObject(null);
        //SceneManager.SetActiveScene(main);
        //_uiController.toResume = true;
    }

    public void Pause()
    {
        gameHUD.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        _event.SetSelectedGameObject(firstToSelect);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu",  LoadSceneMode.Single);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,  LoadSceneMode.Single);
    }

    public void switchState()
    {
        inConfig = !inConfig;
    }

    public void addEventSystem(EventSystem eventSys, GameObject button)
    {
        eventSys.SetSelectedGameObject(button);
    }
}
