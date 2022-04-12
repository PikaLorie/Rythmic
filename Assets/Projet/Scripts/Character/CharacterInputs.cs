using UnityEngine;


public class CharacterInputs : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement = null;

    [SerializeField] private CharacterCamera characterCamera = null;

    [SerializeField] private CharacterCombat characterCombat = null;

    [SerializeField] private CharacterActions characterActions = null;

    [SerializeField] private Health health = null;

    private float cameraRotationY;
    private float cameraRotationX;

    private void Awake()
    {
    }
    private void Update()
    {
        if(health.isDead == false)
        {
            HandleMovementInputs();
            HandleCameraRotationInputs();
            HandleCombatInputs();
            HandleJumpInputs();
        }
       

    }
  
    private void HandleMovementInputs()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.Z))
            direction.z += 1;

        if (Input.GetKey(KeyCode.S))
            direction.z -= 1;


        if (Input.GetKey(KeyCode.Q))
            direction.x -= 1;

        if (Input.GetKey(KeyCode.D))
            direction.x += 1;

        movement.SetDirection(direction);
    }

    private void HandleCameraRotationInputs()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        float _mouseY = Input.GetAxis("Mouse Y");

        cameraRotationY += _mouseX;
        cameraRotationX += -_mouseY;

        cameraRotationX = Mathf.Clamp(cameraRotationX, 20f, 30f);

        Vector2 _mouseDelta = new Vector2(cameraRotationY, cameraRotationX);

        characterCamera.SetDeltaRotation(_mouseDelta);
    }

    private void HandleCombatInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            characterCombat.SetCombatMode(!movement.IsCombatMode);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            characterCombat.Punch();
    }

    private void HandleJumpInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && movement.isGrounded())
        {
            Vector3 vector3 = gameObject.GetComponent<Rigidbody>().velocity;
            vector3.y = movement.jumpSpeed.y;

            gameObject.GetComponent<Rigidbody>().velocity = movement.jumpSpeed;

            characterActions.Jump();
        }
}
}
