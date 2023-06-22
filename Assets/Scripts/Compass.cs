using Unity.VisualScripting;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    Vector3 dir,forward,rotation;

    // Update is called once per frame
    void Update()
    {
        dir = QuestManager.Instance.currentQuest.transform.position - Player.Instance.transform.position;
        forward = Player.Instance.transform.forward;
        rotation.z = 180 + Vector3.SignedAngle(dir, forward, Vector3.up);
        transform.eulerAngles = rotation;
    }
}
