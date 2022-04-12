using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterActions : MonoBehaviour
{
    [SerializeField] private CharacterAnimationEvents events = null;

    public event Action OnJumpEnded;
    public event Action OnStartJump;

    private void Awake()
    {
        events.OnJumpAnimationEnded += JumpEnded;
    }

    public void Jump()
    {
      OnStartJump?.Invoke();
    }

    private void JumpEnded()
    {
        OnJumpEnded?.Invoke();
    }
}
