using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TileGridManager.Instance.questPoints.Add(this);
        gameObject.SetActive(false);
    }
}
