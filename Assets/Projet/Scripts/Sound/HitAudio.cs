using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudio : MonoBehaviour
{
    [SerializeField] private RepetitiveSound HitSound = null;
    [SerializeField] private CharacterAnimationEvents characterAnimationEvents = null;
    [SerializeField] private float minDelayBetweenSounds = 0.2f;

    private float nextAllowedTime;

    private void Awake()
    {
        characterAnimationEvents.OnHitAnimationEnded += PlayHitSound;
    }

    private void PlayHitSound()
    {
        if (Time.time > nextAllowedTime)
            HitSound.PlaySound();

        nextAllowedTime = Time.time + minDelayBetweenSounds;
    }
}
