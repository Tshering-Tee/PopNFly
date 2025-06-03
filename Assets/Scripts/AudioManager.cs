using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource eventSource;
    public AudioSource backgroundSource;

    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip playerDeadSound;
    public AudioClip buttonSound;
    public AudioClip backgroundSound;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySound(AudioClip sounds)
    {
        eventSource.PlayOneShot(sounds);

    }
    public void PlayJumpSound()
    {
        PlaySound(jumpSound);
    }
    public void PlayScoreSound()
    {
        PlaySound(scoreSound);
    }
    public void PlayPlayerDeadSound()
    {
        PlaySound(playerDeadSound);
    }
    public void PlayButtonSound()
    {
        PlaySound(buttonSound);
    }

    public void PlayBackgroundSound()
{
    if (!backgroundSource.isPlaying)
    {
        backgroundSource.clip = backgroundSound;
        backgroundSource.loop = true;
        backgroundSource.Play();
    }
}
}