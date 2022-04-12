using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip onClic;
    public AudioClip onHover;

    public void HoverSound()
    {
        myFX.PlayOneShot(onHover);
    }

    public void ClicSound()
    {
        myFX.PlayOneShot(onClic);
    }
}
