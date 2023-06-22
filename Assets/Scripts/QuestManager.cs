using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    public List<Vector3> questPoints = new();

    public GameObject currentQuest;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SpawnQuest()
    {
        currentQuest = ObjectPoolManager.Instance.ReleaseObject(ObjectID.QuestMarker);
        currentQuest.transform.position = questPoints[Random.Range(0, questPoints.Count)];
        currentQuest.SetActive(true);
    }
}
