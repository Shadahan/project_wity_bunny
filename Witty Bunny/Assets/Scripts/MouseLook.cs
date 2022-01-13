using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Tooltip("A multiplier to the input. Describes the maximum speed in degrees/second. To flip vertical rotation, set Y to a negative value")]
    [SerializeField] private Vector2 sensitivity;

    private Vector2 rotation; // The current rotation in degrees


    private Vector2 GetInput()
    {
        // Get the input vector. This can be changed to work with the new input system or even touch controls
        // Using Unity's original input system to get the mouse movement on the screen in pixels since the last update
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
        );
        return input;
    }

    private void Update() {
        // The wanted velocity is the current input scaled by the sensitivity
        // This is also the maximum velocity
        Vector2 wantedVelocity = GetInput() * sensitivity;

        // Calculate new rotation
        rotation += wantedVelocity * Time.deltaTime;

        // Convert the rotation to euler angles
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}
