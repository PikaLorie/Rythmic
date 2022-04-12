using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget = null;
    [SerializeField] private Transform cameraTargetRenderer = null;
    [SerializeField] private Vector2 rotationSpeed = new Vector2(180f, 180f);

    private Vector2 directionDelta;

    private void LateUpdate()
    {
        CameraRotation();
    }

    public void SetDeltaRotation(Vector2 directionDelta)
    {
        this.directionDelta = directionDelta;
    }

    private void CameraRotation()
    {
        float yRotation = directionDelta.x * rotationSpeed.x;
        float xRotation = directionDelta.y * rotationSpeed.y;

        cameraTarget.rotation = Quaternion.Euler(0f, yRotation, 0f);
        cameraTargetRenderer.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }



}
