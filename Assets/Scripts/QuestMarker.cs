using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.Score++;
            transform.parent.gameObject.SetActive(false);
            ObjectPoolManager.Instance.ReturnObject(transform.parent.gameObject);
            QuestManager.Instance.SpawnQuest();
        }
    }
}
