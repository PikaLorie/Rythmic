using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedMax = 6;

    private Vector3 _currentDirection;
    private Rigidbody _rb;

    public void move (Vector3 direction)
    {
        _currentDirection = direction;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _currentDirection * _speedMax;
    }
}
