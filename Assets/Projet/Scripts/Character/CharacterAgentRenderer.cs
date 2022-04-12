using UnityEngine;
using UnityEngine.AI;

public class CharacterAgentRenderer : MonoBehaviour
{
    private static int xProperty = Animator.StringToHash("x");

    private static int zProperty = Animator.StringToHash("z");
    
    [SerializeField] private NavMeshAgent movement = null;

    [SerializeField] private Animator animator = null;
  
    private void LateUpdate()
    {
        Vector3 currentMovement = transform.InverseTransformVector(movement.velocity);
        float speed = movement.speed;

        animator.SetFloat(xProperty, currentMovement.x / speed);
        animator.SetFloat(zProperty, currentMovement.z / speed);
    }
}
