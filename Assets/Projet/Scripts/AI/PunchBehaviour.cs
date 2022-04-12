using System;
using UnityEngine;


public class PunchBehaviour : MonoBehaviour, AIBehaviour
{
    [SerializeField] private int priority = 0;

    [SerializeField] private Transform playerTransform = null;

    [SerializeField] private float maxDistance = 0.4f;

    [SerializeField] private CharacterCombat combat = null;
    [SerializeField] private Health health = null;

    public event Action OnBehaviourEnded;

    public int Priority => priority;

    public void Play()
    {
        if (health.isDead == false)
        {
            combat.OnPunchEnded += OnPunchEnded;
            combat.Punch();

        }
    }

    public bool ShouldExecute()
    {
        return combat.IsCombatMode && !combat.IsStunned && playerTransform && (playerTransform.position - transform.position).magnitude <= maxDistance;
    }
  
    private void OnPunchEnded()
    {
        combat.OnPunchEnded -= OnPunchEnded;
        OnBehaviourEnded?.Invoke();
    }
}