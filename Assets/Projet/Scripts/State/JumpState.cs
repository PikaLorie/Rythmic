using UnityEngine;


public class JumpState : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterAnimationEvents>().JumpAnimationEnded();
    }
}
