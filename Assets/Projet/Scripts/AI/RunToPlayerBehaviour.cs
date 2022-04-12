using System;
using UnityEngine;


public class RunToPlayerBehaviour : MonoBehaviour, AIBehaviour
{
    [SerializeField] private int priority = 0;

    [SerializeField] private float minDistance = 0;

    [SerializeField] private float refreshTimer = 1f;

    [SerializeField] private Transform playerTransform = null;
    
    [SerializeField] private CharacterPathfinding pathfinding = null;
    
    private float refreshTime;
   
    public event Action OnBehaviourEnded;

    public int Priority => priority;

    public void Play()
    {
        enabled = true;

        pathfinding.OnPathEnded += OnPathfindingEnded;
        pathfinding.SetDestination(playerTransform.position, minDistance);

        refreshTime = Time.time + refreshTimer;
    }

    public bool ShouldExecute()
    {
        return playerTransform && (transform.position - playerTransform.position).magnitude > minDistance;
    }
    
    private void Awake()
    {
        enabled = false;    
    }

    private void Update()
    {
        if (Time.time > refreshTime)
        {
            pathfinding.SetDestination(playerTransform.position, minDistance);
            refreshTime = Time.time + refreshTimer;
        }
    }
    private void OnPathfindingEnded()
    {
        enabled = false;

        pathfinding.OnPathEnded -= OnPathfindingEnded;
        OnBehaviourEnded?.Invoke();
    }
}
