using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement = null;


    private Vector3 currentDirection = Vector3.zero;

    private Vector3 smoothdampVelocity;


    void Update()
    {
      Vector3 newdirection = Vector3.zero;

      if(Input.GetKey(KeyCode.Z))
        {
            
            newdirection.z += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newdirection.z -= 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newdirection.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newdirection.x += 1;
        }

        newdirection = Vector3.ClampMagnitude(newdirection, 1);

        currentDirection = Vector3.SmoothDamp(currentDirection, newdirection, ref smoothdampVelocity, 0.05f, 10f);

        playerMovement.Move(currentDirection);
    }

}
