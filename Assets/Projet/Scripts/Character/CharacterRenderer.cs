using UnityEngine;


public class CharacterRenderer : MonoBehaviour
{
    private static int combatProperty = Animator.StringToHash("combat");

    private static int punchProperty = Animator.StringToHash("punch");

    private static int hitProperty = Animator.StringToHash("hit");

    private static int jumpProperty = Animator.StringToHash("jump");

    private static int deathProperty = Animator.StringToHash("death");

    [SerializeField] private CharacterCombat combat = null;
    [SerializeField] private CharacterActions characterActions = null;
    [SerializeField] private Health health = null;

    [SerializeField] private Animator animator = null;
   
    private void Awake()
    {
        combat.OnStartPunch += PlayPunchAnimation;
        combat.OnStun += PlayStunAnimation;
        characterActions.OnStartJump += PlayJumpAnimation;
        health.OnDeath += PlayDeathAnimation;



    }

    private void LateUpdate()
    {
        animator.SetBool(combatProperty, combat.IsCombatMode);
    }
   
    private void PlayPunchAnimation()
    {
        animator.SetTrigger(punchProperty);
    }

    private void PlayStunAnimation()
    {
        animator.SetTrigger(hitProperty);
    }

    private void PlayJumpAnimation()
    {
        animator.SetTrigger(jumpProperty);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(deathProperty);
    }
}
