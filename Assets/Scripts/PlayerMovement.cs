using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x, z;
    [SerializeField]
    float speed=1f;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Player.Instance.controller.Move(move * speed * Time.deltaTime);
    }
}
