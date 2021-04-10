using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool splashAlreadyAppeared;

    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void CloseGame(){
         #if UNITY_EDITOR
         if(UnityEditor.EditorApplication.isPlaying)
             UnityEditor.EditorApplication.isPlaying = false;
         #endif 
         Application.Quit();
    }

    public void saveChanges(){
        PlayerPrefs.Save();
    }

}