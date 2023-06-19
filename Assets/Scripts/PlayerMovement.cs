using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x, z;
    [SerializeField]
    float speed=1f;

    [SerializeField]
    CharacterController controller;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
