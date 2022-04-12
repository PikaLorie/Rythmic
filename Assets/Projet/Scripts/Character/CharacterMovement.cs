using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    [SerializeField] private float combatSpeed = 3f;

    [SerializeField] private float angularSpeed = 60f;

    [SerializeField] private float accelerationDuration = 0.25f;
    
    private Vector3 direction;

    private float accelerationStart;
    public float LocalCurrentRotation { get; private set; }
    private float deltaRotationY;

    private bool isCombatMode = false;
    
    public Vector3 LocalCurrentMovement { get; private set; }

    public float MaxSpeed => isCombatMode ? combatSpeed : speed;

    public bool IsCombatMode => isCombatMode;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    private void Start()
    {
        playerCollider = gameObject.GetComponentInChildren<CapsuleCollider>();
        
    }
    public bool isGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f,playerCollider.bounds.center.z), 0.24f, layerMask:3);
    }

    public void SetCombatMode(bool isCombatMode)
    {
        this.isCombatMode = isCombatMode;
    }

    public void SetDirection(Vector3 direction)
    {
        if (this.direction == Vector3.zero && direction != Vector3.zero)
            accelerationStart = Time.time;

        this.direction = direction.normalized;
    }
    
    private void Update()
    {
        Movements();
        Rotations();
    }

    private void Movements()
    {
        float ratio = (Time.time - accelerationStart) / accelerationDuration;
        float actualSpeed = Mathf.Lerp(0f, MaxSpeed, ratio);

        LocalCurrentMovement = direction * actualSpeed;

        transform.position = transform.position + transform.TransformDirection(LocalCurrentMovement) * Time.deltaTime;

    }

    private void Rotations()
    {
        LocalCurrentRotation = deltaRotationY;
        transform.rotation = Quaternion.Euler(0f, LocalCurrentRotation * angularSpeed * Time.deltaTime, 0f) * transform.rotation;
    }



}
