using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static int xProperty = Animator.StringToHash("x");

    private static int zProperty = Animator.StringToHash("z");

    [SerializeField] private PlayerMovement movement = null;

    [SerializeField] private Animator animator = null;

    private void LateUpdate()
    {
        Vector3 currentMovement = movement.LocalCurrentMovement;
        float speed = movement.MaxSpeed;

        animator.SetFloat(xProperty, currentMovement.x / speed);
        animator.SetFloat(zProperty, currentMovement.z / speed);
    }



}
