using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
    protected IAState _stateMachine = null;

    public IAState StateMachine { set => _stateMachine = value; }

    public abstract void Move();
    public abstract AIState NextState();
}

public class IDLEState : AIState
{
    public override void Move()
    {
        _stateMachine.Movement.move(Vector3.zero);
    }

    public override AIState NextState()
    {
        if (_stateMachine.DistanceToTarget < _stateMachine.FollowDistance)
        {
            AIState state = new FollowPlayerState();
            state.StateMachine = _stateMachine;
            return state;
        }
        return this;
    }

}

public class FollowPlayerState : AIState
{
    public override void Move()
    {
        _stateMachine.Movement.move(Vector3.ClampMagnitude(_stateMachine.ToTarget, 1));
    }

    public override AIState NextState()
    {
      if(_stateMachine.DistanceToTarget > _stateMachine.FollowDistance)
        {
            AIState state = new IDLEState();
            state.StateMachine = _stateMachine;
            return state;

        }
        return this;
    }

}

public class WaitNearPlayerState : AIState
{
    public override void Move()
    {
        _stateMachine.Movement.move(Vector3.zero);
    }

    public override AIState NextState()
    {
        if (_stateMachine.DistanceToTarget > _stateMachine.FollowDistance)
        {
            AIState state = new FollowPlayerState();
            state.StateMachine = _stateMachine;
            return state;

        }

        if(_stateMachine.DistanceToTarget < _stateMachine.StopDistance)
        {
            AIState state = new WaitNearPlayerState();
            state.StateMachine = _stateMachine;
            return state;
        }
        return this;
    }

}

public class IAState : MonoBehaviour
{
    private AIState _currentState = new IDLEState();

    [SerializeField] private Transform _target;
    [SerializeField] private float _followDistance;
    [SerializeField] private float _stopDistance;

    private Movement _movement;
    private Vector3 _toTarget = Vector3.one;
    private float _distanceToTarget = 0;

    public Movement Movement { get => _movement;}
    public Vector3 ToTarget { get => _toTarget;}
    public float DistanceToTarget { get => _distanceToTarget;}
    public float StopDistance { get => _stopDistance;}
    public float FollowDistance { get => _followDistance;}

    public void computeToTarget()
    {
        _toTarget = _target.position - transform.position;
        _distanceToTarget = _toTarget.magnitude;
    }

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _currentState.StateMachine = this;
    }

    private void Update()
    {
        computeToTarget();
        _currentState = _currentState.NextState();
        _currentState.Move();
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _followDistance);

        Gizmos.color = new Color(1, 1 ,0, 0.3f);
        Gizmos.DrawSphere(transform.position, _stopDistance);


    }*/
}
