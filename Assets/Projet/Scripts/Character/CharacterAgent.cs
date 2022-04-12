using UnityEngine;
using UnityEngine.AI;


public class CharacterAgent : MonoBehaviour
{
    [SerializeField] private float speed = 9f;

    [SerializeField] private float combatSpeed = 3f;

    [SerializeField] private CharacterCombat characterCombat = null;

    [SerializeField] private NavMeshAgent navMeshAgent = null;

    [SerializeField] private Health health = null;


    private void Update()
    {
        if(health.isDead == false)
        {
            navMeshAgent.speed = characterCombat.IsCombatMode ? combatSpeed : speed;
        }
    }
}
