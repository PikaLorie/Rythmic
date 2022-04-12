using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBehaviour : MonoBehaviour, AIBehaviour
{
    [SerializeField] private int priority = 0;

    [SerializeField] private CharacterCombat combat = null;
   
    public int Priority => priority;

    public event Action OnBehaviourEnded;

    public void Play()
    {
        combat.OnStunEnded += OnStunEnded;
    }

    public bool ShouldExecute()
    {
        return combat.IsStunned;
    }
    
    private void OnStunEnded()
    {
        combat.OnStunEnded -= OnStunEnded;
        OnBehaviourEnded?.Invoke();
    }
}
