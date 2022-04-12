using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAudio : MonoBehaviour
{
    [SerializeField] private RepetitiveSound punchSound = null;
    [SerializeField] private CharacterCombat characterCombat = null;
    [SerializeField] private float minDelayBetweenSounds = 0.3f;

    private float nextAllowedTime;

    private void Awake()
    {
        characterCombat.OnStartPunch += PlayPunchSound;
    }

    private void PlayPunchSound()
    {
        if (Time.time > nextAllowedTime)
            punchSound.PlaySound();

        nextAllowedTime = Time.time + minDelayBetweenSounds;
    }
}
