using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;

    public Image musicButton;
    public Image soundButton;
    public Sprite sfxOn;
    public Sprite sfxDown;


    // public Image vibrateButton;

    // public Boolean vibrate;


    public void BackgroundMusicController()
    {
        if (musicButton.sprite == offMusic)
        {
            musicButton.GetComponent<Image>().sprite = onMusic;
            AudioManager.instance.backgroundSource.volume = 1f;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = offMusic;
            AudioManager.instance.backgroundSource.volume = 0f;
        }
    }

    public void EventGameSound()
    {
        if (soundButton.sprite == sfxDown)
        {
            soundButton.GetComponent<Image>().sprite = sfxOn;
            AudioManager.instance.eventSource.volume = 1f;

        }
        else
        {
            soundButton.GetComponent<Image>().sprite = sfxDown;
            AudioManager.instance.eventSource.volume = 0;
        }
    }


    // public void isVibrate()
    // {
    //     if (vibrateButton.sprite == offMusic)
    //     {
    //         vibrateButton.GetComponent<Image>().sprite = onMusic;
    //         Handheld.Vibrate();
    //         vibrate = true;
    //     }
    //     else
    //     {
    //         vibrateButton.GetComponent<Image>().sprite = offMusic;
    //         vibrate = false;
    //     }
    // } 
}