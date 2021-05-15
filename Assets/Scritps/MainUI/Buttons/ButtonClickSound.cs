using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    private void Awake()
    {
        SetAudioSource();
    }

    private void SetAudioSource()
    {
        if (gameObject.TryGetComponent<AudioSource>(out AudioSource audio))
        {
            audioSource = audio;
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayClickSound()
    {
        audioSource.clip = clickSound;
        audioSource.Play();
    }
}
