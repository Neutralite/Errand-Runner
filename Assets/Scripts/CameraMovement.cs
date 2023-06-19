using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseX;
    [SerializeField]
    float mouseSensitivity = 200f;
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
