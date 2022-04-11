using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector3 _deplacement = Vector3.zero;
    public float _speed = 20f;
    public float MaxSpeed => _speed;
    private float accelerationStart;
    public Vector3 LocalCurrentMovement { get; private set; }
    [SerializeField] private float accelerationDuration = 0.25f;

    public void Move(Vector3 deplacement)
    {

        _deplacement = deplacement;
        float ratio = (Time.time - accelerationStart) / accelerationDuration;
        float actualSpeed = Mathf.Lerp(0f, MaxSpeed, ratio);

        LocalCurrentMovement = _deplacement * actualSpeed;

        transform.position = transform.position + transform.TransformDirection(LocalCurrentMovement) * Time.deltaTime;

    }
    
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       _rigidbody.velocity = _deplacement  * _speed;
    }
}
