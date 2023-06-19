using UnityEngine;

public class LoopingWall : MonoBehaviour
{
    static Vector3 change;
    static float offset = 0.05f;
    private void OnTriggerEnter(Collider other)
    {
        switch (transform.parent.localEulerAngles.y)
        {
            case 0:
                change = Vector3.left * (TileGrid.Instance.xWidth - offset);
                break;
            case 90:
                change = Vector3.forward * (TileGrid.Instance.zLength - offset);
                break;
            case 180:
                change = Vector3.right * (TileGrid.Instance.xWidth - offset);
                break;
            case 270:
                change = Vector3.back * (TileGrid.Instance.zLength - offset);
                break;
        }
        bool temp = other.CompareTag("Player");
        if (temp)
        {
            other.GetComponent<CharacterController>().enabled = false;
        }
        other.transform.position += change;
        if (temp)
        {
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
