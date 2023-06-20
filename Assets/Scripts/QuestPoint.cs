using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        QuestManager.Instance.questPoints.Add(transform.position);
    }
}
