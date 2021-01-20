using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject splashScreen;

    private void Awake()
    {
        if(GameController.splashAlreadyAppeared == false)
        {
            splashScreen.SetActive(true);
            StartCoroutine(DisableSplashScreen());
        }    
    }

    IEnumerator DisableSplashScreen()
    {
        yield return new WaitForSeconds(3f);
        LeanTween.alphaCanvas(splashScreen.GetComponent<CanvasGroup>(), 0, 0.5f);

        yield return new WaitForSeconds(1.1f);
        GameController.splashAlreadyAppeared = true;
        splashScreen.SetActive(false);
    }
}
