using UnityEngine;


public class HitState : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterAnimationEvents>().HitAnimationEnded();
    }
}
