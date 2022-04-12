using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NormalModeBehaviour : MonoBehaviour, AIBehaviour
{
    [SerializeField] private int priority = 0;

    [SerializeField] private float minDistance = 0;

    [SerializeField] private Transform playerTransform = null;

    [SerializeField] private CharacterCombat combat = null;

    public int Priority => priority;

    public event Action OnBehaviourEnded;

    public void Play()
    {
        combat.SetCombatMode(false);
        OnBehaviourEnded?.Invoke();
    }

    public bool ShouldExecute()
    {
        return combat.IsCombatMode && playerTransform && (transform.position - playerTransform.position).magnitude > minDistance;
    }
}
