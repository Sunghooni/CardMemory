using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;

    [Header("AudioClip")]
    public AudioClip ringClip;
    public AudioClip flipClip;
    public AudioClip clearClip;
    public AudioClip failClip;

    private void Awake()
    {
        instance = gameObject.GetComponent<SoundManager>();
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

    public void PlayRingSound()
    {
        audioSource.clip = ringClip;
        audioSource.Play();
    }

    public void PlayFlipSound()
    {
        audioSource.clip = flipClip;
        audioSource.Play();
    }

    public void PlayClearSound()
    {
        audioSource.clip = clearClip;
        audioSource.Play();
    }

    public void PlayFailSound()
    {
        audioSource.clip = failClip;
        audioSource.Play();
    }
}
