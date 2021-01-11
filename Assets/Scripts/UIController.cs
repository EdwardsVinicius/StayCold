using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //Health instances
    public bool health=false;
    public GameObject penguinHealth;
    public GameObject bearHealth;
    private LifeSlider _penguinSlider;
    private LifeSlider _bearSlider;
    //Score instances
    public bool score=false;

    //Pause instances
    public bool pause=false;
    private bool _isPaused=false;
    public bool toResume=true;
    
    //Main instances
    private Scene _ui;
    //private Scene _main;
    private GameObject _gameController;
    private GameObject[] _rootObjects;

    void Awake() 
    {
        //_main = SceneManager.GetActiveScene();
        SceneManager.LoadScene("InGame_UI", LoadSceneMode.Additive);
        _ui = SceneManager.GetSceneAt(1);
    }

    void Start()
    {
        _rootObjects = _ui.GetRootGameObjects();
        _gameController = GameObject.Find("GameController");
        //_gameController.GetComponent<PauseMenu>().main = _main;
        penguinHealth = GameObject.Find("HolderPenguinHUD");
        bearHealth = GameObject.Find("HolderBearHUD");
        _penguinSlider = penguinHealth.GetComponentInChildren<LifeSlider>();
        _bearSlider = bearHealth.GetComponentInChildren<LifeSlider>();
        //SceneManager.SetActiveScene(_main);
        ChangeHealthUIState(health);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            //Time.timeScale = 0f;
            toResume = false;
            _isPaused = true;
            ChangeHealthUIState(false);
            SceneManager.SetActiveScene(_ui);
        }
        
        if(toResume && _isPaused)
        {
            //Time.timeScale = 1f;
            ChangeHealthUIState(true);
        }
    }

    public void ChangeHealthValue(int value, string name)
    {
        if(name == "bear")
        {
            _bearSlider.SetHealth(value);
        }else
        {
            if(name == "penguin")
            {
                _penguinSlider.SetHealth(value);
            }
        }
    }

    private void ChangeHealthUIState(bool state)
    {
        penguinHealth.SetActive(state);
        bearHealth.SetActive(state);
    }
}
