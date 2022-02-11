using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float lookSensivity;
    [SerializeField] private float smoothing;
    [SerializeField] private int maxLookingRotation;

    private GameObject player;

    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPosition;

    void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensivity * smoothing, lookSensivity * smoothing));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

        /*
        if (currentLookingPosition.y + smoothedVelocity.y > 90f || currentLookingPosition.y + smoothedVelocity.y < -90f)
        {
            currentLookingPosition.x += smoothedVelocity.x;
        }
        else
        {
            currentLookingPosition += smoothedVelocity;
        }*/

        currentLookingPosition += smoothedVelocity;

        currentLookingPosition.y = Mathf.Clamp(currentLookingPosition.y, -maxLookingRotation, maxLookingRotation);

        //look up and down
        transform.localRotation = Quaternion.AngleAxis(-currentLookingPosition.y, Vector3.right);
        //look left and right
        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);
    }
}
