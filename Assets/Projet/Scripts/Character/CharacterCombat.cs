using System;
using UnityEngine;


public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement = null;

    [SerializeField] private Health health = null;

    [SerializeField] private CharacterAnimationEvents events = null;

    [SerializeField] private LayerMask punchMask = default;

    [SerializeField] private float punchRange = 0.5f;

    [SerializeField] private float punchHeight = 1.4f;
   
    private bool isCombatMode = false;

    private bool isStunned = false;
    
    public event Action OnStartPunch;

    public event Action OnPunchEnded;

    public event Action OnStun;

    public event Action OnStunEnded;

    public event Action OnDeath;


    public bool IsCombatMode => isCombatMode;

    public bool IsStunned => isStunned;

    public void SetCombatMode(bool isCombatMode)
    {

        this.isCombatMode = isCombatMode;
        movement.SetCombatMode(isCombatMode);
    }

    public void Punch()
    {
        if (IsCombatMode && !IsStunned)
            OnStartPunch?.Invoke();
    }
   
    private void Awake()
    {
        events.OnPunchDamage += ApplyPunchDamage;

        health.OnDamageTaken += Stun;
        //health.OnDeath += Death;
        events.OnHitAnimationEnded += StunEnded;
        events.OnPunchAnimationEnded += PunchEnded;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 start = transform.position + Vector3.up * punchHeight;
        Vector3 end = start + transform.forward * punchRange;

        Gizmos.DrawLine(start, end);
    }
    
    private void ApplyPunchDamage()
    {
        if (IsStunned)
            return;

        Vector3 start = transform.position + Vector3.up * punchHeight;
        Vector3 direction = transform.forward;

        RaycastHit[] hits = Physics.RaycastAll(start, direction, punchRange, punchMask);

        Debug.DrawLine(start, start + direction, Color.red,2f);

        foreach (RaycastHit hit in hits)
        {
            Health health = hit.collider.GetComponent<Health>();
            health.Hit(1);
        }
    }

    private void PunchEnded()
    {
        OnPunchEnded?.Invoke();
    }

    private void Stun(int damage)
    {
        isStunned = true;

        OnStun?.Invoke();
    }

    private void StunEnded()
    {
        isStunned = false;
        OnStunEnded?.Invoke();
    }

   
   


}
