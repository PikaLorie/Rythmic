using System;
using UnityEngine;


public class CharacterAnimationEvents : MonoBehaviour
{
    public event Action OnHitAnimationEnded;
    public event Action OnPunchAnimationEnded;
    public event Action OnPunchDamage;
    public event Action OnFootstep;
    public event Action OnJumpAnimationEnded;

    public void HitAnimationEnded()
    {
        OnHitAnimationEnded?.Invoke();
    }

    public void JumpAnimationEnded()
    {
        OnJumpAnimationEnded?.Invoke();
    }

    public void PunchAnimationEnded()
    {
        OnPunchAnimationEnded?.Invoke();
    }

    public void PunchDamage()
    {
        OnPunchDamage?.Invoke();
    }

    public void Footstep()
    {
        OnFootstep?.Invoke();
    }
}
