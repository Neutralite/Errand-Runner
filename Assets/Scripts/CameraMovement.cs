using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseX,mouseY,xRotation;
    [SerializeField]
    float mouseSensitivity = 200f;
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
