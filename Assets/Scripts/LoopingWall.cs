using UnityEngine;

public class LoopingWall : MonoBehaviour
{
    static Vector3 change;
    static float offset = 0.05f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
            Player.Instance.controller.enabled = false;
            other.transform.position += change;
            Player.Instance.controller.enabled = true;
        }
        
    }
}
