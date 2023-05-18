using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Function for the UI to display a Holodeck (voice recording) Node's functions and visual demonstrate the status of the voice recording
/// </summary>

public class HoloManager : MonoBehaviour
{
    public Image fillBar;
    public AudioSource audioSource;


    
    float fillAmount;

    bool play;
    bool pause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log($"At sample {audioSource.timeSamples} out of {audioSource.clip.samples}");
        }
        if (play && !pause)
        {
            fillAmount = (float)audioSource.timeSamples / (float)audioSource.clip.samples;
            fillBar.fillAmount = fillAmount;
        }
        if (!audioSource.isPlaying && !pause)
        {            
            play = false;
        }
    }


    public void ResetClip()
    {
        fillBar.fillAmount = 0f;
        play = false;
        pause = false;
        audioSource.Stop();
    }

    public void PauseClip()
    {
        if (audioSource.isPlaying)
        {
            pause = true;
            audioSource.Pause();
        }
        
    }

    public void StartClip()
    {
        if (play && pause)
        {
            pause = false;
            audioSource.Play();
        }
        if (!play) //Only play if not playing already
        {
            play = true;
            pause = false;
            audioSource.Play();
        }
        
    }

    public void LoadAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        fillBar.fillAmount = 0f;
    }
}
