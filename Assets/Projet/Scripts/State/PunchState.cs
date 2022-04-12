using UnityEngine;


public class PunchState : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterAnimationEvents>().PunchAnimationEnded();
    }
}
