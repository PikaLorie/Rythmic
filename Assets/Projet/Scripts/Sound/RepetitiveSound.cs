using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetitiveSound : MonoBehaviour
{
    [SerializeField, Range(0.01f, 0.5f)] private float pitchDelta = 0.1f;
    [SerializeField] private AudioClip[] clips = null;

    private AudioSource[] audioSources = null;

    private float initialPitch;

    public void PlaySound()
    {
        float randomizedPitchDelta = Random.Range(-pitchDelta, pitchDelta);
        AudioClip clip = clips[Random.Range(0, clips.Length)];

        AudioSource selectedAudioSource = null;

        foreach (AudioSource audioSource in audioSources)
            if(!audioSource.isPlaying)
            {
                selectedAudioSource = audioSource;
                break;
            }

        if ( selectedAudioSource)
        {
            selectedAudioSource.pitch = initialPitch + randomizedPitchDelta;
            selectedAudioSource.PlayOneShot(clip);
        }
    }
    private void Awake()
    {
        audioSources = GetComponentsInChildren<AudioSource>();

        initialPitch = audioSources[0].pitch;
    }
}
