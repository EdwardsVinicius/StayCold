using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ConfigMenuButton : MonoBehaviour
{
    public Sprite onButton;
    public Sprite offButton;
    public AudioMixer audio;
    private bool state;

    public Image imageButton;
    // Start is called before the first frame update
    void Start()
    {
        
        if(PlayerPrefs.HasKey(gameObject.name))
        {
            state = bool.Parse(PlayerPrefs.GetString(gameObject.name));
        }else
        {
            state = true;
            PlayerPrefs.SetString(gameObject.name, state.ToString());
        }
        imageButton.sprite = state?onButton:offButton;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void switchButton()
    {
        state = !state;
        PlayerPrefs.SetString(gameObject.name, state.ToString());
        if(state)
        {
            imageButton.sprite = onButton;
            audio.SetFloat("VolumeMaster", 0);
        }else
        {
            imageButton.sprite = offButton;
            audio.SetFloat("VolumeMaster", -80);
        }
    }
}
