using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsAudio : MonoBehaviour
{
    [SerializeField] private RepetitiveSound footstepSound = null;
    [SerializeField] private CharacterAnimationEvents characterAnimationEvents = null;
    [SerializeField] private float minDelayBetweenSounds = 0.2f;

    private float nextAllowedTime;

    private void Awake()
    {
        characterAnimationEvents.OnFootstep += PlayFootstepSound;
    }

    private void PlayFootstepSound()
    {
        if(Time.time > nextAllowedTime)
        footstepSound.PlaySound();

        nextAllowedTime = Time.time + minDelayBetweenSounds;
    }

}
