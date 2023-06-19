using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        QuestManager.Instance.questPoints.Add(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
