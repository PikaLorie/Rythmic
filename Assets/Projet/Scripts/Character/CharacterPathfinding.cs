using System;
using UnityEngine;
using UnityEngine.AI;


public class CharacterPathfinding : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent = null;
    
    private float minDistance;
   
    public event Action OnPathEnded;

    public void SetDestination(Vector3 target, float minDistance)
    {
        enabled = true;
        this.minDistance = minDistance;

        navMeshAgent.SetDestination(target);
    }
  
    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance <= minDistance)
        {
            enabled = false;
            OnPathEnded?.Invoke();
        }
    }
}
