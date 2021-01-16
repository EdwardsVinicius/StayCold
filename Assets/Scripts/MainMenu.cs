using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject splashScreen;

    private void Awake()
    {
        splashScreen.SetActive(true);
        StartCoroutine(disableSplashScreen());
    }

    IEnumerator disableSplashScreen()
    {
        yield return new WaitForSeconds(3f);
        LeanTween.alphaCanvas(splashScreen.GetComponent<CanvasGroup>(), 0, 0.5f);

        yield return new WaitForSeconds(1.1f);
        splashScreen.SetActive(false);

    }
}
