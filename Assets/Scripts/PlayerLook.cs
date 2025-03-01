using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    [Header("Sensitivity Settings")]
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    [Header("Rotation Limits")]
    public float minLookAngle = -80f;
    public float maxLookAngle = 80f;



    public void ProcessLook(Vector2 input)
    {
    
        float mouseX = input.x * xSensitivity * Time.deltaTime;
        float mouseY = input.y * ySensitivity * Time.deltaTime;

        // Vertical rotation (clamped)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);
        cam.transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);

        // Horizontal rotation (unclamped for free rotation)
        transform.Rotate(Vector3.up * mouseX);
    }
}
